using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Gerador.Library
{
    public class LibraryID
    {

        public static string RecuperaIDProcessador()
        {
            string idProcessador = string.Empty;

            string query = "SELECT ProcessorId FROM Win32_Processor";

            ManagementObjectSearcher mos = new ManagementObjectSearcher(query);

            ManagementObjectCollection moc = mos.Get();

            foreach (ManagementObject mo in moc)
            {
                idProcessador = mo["ProcessorId"].ToString();
            }

            return idProcessador;
        }
    }
}
   

