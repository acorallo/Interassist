using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils.InterAssist;

namespace UI.InterAssist.Modelviews
{
    
    [Serializable]
    public class PrestadorModelView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Iva { get; set; }
        public string Email { get; set; }
        
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public string Domicilio { get; set; }
        
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Nextel { get; set; }
        public string Comentarios { get; set; }
        public string Activo { get; set; }

        public float? LIV_MOVIDA { get; set; }
        public float? LIV_KM { get; set; }

        public float? SP1_MOVIDA { get; set; }
        public float? SP1_KM { get; set; }

        public float? SP2_MOVIDA { get; set; }
        public float? SP2_KM { get; set; }

        public float? PS1_MOVIDA { get; set; }
        public float? PS1_KM { get; set; }

        public float? PS2_MOVIDA { get; set; }
        public float? PS2_KM { get; set; }
        
/*
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

        */
        public static PrestadorModelView getPrestadorModelView(Entities.InterAsisst.Prestador p)
        {
            PrestadorModelView resultPrestador = new PrestadorModelView();

            resultPrestador.Id = p.ID;
            resultPrestador.Nombre = p.Nombre;
            resultPrestador.Pais = p.NombrePais;
            resultPrestador.Provincia = p.ProvinciaNombre;
            resultPrestador.Localidad = p.LocalidadNombre;
            resultPrestador.Ciudad = p.NombreCiudad;
            resultPrestador.Domicilio = p.Domicilio;
            resultPrestador.Telefono1 = p.Telefono1;
            resultPrestador.Telefono2 = p.Telefono2;
            resultPrestador.Celular1 = p.Celular1;
            resultPrestador.Celular2 = p.Celular2;
            resultPrestador.Nextel = p.Nextel;
            resultPrestador.Comentarios = p.Descripcion;
            resultPrestador.Iva = p.Iva;
            resultPrestador.Cuit = p.Cuit;
            resultPrestador.Activo = p.Activo ? Resource.TXT_ACTIVO : Resource.TXT_NO_ACTIVO;
            resultPrestador.Email = p.Email;

            resultPrestador.LIV_MOVIDA = p.LIV_MOVIDA;
            resultPrestador.LIV_KM = p.LIV_KM;
            resultPrestador.SP1_MOVIDA = p.SP1_MOVIDA;
            resultPrestador.SP1_KM = p.SP1_KM;

            resultPrestador.SP2_MOVIDA = p.SP2_MOVIDA;
            resultPrestador.SP2_KM = p.SP2_KM;

            resultPrestador.PS1_MOVIDA = p.PS1_MOVIDA;
            resultPrestador.PS1_KM = p.PS1_KM;

            resultPrestador.PS2_MOVIDA = p.PS2_MOVIDA;
            resultPrestador.PS2_KM = p.PS2_KM;
        
            return resultPrestador;
        }

        public static List<PrestadorModelView> getPrestadorModelView(List<Entities.InterAsisst.Prestador> listp)
        {
            List<PrestadorModelView> resultList = new List<PrestadorModelView>();

            foreach (var p in listp)
            {
                resultList.Add(getPrestadorModelView(p));
            }

            return resultList;
        }

    }
}