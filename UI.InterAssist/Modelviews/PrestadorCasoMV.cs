using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils.InterAssist;

namespace UI.InterAssist.Modelviews
{
    [Serializable]
    public class PrestadorCasoMV
    {
        public string Id
        {
            get;
            set;
        }


        public decimal Kilometros
        {
            get;
            set;
        }

        public decimal Costo
        {
            get;
            set;
        }



        public string IdTipoAsistencia
        {
            get;
            set;
        }

        public string TipoAsistencia
        {
            get;
            set;
        }

        public int IdPrestador
        {
            get;
            set;
        }

        public string Prestador
        {
            get;
            set;
        }

        public Constants.PersistOperationType Estado
        {
            get
            {
                return this._estado;
            }

            set
            {
                this._estado = value;
            }
        }


        public string InternalID
        {
            get
            {
                return this._internalID;
            }
            set
            {
                this._internalID = value;
            }
        }

        private Constants.PersistOperationType _estado = Constants.PersistOperationType.Void;
        private string _internalID;


        public static PrestadorCasoMV getPrestadorCasoMV(Entities.InterAsisst.PrestadorCaso casoprestador)
        {
            PrestadorCasoMV p = new PrestadorCasoMV();

            p.Id = casoprestador.ID.ToString();
            p.Kilometros = casoprestador.Kilometros;
            p.Costo = casoprestador.Costo;
            p.IdTipoAsistencia = casoprestador.TipoServicio.ID.ToString();
            p.IdPrestador = casoprestador.Prestador.ID;
            p.Prestador = casoprestador.Prestador.Nombre;

            return p;
        }


        public static List<PrestadorCasoMV> getList(List<Entities.InterAsisst.PrestadorCaso> ps)
        {
            List<PrestadorCasoMV> resultList = new List<PrestadorCasoMV>();

            foreach(var prestadorcaso in ps)
            {
                resultList.Add(getPrestadorCasoMV(prestadorcaso));
            }

            return resultList;
        }
    }
}