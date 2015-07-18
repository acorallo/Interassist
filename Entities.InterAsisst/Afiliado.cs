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
    public class Afiliado : PersistEntity, IRepository
    {
        
        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        public Afiliado()
        {
        }


        public Afiliado(int id, string ObjectHash)
        {
            this._id = id;
            this._UObjectID = ObjectHash;

        }

        #endregion Constructores

        #region Miembros de Entidad

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _poliza;

        public string Poliza
        {
            get { return _poliza; }
            set { _poliza = value; }
        }
        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _codigoPostal;

        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }
        private DateTime _fechaDesde = DateTime.MinValue;

        public DateTime FechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }
        private DateTime _fechaHasta = DateTime.MinValue;

        public DateTime FechaHasta
        {
            get { return _fechaHasta; }
            set { _fechaHasta = value; }
        }
        private string _documento;

        public string Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }
        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        private string _patente;

        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
        }
        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        private string _año;

        public string Año
        {
            get { return _año; }
            set { _año = value; }
        }

        private int _idempresa;

        public int IDEmpresa
        {
            get { return _idempresa; }
            set { _idempresa = value; }
        }

        private string _categoria = string.Empty;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private string _nombreCategoria = string.Empty;

        public string NombreCategoria
        {
            get { return _nombreCategoria; }
            set { _nombreCategoria = value; }
        }

        private bool _hogar = false;

        public bool Hogar
        {
            get { return _hogar; }
            set { _hogar = value; }
        }

        private string _modelo = string.Empty;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private bool _estado = true;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }



        #endregion Miembros de Entidad

        #region Miembros Adicionales para listados

        string _nombreEmpresa = string.Empty;

        public string NombreEmpresa
        {
            get { return _nombreEmpresa; }
            
        }



        #endregion Miembros

        #region Miembros
        #endregion Miembros

        #region Propiedades

        public override Dataservices getDataService()
        {
            return new AfiliadoDS();
        }

        

        #endregion Propiedades

        #region Metodos

        public static List<Afiliado> List(FiltroAfiliado f)
        {
            int r;
            return List(f, out r);
        }

       

        public static List<Afiliado> List(FiltroAfiliado f, out int RecordCount)
        {
            List<Afiliado> resultList = new List<Afiliado>();

            try
            {
                AfiliadoDS dataservice = new AfiliadoDS();
                DataSet ds = dataservice.List(f, out RecordCount);

                if(ds.Tables.Count>0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Afiliado a = new Afiliado();
                        ORM(a, r);
                        resultList.Add(a);
                    }
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }

        public static List<Afiliado> ListHuerfanos(FiltroAfiliado f, out int RecordCount)
        {
            List<Afiliado> resultList = new List<Afiliado>();

            try
            {
                AfiliadoDS dataservice = new AfiliadoDS();
                DataSet ds = dataservice.ListHuerfanos(f, out RecordCount);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Afiliado a = new Afiliado();
                        ORM(a, r);
                        resultList.Add(a);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }

        public override DataRow ObjectToRow()
        {
            DataRow drResult = null;

            try
            {
                Afiliados.AFILIADOSDataTable dt = (Afiliados.AFILIADOSDataTable)this.Dataservice.getMyTable();
                Afiliados.AFILIADOSRow dr = (Afiliados.AFILIADOSRow)dt.NewRow();

                dr.IDAFILIADO = this.ID;
                dr.IDEMPRESA = this.IDEmpresa;
                dr.APELLIDO = this.Apellido;
                dr.NOMBRE = this.Nombre;
                dr.POLIZA = this.Poliza;
                dr.DIRECCION = this.Direccion;
                dr.CODPOSTAL = this.CodigoPostal;
                dr.FECHADESDE = this.FechaDesde;
                dr.FECHAHASTA = this.FechaHasta;
                dr.IDDOCUMENTO = this.Documento;
                dr.MARCA = this.Marca;
                dr.PATENTE = this.Patente;
                dr.COLOR = this.Color;
                dr.CATEGORIA = this.Categoria;
                dr.ANO = this.Año;
                dr.OBJECTHASH = this.UObjectID;
                dr.HOGAR = this.Hogar ? ACTIVO : NO_ACTIVO;
                dr.MODELO = this.Modelo;
                dr.ESTADO = this.Estado ? ACTIVO : NO_ACTIVO;


                drResult = dr;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return drResult;
        }

        public static void ORM(Afiliado afiliado, DataRow dr)
        {

            afiliado._id = Int32.Parse(dr[AfiliadoDS.COLUMN_ID_AFILIADO].ToString());
            afiliado.Apellido = dr[AfiliadoDS.COLUMN_APELLIDO].ToString();
            afiliado.Nombre = dr[AfiliadoDS.COLUMN_NOMBRE].ToString();
            afiliado.Poliza = dr[AfiliadoDS.COLUMN_POLIZA].ToString();
            afiliado.Direccion = dr[AfiliadoDS.COLUMN_DIRECCION].ToString();
            afiliado.CodigoPostal = dr[AfiliadoDS.COLUMN_COD_POSTAL].ToString();
            afiliado.Documento = dr[AfiliadoDS.COLUMN_DOCUMENTO].ToString();
            afiliado.Marca = dr[AfiliadoDS.COLUMN_MARCA].ToString();
            afiliado.Patente = dr[AfiliadoDS.COLUMN_PATENTE].ToString();
            afiliado.Color = dr[AfiliadoDS.COLUMN_COLOR].ToString();
            afiliado.Año = dr[AfiliadoDS.COLUMN_AÑO].ToString(); 
            afiliado.IDEmpresa = Int32.Parse(dr[AfiliadoDS.COLUMN_IDEMPRESA].ToString());
            afiliado.FechaDesde = ((DateTime)dr[AfiliadoDS.COLUMN_FECHADESDE]);
            afiliado.FechaHasta = ((DateTime)dr[AfiliadoDS.COLUMN_FECHAHASTA]);
            afiliado._nombreEmpresa = dr[AfiliadoDS.COLUMN_NOMBRE_EMPRESA].ToString();
            afiliado.Categoria = dr[AfiliadoDS.COLUMN_CATEGORIA].ToString();
            afiliado.NombreCategoria = dr[AfiliadoDS.COLUMN_CATEGORIA_NOMBRE].ToString();
            afiliado.Hogar = Int32.Parse(dr[AfiliadoDS.COLUMN_HOGAR].ToString()) == ACTIVO;
            afiliado.Modelo = dr[AfiliadoDS.COLUMN_MODELO].ToString();
            afiliado.Estado = Int32.Parse(dr[AfiliadoDS.COLUMN_ESTADO].ToString()) == ACTIVO;

        }

        public static Afiliado GetById(int id)
        {
            Afiliado afiliadoResult = null;

            try
            {
                AfiliadoDS afiliadoDS = new AfiliadoDS();
                String objectHash = Guid.NewGuid().ToString();
                DataRow dr = afiliadoDS.GetObjectById(id, objectHash);

                if (dr != null)
                {
                    afiliadoResult = new Afiliado();
                    afiliadoResult._UObjectID = objectHash;
                    ORM(afiliadoResult, dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return afiliadoResult;
        }

        public static Afiliado GetAfiliadoByPoliza(string poliza)
        {
            Afiliado result = null;
            int RecordCount;
            try
            {
                FiltroAfiliado f = new FiltroAfiliado();
                f.Poliza = poliza;
                

                AfiliadoDS dataservice = new AfiliadoDS();
                DataSet ds = dataservice.List(f, out RecordCount);

                if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    result = new Afiliado();
                    ORM(result, ds.Tables[0].Rows[0]);
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
            
        } 

        #endregion Metodos

    }
}
