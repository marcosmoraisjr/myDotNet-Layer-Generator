using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Gen.DAL
{
    public class Banco
    {
        //ATRIBUTOS
        private SqlConnection oConnection = null;
        private string connectionString = null;
        private SqlDataAdapter oDataAdapter = null;
        private SqlCommand oCommand = null;
        private DataSet oDataSet = null;

        //CONSTRUTOR
        public Banco(string strConn)
        {
            //connectionString = @"Data Source=MMSTEC-01\SQLEXPRESS;Initial Catalog=MMSTEC;Integrated Security=True";
            connectionString = @""+strConn;
            try
            {
                oConnection = new SqlConnection(connectionString);
            }
            catch
            {
                throw new Exception("Erro ao conectar com o banco. Verifica a string de conexão.");
            }
        }

        //MÉTODOS
        /// <summary>
        /// Executa comandos sql e retorna o número de linhas afetadas.
        /// </summary>
        /// <param name="sSQL">Comando sql</param>
        /// <returns>int regAffect</returns>
        public int ExecutaQuery(string sSQL)
        {
            int regAffect = 0;
            try
            {
                oCommand = new SqlCommand(sSQL, oConnection);
                oConnection.Open();
                regAffect = oCommand.ExecuteNonQuery();
                if (regAffect == 0)
                {
                    throw new Exception("Ocorreu um erro no comando sql, entre em contato com o administrador do sistema.");
                }
                else
                {
                    return regAffect;
                }

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                oConnection.Dispose();
                oCommand.Dispose();
            }

        }

        /// <summary>
        /// Retorna um data set apartir de um comando sql
        /// </summary>
        /// <param name="command">Comando sql</param>
        /// <param name="table">Nome da tabela</param>
        /// <returns>DataSet oDataSet</returns>
        public DataSet GetDataSet(string command, string table)
        {
            try
            {

                oConnection.Open();
                oCommand = new SqlCommand(command, oConnection);
                oDataAdapter = new SqlDataAdapter(oCommand);
                oDataSet = new DataSet();
                oDataAdapter.Fill(oDataSet, table);
                return oDataSet;
            }
            catch (SqlException err)
            {
                throw err;
            }
            finally
            {
                oConnection.Dispose();
                oCommand.Dispose();
                oDataAdapter.Dispose();
            }
        }

        /// <summary>
        /// Executa select no banco
        /// </summary>
        /// <param name="command"></param>
        /// <returns>DataReader oCommand.ExecuteReader()</returns>
        public SqlDataReader QueryConsulta(string command)
        {
            try
            {
                oConnection.Open();
                oCommand = new SqlCommand(command, oConnection);
                return oCommand.ExecuteReader();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                //oConnection.Dispose();
                //oCommand.Dispose();
            }
        }

        public void CloseConn()
        {
            oConnection.Dispose();
        }
    }
}
