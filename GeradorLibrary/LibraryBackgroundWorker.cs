using System;
using System.Collections.Generic;
using System.Text;

namespace Gerador
{
    #region BackgroundWorker
    public class BackgroundWorker
    {
        bool m_CancelPending = false;
        bool m_ReportsProgress = false;
        bool m_SupportsCancellation = false;

        public event DoWorkEventHandler DoWork;
        public event ProgressChangedEventHandler ProgressChanged;
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;

        public bool WorkerSupportsCancellation
        {
              get
              {
                    lock(this)
                    {
                          return m_SupportsCancellation;
                    }
              }
              set
              {
                    lock(this)
                    {
                          m_SupportsCancellation = value;
                    }
              }
        }

        public bool WorkerReportsProgress
        {
              get
              {
                    lock(this)
                    {
                          return m_ReportsProgress;
                    }
              }
              set
              {
                    lock(this)
                    {
                          m_ReportsProgress = value;
                    }
              }
        }

        public bool CancellationPending
        {
              get
              {
                    lock(this)
                    {
                          return m_CancelPending;
                    }
              }
        }    

        public void RunWorkerAsync()
        {
              RunWorkerAsync(null);
        }

        public void RunWorkerAsync(object argument)
        {
              m_CancelPending = false;
              if(DoWork != null)
              {
                    DoWorkEventArgs args = new DoWorkEventArgs(argument);
                    AsyncCallback callback;
                    callback = new AsyncCallback(ReportCompletion);
                    DoWork.BeginInvoke(this,args,callback,args);
              }
        }

        public void ReportProgress(int percent)
        {
              if(WorkerReportsProgress)
              {
                    ProgressChangedEventArgs progressArgs;
                    progressArgs = new ProgressChangedEventArgs(percent);                  
                    OnProgressChanged(progressArgs);
              }
        }

        public void CancelAsync()
        {
              lock(this)
              {
                    m_CancelPending = true;
              }
        }

        protected virtual void OnProgressChanged(ProgressChangedEventArgs progressArgs)
        {
              ProcessDelegate(ProgressChanged,this,progressArgs);
        }

        protected virtual void OnRunWorkerCompleted(RunWorkerCompletedEventArgs completedArgs)
        {
              ProcessDelegate(RunWorkerCompleted,this,completedArgs);
        }

        public delegate void DoWorkEventHandler(object sender, DoWorkEventArgs e);
        public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
        public delegate void RunWorkerCompletedEventHandler(object sender, RunWorkerCompletedEventArgs e);


        void ProcessDelegate(Delegate del,params object[] args)
        {
              Delegate temp = del;
              if(temp == null)
              {
                    return;
              }
              Delegate[] delegates = temp.GetInvocationList();
              foreach(Delegate handler in delegates)
              {
                    InvokeDelegate(handler,args);
              }
        }

        void InvokeDelegate(Delegate del,object[] args)
        {
              System.ComponentModel.ISynchronizeInvoke synchronizer;
              synchronizer = del.Target as System.ComponentModel.ISynchronizeInvoke;
              if(synchronizer != null) //A Windows Forms object
              {
                    if(synchronizer.InvokeRequired == false)
                    {
                          del.DynamicInvoke(args);
                          return;
                    }
                    try
                    {
                          synchronizer.Invoke(del,args);
                    }
                    catch
                    {}
              }  
              else //Not a Windows Forms object
              {
                    del.DynamicInvoke(args);
              } 
        }

        void ReportCompletion(IAsyncResult asyncResult)
        {
              System.Runtime.Remoting.Messaging.AsyncResult ar = (System.Runtime.Remoting.Messaging.AsyncResult)asyncResult;
              DoWorkEventHandler del;
              del  = (DoWorkEventHandler)ar.AsyncDelegate;
              DoWorkEventArgs doWorkArgs = (DoWorkEventArgs)ar.AsyncState;
              object result = null;
              Exception error = null;
              try
              {
                    del.EndInvoke(asyncResult);
                    result = doWorkArgs.Result;
              }
              catch(Exception exception)
              {
                    error = exception;
              }
              RunWorkerCompletedEventArgs completedArgs = new RunWorkerCompletedEventArgs(result, error, doWorkArgs.Cancel);
              OnRunWorkerCompleted(completedArgs);
        }

    }
    #endregion

    #region AsyncCompletedEventArgs
    public class AsyncCompletedEventArgs : EventArgs
    {    
        public AsyncCompletedEventArgs (bool cancelled,Exception ex)
        {
              Cancelled= cancelled;
              Error = ex;
        }

        public AsyncCompletedEventArgs(){}

        public readonly Exception Error;
        public readonly bool Cancelled;          
    }
    #endregion

    #region CancelEventArgs
    public class CancleEventArgs : EventArgs
    {
        private bool m_cancel = false;
        public bool Cancel
        {
              get
              {
                    return m_cancel;
              }
              set
              {
                    m_cancel=value;
              }
        }          
    }
    #endregion

    #region DoWorkEventArgs
    public class DoWorkEventArgs : CancleEventArgs
    {
        public bool Result
        {
              get
              {
                    return false;
              }
              set
              {
                   
              }
        }

        public readonly object Argument;   

        public DoWorkEventArgs(object objArgument)
        {
              Argument = objArgument;
        }
    }
    #endregion

    #region ProgressChangedEventArgs
    public class ProgressChangedEventArgs : EventArgs
    {
        public readonly int ProgressPercentage;        

        public ProgressChangedEventArgs (int intProgressPercentage)
        {
              ProgressPercentage = intProgressPercentage;
        }
    }
    #endregion

    #region RunWorkerCompletedEventArgs
    public class RunWorkerCompletedEventArgs : AsyncCompletedEventArgs
    {          
        public readonly object Result;

        public RunWorkerCompletedEventArgs (object objResult, Exception exException, bool bCancel)
              :base(bCancel,exException)
        {                
              Result = objResult;
        }
    }
    #endregion
}
