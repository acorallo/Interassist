using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.InterAssist;
using System.Security.Cryptography;
using Cognitas.Framework.Repository;
using Cognitas.Framework.Repository.Interfaces;
using Utils.InterAssist;


namespace Entities.InterAsisst
{
    [Serializable]
    public class Operador : PersistEntity, IRepository
    {

        #region Constantes

        public const int MIN_LONG_USUARIO = 6;
        public const int MAX_LONG_USUARIO = 25;
        public const int MIN_PASSWORD = 6;

        #endregion Constantes

        #region Constructores

        public Operador(int id, string ObjectHasH)
        {
            this._id = id;
            this._UObjectID = ObjectHasH;
        }

        public Operador()
        {

        }

        public static Operador GetById(int id)
        {
            Operador resultOperador = null;

            try
            {
                OperadorDS dsOperador = new OperadorDS();
                string ObjectHash = Guid.NewGuid().ToString();
                DataRow drResult = dsOperador.GetObjectById(id, ObjectHash);

                if (drResult != null)
                {
                    resultOperador = new Operador();
                    resultOperador._UObjectID = ObjectHash;
                    ORM(resultOperador, drResult);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return resultOperador;
        }

        public static Operador GetByCredeciales(string usuario, string clave)
        {
            Operador resulOperador = null;

            try
            {
                FiltroOperador f = new FiltroOperador();
                f.Usuario = usuario;
                f.Clave = GetHash(clave);

                OperadorDS dataservice = new OperadorDS();

                DataSet ds = dataservice.List(f);
                

                if(ds.Tables[0].Rows.Count>0)
                {
                    Operador o = new Operador();
                    ORM(o, ds.Tables[0].Rows[0]);
                    resulOperador = o;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulOperador;
        }



        #endregion Constuctores

        #region Miembros

        private string _nombre = string.Empty;
        private string _apellido = string.Empty;
        private string _usuario = string.Empty;
        private string _clave = string.Empty;
        private string _email = string.Empty;
        private bool _activo = false;
        private bool _admin = false;

        #endregion Miembros

        #region Propiedades

        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        
        }

        public string Usuario
        {
            get
            {
                return this._usuario;
            }
            set
            {
                this._usuario = value;
            }
        }

        public string Clave
        {
            get
            {
                return this._clave;
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    
        #endregion Propiedades

        #region Metodos

        private static void ORM(Operador operador, DataRow dr)
        {
            operador._id = Int32.Parse(dr[OperadorDS.COLUMN_ID_OPERADOR].ToString());
            operador.Usuario = dr[OperadorDS.COLUMN_USUARIO].ToString();
            operador.Email = dr[OperadorDS.COLUMN_EMAIL].ToString();
            operador.Nombre = dr[OperadorDS.COLUMN_NOMBRE].ToString();
            operador.Apellido = dr[OperadorDS.COLUMN_APELLIDO].ToString();
            operador._clave = dr[OperadorDS.COLUMN_CLAVE].ToString();
            operador.Activo = Int32.Parse(dr[OperadorDS.COLUMN_ACTIVO].ToString()) == Dataservices.ACTIVO;
            operador.Admin = Int32.Parse(dr[OperadorDS.COLUMN_ADMIN].ToString()) == Dataservices.ACTIVO;

        }

        public override DataRow ObjectToRow()
        {
            DataRow dr = null;

            DAL.InterAssist.Datasets.Operadores.OPERADORESDataTable dtable = (DAL.InterAssist.Datasets.Operadores.OPERADORESDataTable)this.Dataservice.getMyTable();
            dr = dtable.NewRow();

            dr[dtable.IDOPERADORColumn] = this.ID;
            dr[dtable.USUARIOColumn] = this.Usuario;
            dr[dtable.CLAVEColumn] = this.Clave;
            dr[dtable.NOMBREColumn] = this.Nombre;
            dr[dtable.APELLIDOColumn] = this.Apellido;
            dr[dtable.EMAILColumn] = this.Email;
            dr[dtable.ACTIVOColumn] = this.Activo ? Dataservices.ACTIVO : Dataservices.NO_ACTIVO;
            dr[dtable.ADMINColumn] = this.Admin ? Dataservices.ACTIVO : Dataservices.NO_ACTIVO;
            dr[dtable.OBJECTHASHColumn] = this._UObjectID;
            
            return dr;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private static string GetHash(string textoClave)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, textoClave);
            }
        }

        private string EncodeClave(string rowTextClave)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetHash(rowTextClave);
            }
        }

        public void SetClave(string textoClave)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                this._clave = EncodeClave(textoClave);
            }
        }

        public bool CambiarClave(string Clave)
        {
            bool result = false;

            try
            {
                OperadorDS dsOperador = new OperadorDS();
                result = dsOperador.ModificarClave(this.ID, EncodeClave(Clave));
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return result;
        }

        public string ResetPassword()
        {
            string result = "provisoria" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

            this.CambiarClave(result);

            return result;
                 
        }


        public bool VerficarClave(string textClave)
        {
            bool result = false;

            using (MD5 md5Hash = MD5.Create())
            {
                result = GetMd5Hash(md5Hash, textClave) == this.Clave;
            }

            return result;
        }

        public static Operador GetByUsuario(string usuario)
        {
            Operador resulOperador = null;

            try
            {
                FiltroOperador filtro = new FiltroOperador();
                filtro.Usuario = usuario;

                OperadorDS dataserviceOperador = new OperadorDS();
                DataSet ds = dataserviceOperador.List(filtro);
                
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    resulOperador = new Operador();
                    ORM(resulOperador, ds.Tables[0].Rows[0]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulOperador;
        }

        public static List<Operador> List(FiltroOperador f)
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                OperadorDS dataservice = new OperadorDS();
                DataSet ds = dataservice.List(f);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Operador o = new Operador();
                        ORM(o, dr);
                        operadores.Add(o);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }



            return operadores;
        }

        #endregion Metodos

        #region IRepository Objects

        public override Dataservices getDataService()
        {
            return new OperadorDS();
        }

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        #endregion IRepository Objects

    }
}
