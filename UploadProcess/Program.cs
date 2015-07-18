using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadProcess
{
    class Program
    {

        private static readonly string errorMsg = "El proceso finalizo con errores. Descripción del error {0}. Mensaje: {1}";

        static void Main(string[] args)
        {


            try
            {
                Entities.Configuration.WriteConsole("Inicio de proceso.");
                Entities.ServiceProcess.RunProcess();
                Entities.Configuration.WriteConsole("Fin de Proceso.");
            }
            catch (Exception ex)
            {

                Exceptions.ExceptionManager.TrackError(String.Format(errorMsg, ex.ToString(), ex.Message));
            }

        }
    }
}
