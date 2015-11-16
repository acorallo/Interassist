using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.InterAssist.Modelviews;
using Entities.InterAsisst;
using Utils.InterAssist;


namespace UI.InterAssist.Views
{
    public partial class services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region WebMethods

        [System.Web.Services.WebMethod]
        public static List<OptionComboModelView> GetPaises()
        {
            List<OptionComboModelView> result = new List<OptionComboModelView>();
            List<Pais> listPais = Pais.List();

            result = OptionComboModelView.getAllOptions<Pais>(listPais, (o, i) => { o.id = i.IdPais.ToString(); 
                                                                                    o.value = i.Nombre; 
                                                                                    });

            return result;

        }

        [System.Web.Services.WebMethod]
        public static List<OptionComboModelView> GetProvincias(int key)
        {
            List<OptionComboModelView> result = new List<OptionComboModelView>();
            List<Provincia> lisProvincia = Provincia.List(key);

            result = OptionComboModelView.getAllOptions<Provincia>(lisProvincia, (o, i) =>
            {
                o.id = i.Id.ToString();
                o.value = i.Nombre;
            });

            return result;

        }
        
        [System.Web.Services.WebMethod]
        public static List<PrestadorModelView> ListPrestadores (int idPais, int idProvincia, string ciudad, string nombre)
        {
            List<PrestadorModelView> resultList = new List<PrestadorModelView>();

            FiltroPrestador filtro = new FiltroPrestador();
            filtro.IdPais = idPais;
            filtro.IdProvincia = idProvincia;
            filtro.Localidad = ciudad.Trim();
            filtro.Nombre = nombre.Trim();

            List<Entities.InterAsisst.Prestador> lPrestadores = Entities.InterAsisst.Prestador.List(filtro);
            foreach (Entities.InterAsisst.Prestador p in lPrestadores)
            {
                PrestadorModelView pw = new PrestadorModelView();
                pw.Id = p.ID;
                pw.Localidad = p.LocalidadNombre;
                pw.Nombre = p.Nombre;
                pw.Pais = p.NombrePais;
                pw.Provincia = p.ProvinciaNombre;
                pw.Telefono = p.Telefono1;
                resultList.Add(pw);

            }

            return resultList;
        }


        [System.Web.Services.WebMethod]
        public static Modelviews.PrestadorModelView getPrestadorWM(int idPrestador)
        {
            Modelviews.PrestadorModelView result = CasoCrud.getPrestador(idPrestador);
            return result;
        }
        
        #endregion WebMethods

    }
}