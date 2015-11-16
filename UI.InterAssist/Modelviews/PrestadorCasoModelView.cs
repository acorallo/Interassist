using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils.InterAssist;

namespace UI.InterAssist.Modelviews
{
    [Serializable]
    public class PrestadorCasoModelView
    {
        public int IdCasoPrestador = -1;
        public int IdPrestador;
        public string InternalID = Guid.NewGuid().ToString();
        public string NombrePrestador;
        public string UbicacionPrestador;
        public string TipoAsistencia;
        public int IdTipoAsistencia;
        public string Detalles;
        public Constants.PersistOperationType Estado = Constants.PersistOperationType.Void;

        public PrestadorCasoModelView()
        {

        }

        public Entities.InterAsisst.PrestadorCaso getPrestadorCaso()
        {
            Entities.InterAsisst.PrestadorCaso result = new Entities.InterAsisst.PrestadorCaso();

            result.Prestador = Entities.InterAsisst.Prestador.Get_Shadow(this.IdPrestador);
            result.TipoServicio = Entities.InterAsisst.TipoServicio.get_Shadow(this.IdTipoAsistencia);
            result.Comentarios = this.Detalles;
            result.ID = this.IdCasoPrestador;
            result.TipoOperacion = this.Estado;
            
           

            return result;
        }

        public PrestadorCasoModelView(Entities.InterAsisst.PrestadorCaso p)
        {
            this.IdCasoPrestador = p.ID;
            this.IdPrestador = p.Prestador.ID;
            this.NombrePrestador = p.Prestador.Nombre;
            this.UbicacionPrestador = getUbicacion(p.Prestador);
            this.TipoAsistencia = p.TipoServicio.Descripcion;
            this.IdTipoAsistencia = p.TipoServicio.ID;
            this.Detalles = p.Comentarios;

        }

        public PrestadorCasoModelView(Entities.InterAsisst.Prestador p)
        {
            this.IdPrestador = p.ID;
            this.NombrePrestador = p.Nombre;
            this.UbicacionPrestador = getUbicacion(p);
        }

        private static string getUbicacion(Entities.InterAsisst.Prestador p)
        {
            return p.Domicilio + " - " + p.LocalidadNombre + " - " + p.NombreCiudad + " - " + p.ProvinciaNombre;
        }


        public static List<PrestadorCasoModelView> getList(List<Entities.InterAsisst.PrestadorCaso> ps)
        {
            List<PrestadorCasoModelView> result = new List<PrestadorCasoModelView>();

            foreach (Entities.InterAsisst.PrestadorCaso p in ps)
            {
                result.Add(new PrestadorCasoModelView(p));
                
            }

            return result;
        }

    }
}   