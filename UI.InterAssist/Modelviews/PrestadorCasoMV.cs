using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entities.InterAsisst;
using System.Security.Cryptography;
using Cognitas.Framework.Repository;
using Cognitas.Framework.Repository.Interfaces;
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



        public Entities.InterAsisst.PrestadorCaso getPrestadorCaso()
        {
            Entities.InterAsisst.PrestadorCaso result = new Entities.InterAsisst.PrestadorCaso();

            if(this.IdPrestador>0)
                result.Prestador = Entities.InterAsisst.Prestador.Get_Shadow(this.IdPrestador);

            if (this.IdTipoAsistencia.Trim()!=String.Empty)
                result.TipoServicio = Entities.InterAsisst.TipoServicio.get_Shadow(Int32.Parse(this.IdTipoAsistencia));
            
            result.Comentarios = string.Empty;
            
            result.TipoOperacion = this.Estado;
            result.Costo = this.Costo;
            result.Kilometros = this.Kilometros;

            // Verifica si es un nuevo id y en tal caso lo convierte a null.
            if (Utils.InterAssist.Constants.IsNewPrefix(this.Id))
                result.ID = Entities.InterAsisst.PersistEntity.NULL_ID;
            else
                result.ID = Int32.Parse(this.Id);

            return result;
        }
         
    }
}