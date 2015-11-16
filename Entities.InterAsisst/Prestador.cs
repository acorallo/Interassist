using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Interfaces;
using Cognitas.Framework.Repository;
using DAL.InterAssist.Datasets;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Prestador : PersistEntity, IRepository
    {

        #region Miembros
        #endregion Miembros

        #region Miembros de Clase

        private string _nombre = string.Empty;
        private string _descripcion = string.Empty;
        private bool _activo = false;


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

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _telefono1 = string.Empty;

        public string Telefono1
        {
            get { return _telefono1; }
            set { _telefono1 = value; }
        }
        private string _telefono2 = string.Empty;

        public string Telefono2
        {
            get { return _telefono2; }
            set { _telefono2 = value; }
        }
        private string _celular1 = string.Empty;

        public string Celular1
        {
            get { return _celular1; }
            set { _celular1 = value; }
        }
        private string _celular2 = string.Empty;

        public string Celular2
        {
            get { return _celular2; }
            set { _celular2 = value; }
        }
        private string _nextel = string.Empty;

        public string Nextel
        {
            get { return _nextel; }
            set { _nextel = value; }
        }

        private string _domicilio = string.Empty;

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }
        private int _idPais = 0;

        public int IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }

        private string _nombrePais = string.Empty;

        public string NombrePais
        {
            get { return _nombrePais; }
            set { _nombrePais = value; }
        }

        private int _idProvincia = 0;

        public int IdProvincia
        {
            get { return _idProvincia; }
            set { _idProvincia = value; }
        }

        private int _idlocalidad = 0;

        public int IdLocalidad
        {
            get { return _idlocalidad; }
            set { _idlocalidad = value; }
        }

        private string _localidadNombre = string.Empty;

        public string LocalidadNombre
        {
            get { return _localidadNombre; }
            set { _localidadNombre = value; }
        }

        private string _provinciaNombre = string.Empty;

        public string ProvinciaNombre
        {
            get { return _provinciaNombre; }
            set { _provinciaNombre = value; }
        }


        private int _idCiudad = 0;

        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }
        private string _nombreCiudad = string.Empty;

        public string NombreCiudad
        {
            get { return _nombreCiudad; }
            set { _nombreCiudad = value; }
        }


        private string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _cuit = string.Empty;

        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }
        private string _iva = string.Empty;

        public string Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private Nullable<float> _LIV_MOVIDA = null;

        public Nullable<float> LIV_MOVIDA
        {
            get { return _LIV_MOVIDA; }
            set { _LIV_MOVIDA = value; }
        }
        private Nullable<float> _LIV_KM = null;

        public Nullable<float> LIV_KM
        {
            get { return _LIV_KM; }
            set { _LIV_KM = value; }
        }
        private Nullable<float> _SP1_MOVIDA = null;

        public Nullable<float> SP1_MOVIDA
        {
            get { return _SP1_MOVIDA; }
            set { _SP1_MOVIDA = value; }
        }
        private Nullable<float> _SP1_KM = null;

        public Nullable<float> SP1_KM
        {
            get { return _SP1_KM; }
            set { _SP1_KM = value; }
        }

        private Nullable<float> _SP2_MOVIDA = null;

        public Nullable<float> SP2_MOVIDA
        {
            get { return _SP2_MOVIDA; }
            set { _SP2_MOVIDA = value; }
        }
        private Nullable<float> _SP2_KM = null;

        public Nullable<float> SP2_KM
        {
            get { return _SP2_KM; }
            set { _SP2_KM = value; }
        }

        private Nullable<float> _PS1_MOVIDA = null;

        public Nullable<float> PS1_MOVIDA
        {
            get { return _PS1_MOVIDA; }
            set { _PS1_MOVIDA = value; }
        }

        private Nullable<float> _PS1_KM = null;

        public Nullable<float> PS1_KM
        {
            get { return _PS1_KM; }
            set { _PS1_KM = value; }
        }

        private Nullable<float> _PS2_MOVIDA = null;

        public Nullable<float> PS2_MOVIDA
        {
            get { return _PS2_MOVIDA; }
            set { _PS2_MOVIDA = value; }
        }

        private Nullable<float> _PS2_KM = null;

        public Nullable<float> PS2_KM
        {
            get { return _PS2_KM; }
            set { _PS2_KM = value; }
        }
        
        #endregion Miembros

        #region constructores
        
        
        public static Prestador Get_Shadow (int id)
        {
            Prestador p = new Prestador();
            p._id = id;
            return p;
        }
        
        public static Prestador GetById(int id)
        {
            Prestador resultPrestador = null;

            PrestadorDS dataServicePrestador = new PrestadorDS();
            String ObjectHash = Guid.NewGuid().ToString();

            DataRow dr = dataServicePrestador.GetObjectById(id, ObjectHash);

            if (dr != null)
            {
                resultPrestador = new Prestador();
                resultPrestador._UObjectID = ObjectHash;
                ORM(resultPrestador, dr);
            }

            return resultPrestador;
        }

        
        public static Prestador GetById_ReadOnly(int id)
        {

            Prestador result = null;
            
            FiltroPrestador f = new FiltroPrestador();
            f.ID = id;

            List<Prestador> listado = List(f);

            if(listado.Count>0)
            {
                result = listado[0];
            }


            return result;


        }

        public Prestador(int id, string ObjectHash)
        {
            this._id = id;
            this._UObjectID = ObjectHash;
        }

        public Prestador()
        {
        }

        #endregion constructores

        #region Propiedades



        #endregion Propiedades

        #region Metodos Estaticos

        public static bool Delete(int id)
        {
            PrestadorDS ds = new PrestadorDS();
            return ds.Delete(id);
        }


        public static List<Prestador> List(FiltroPrestador filtro)
        {
            int RecordCount;
            return List(filtro, out RecordCount);
        }

        public static List<Prestador> List(FiltroPrestador filtro, out int RecordCount)
        {
            List<Prestador> prestadorList = new List<Prestador>();

            try
            {

                PrestadorDS dataService = new PrestadorDS();
                DataSet ds = dataService.List(filtro, out  RecordCount);


                if (ds.Tables.Count>0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Prestador p = new Prestador();
                            
                        ORM(p, r);
                        prestadorList.Add(p);
                    }
                }


            }catch(Exception ex)
            {
                throw ex;
            }

            return prestadorList;
        }

        #endregion Metodos Estaticos

        #region IRepository Objects

        public override Cognitas.Framework.Repository.Dataservices getDataService()
        {
            return new PrestadorDS();
        }

        #endregion IRepository Objects

        #region IRepository Members

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        private static void ORM(Prestador prestador, DataRow dr)
        {
            
            prestador._id = Int32.Parse(dr[PrestadorDS.COL_ID_PRESTADOR].ToString());
            prestador._nombre = dr[PrestadorDS.COL_NOMBRE].ToString();
            prestador._descripcion = dr[PrestadorDS.COL_DESCRIPCION].ToString();
            prestador._activo = Int32.Parse(dr[PrestadorDS.COL_ESTADO].ToString()) == ACTIVO;

            prestador._telefono1 = dr[PrestadorDS.COL_TELEFONO1].ToString();
            prestador._telefono2 = dr[PrestadorDS.COL_TELEFONO2].ToString();
            prestador._celular1 = dr[PrestadorDS.COL_CELULAR1].ToString();
            prestador._celular2 = dr[PrestadorDS.COL_CELULAR2].ToString();
            
            prestador._nextel = dr[PrestadorDS.COL_NEXTEL].ToString();
            prestador._domicilio = dr[PrestadorDS.COL_DOMICILIO].ToString();
            prestador._idCiudad= Int32.Parse(dr[PrestadorDS.COL_ID_CIUDAD].ToString());
            prestador._nombreCiudad = dr[PrestadorDS.COL_NOMBRE_CIUDAD].ToString();

            prestador._provinciaNombre = dr[PrestadorDS.COL_PROVINCA_NOMBRE].ToString();
            prestador._idProvincia = Int32.Parse(dr[PrestadorDS.COL_IDPROVINCIA].ToString());
            prestador._idPais = Int32.Parse(dr[PrestadorDS.COL_IDPAIS].ToString());
            prestador._idlocalidad = Int32.Parse(dr[PrestadorDS.COL_IDLOCALIDAD].ToString());
            prestador._localidadNombre = dr[PrestadorDS.COL_LOCALIDAD_NOMBRE].ToString();

            prestador._nombrePais = dr[PrestadorDS.COL_PAIS_NOMBRE].ToString();
            prestador._email = dr[PrestadorDS.COL_EMAIL].ToString();
            prestador._cuit = dr[PrestadorDS.COL_CUIT].ToString();
            prestador._iva = dr[PrestadorDS.COL_IVA].ToString();

            prestador._LIV_MOVIDA = PersistEntity.FloatConvet(dr[PrestadorDS.COL_LIV_MOVIDA]);
            prestador.LIV_KM = PersistEntity.FloatConvet(dr[PrestadorDS.COL_LIV_KM]);
            prestador.SP1_MOVIDA = PersistEntity.FloatConvet(dr[PrestadorDS.COL_SP1_MOVIDA]);
            prestador.SP1_KM = PersistEntity.FloatConvet(dr[PrestadorDS.COL_SP1_KM]);

            prestador.SP2_MOVIDA = PersistEntity.FloatConvet(dr[PrestadorDS.COL_SP2_MOVIDA]);
            prestador.SP2_KM = PersistEntity.FloatConvet(dr[PrestadorDS.COL_SP2_KM]);

            prestador.PS1_MOVIDA = PersistEntity.FloatConvet(dr[PrestadorDS.COL_PS1_MOVIDA]);
            prestador.PS1_KM = PersistEntity.FloatConvet(dr[PrestadorDS.COL_PS1_KM]);

            prestador.PS2_MOVIDA = PersistEntity.FloatConvet(dr[PrestadorDS.COL_PS2_MOVIDA]);
            prestador.PS2_KM = PersistEntity.FloatConvet(dr[PrestadorDS.COL_PS2_KM]);
  

        }

        public override DataRow ObjectToRow()
        {
            DataRow dr = null;

            Prestadores.PRESTADORESDataTable dt = (Prestadores.PRESTADORESDataTable)this.Dataservice.getMyTable();
            dr = dt.NewRow();

            dr[dt.IDPRESTADORColumn] = this.ID;
            dr[dt.NOMBREColumn] = this.Nombre;
            dr[dt.DESCRIPCIONColumn] = this.Descripcion;
            dr[dt.ESTADOColumn] = this.Activo ? Cognitas.Framework.Repository.Dataservices.ACTIVO : Cognitas.Framework.Repository.Dataservices.NO_ACTIVO;
            dr[dt.OBJECTHASHColumn] = this.UObjectID;
            dr[dt.TELEFONO1Column] = this.Telefono1;
            dr[dt.TELEFONO2Column] = this.Telefono2;
            dr[dt.CELULAR1Column] = this.Celular1;
            dr[dt.CELULAR2Column] = this.Celular2;
            dr[dt.NEXTELColumn] = this.Nextel;
            dr[dt.DOMICILIOColumn] = this.Domicilio;
            dr[dt.IDCIUDADColumn] = this.IdCiudad;
            dr[dt.IDPAISColumn] = this.IdPais;
            dr[dt.IDLOCALIDADColumn] = this.IdLocalidad;
            dr[dt.IDPROVINCIAColumn] = this.IdProvincia;
            dr[dt.EMAILColumn] = this.Email;
            dr[dt.CUITColumn] = this.Cuit;
            dr[dt.IVAColumn] = this.Iva;

            if(this.LIV_MOVIDA!=null)
                dr[dt.LIV_MOVIDAColumn] = this.LIV_MOVIDA;
            
            if(this.LIV_KM!=null)
                dr[dt.LIV_KMColumn] = this.LIV_KM;
            
            if(this.SP1_MOVIDA!=null)
                dr[dt.SP1_MOVIDAColumn] = this.SP1_MOVIDA;
            
            if(this._SP1_KM != null)
                dr[dt.SP1_KMColumn] = this._SP1_KM;
            
            if(this.SP2_MOVIDA !=null)
                dr[dt.SP2_MOVIDAColumn] =this.SP2_MOVIDA;
            
            if(_SP2_KM!=null)
                dr[dt.SP2_KMColumn] = this._SP2_KM;
            
            if(PS1_MOVIDA!=null)
                dr[dt.PS1_MOVIDAColumn] = this.PS1_MOVIDA;
            
            if(_PS1_KM!=null)
                dr[dt.PS1_KMColumn] = this._PS1_KM;

            if (this.PS2_MOVIDA != null)
                dr[dt.PS2_MOVIDAColumn] = this.PS2_MOVIDA;

            if (this._PS2_KM != null)
                dr[dt.PS2_KMColumn] = this._PS2_KM;

            return dr;
        }

        #endregion

    }
}
 