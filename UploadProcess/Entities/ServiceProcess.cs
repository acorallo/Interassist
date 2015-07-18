using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UploadProcess.Entities
{
    public class ServiceProcess
    {

        #region Miembros

        private static bool Running = false;
        private static bool Working = false;


        public static bool MoveFile(string sourceFilePath, string targetFilePath)
        {
            bool result = false;

            string fileName = Path.GetFileName(sourceFilePath);

            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    // This statement ensures that the file is created, 
                    // but the handle is not kept. 
                    using (FileStream fs = File.Create(sourceFilePath)) { }
                }

                // Ensure that the target does not exist. 
                if (File.Exists(targetFilePath))
                    File.Delete(targetFilePath);

                // Move the file.
                File.Move(sourceFilePath, targetFilePath);

                result = true;

            }
            catch (System.Exception ex)
            {
                throw new Exceptions.MoveFileException(fileName, ex);
            }

            return result;
        }

        #endregion Miembros


        

        public static void Start()
        {
            Running = true;
            Task t = new Task(RunProcess);
            t.Start();
            Exceptions.ExceptionManager.TrackStartProcess();

        }

        public static void Stop()
        {
            Running = false;
            while (Working) ;
            Exceptions.ExceptionManager.TrackEndProcess();
        }

        public static void RunProcess()
        {
            bool bMotex;
            // Implements mutex in order to avoid concurrent programing.
            Mutex mutex = new Mutex(false, "InterassistSynchroService_MUTEX", out bMotex);

                try
                {

                    if (bMotex)
                    {
                        
                         string[] files = Directory.GetFiles(Entities.Configuration.PARAM_PREBOUND_PATH);
                         Entities.Configuration.WriteConsole("Accediendo al sistema de archivos.");
                         foreach (string filePath in files)
                         {

                             // Mueve el archivo a inbound.
                             string targetSource = Entities.Configuration.PARAM_INBOUND_PATH + Path.GetFileName(filePath);
                             MoveFile(filePath, targetSource);
                             Entities.Configuration.WriteConsole("Procesando el archivo " + filePath);
                             DAL.UpdateProcess p = new DAL.UpdateProcess();
                             if(!p.RunUpdateProcess(targetSource))
                             {
                                 Exceptions.ExceptionManager.TrackError(String.Format("El procesamiento del archivo {0} termino con errores.", filePath));
                             }

                             string outBound = Configuration.PARAM_OUTBOUND_PATH + Path.GetFileName(targetSource);
                             MoveFile(targetSource, outBound);
                            
                         }

                    }
                }
                catch (System.Exception ex)
                {

                    Exceptions.ExceptionManager.TrackError(ex);
                    Working = false;
                    throw (ex);
                    

                }
                finally
                {

                    Working = false;
                    GC.KeepAlive(mutex);
                }

                Working = false;
            }
    }
}
