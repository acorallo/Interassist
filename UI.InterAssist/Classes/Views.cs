using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Cognitas.Framework.Repository;

namespace UI.InterAssist.Classes
{
    public abstract class Views : Cognitas.Framework.UserInterface.PageBase
    {
        
        // Vistas del sistema
        public const string OPERADOR_MODIF_VIEW = "OperadorCrud.aspx";
        public const string OPERADOR_VIEW = "Operadores.aspx";
        public const string AFILIADO_VIEW = "Afiliados.aspx";
        public const string AFILIADO_MODIF_VIEW = "AfiliadoCrud.aspx";
        public const string CASO_MODIF = "CasoCrud.aspx";
        public const string CASO_VIEW = "Casos.aspx";
        public const string LOGIN_VIEW = "Login.aspx";
        public const string USER_VIEW = "Usuario.aspx";
        public const string PRESTADOR_MODIF_VIEW = "PrestadorCrud.aspx";
        public const string PRESTADOR_VIEW = "Prestador.aspx";
        public const string UPLOAD_VIEW = "Uploads.aspx";
        public const string UPLOAD_ERRORS_VIEW = "UpLoadErrors.aspx";
        public const string AFILIADOS_UNSYNC = "AfiliadosUnsync.aspx";
        public const string REPORTES_VIEW = "Report.aspx";

        private const string SESSION_OPEDADOR = "sessionOperador";
        private const string PREVIOS_VIEW = "SessionPreview";
        protected const string VIEW_STATE_FILTRO = "wsFiltoListado";

        public const string COMBO_ELIJA_OPCION = "-1";
        public const int PAGE_SIZE = 20;
        public const int CACHE_OBJECTS = 240;// En minutos
        
        protected abstract bool ReqLogin { get; }
        protected abstract bool ReqAdmin { get; }

        public abstract string ViewName { get; }
        

        public abstract string Seccion { get; }

        
        
        public virtual Entities.InterAsisst.Operador SessionOperador
        {
            get
            {
                Entities.InterAsisst.Operador resultOperador = null;

                if (this.Session[SESSION_OPEDADOR] != null)
                    resultOperador = (Entities.InterAsisst.Operador)this.Session[SESSION_OPEDADOR];

                return resultOperador;
            }
            set
            {
                this.Session.Add(SESSION_OPEDADOR, value);
            }
        }

        public bool IsLoginUser
        {
            get
            {
                return this.SessionOperador != null;
            }
        }

        public virtual string Titulo
        {
            get
            {
                return Resource.TXT_DEFAULT_PAGE_TITLE;
            }

        }

        public void Page_Load(object sender, EventArgs e)
        {

            this.Page.Title = this.Titulo;
            base.Page_Load(sender, e);
            this.ValidarCredenciales();
            
            if (!this.IsPostBack)
            {
                Classes.SessionHelper.CURRENT_VIEW = this.ViewName;
                this.AssigntText();
            }
        }

        private void AssigntText()
        {
            
        }

        public void ValidarCredenciales()
        {
            
            if (this.ReqLogin && this.SessionOperador == null)
                Response.Redirect(LOGIN_VIEW);

            if(this.ReqAdmin&&(this.SessionOperador==null || !this.SessionOperador.Admin))
                throw new Exception("El usuario no es administrador");
         
        }

        public void GoBackView()
        {
            if (Classes.SessionHelper.PREVIEW != string.Empty)
            {
                Classes.SessionHelper.CURRENT_VIEW = Classes.SessionHelper.PREVIEW;
                Response.Redirect(Classes.SessionHelper.CURRENT_VIEW);
            }
        }

        public void goView(string viewName)
        {
            Classes.SessionHelper.PREVIEW = Classes.SessionHelper.CURRENT_VIEW;
            this.Response.Redirect(viewName);
        }

        public static void AgergarElijaOpcion(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem(Resource.TXT_COMBO_ELIJA_OPCION, COMBO_ELIJA_OPCION));
        }

        public static void AgragarOpcionBlank(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem(string.Empty, COMBO_ELIJA_OPCION));
        }

        public static void SendInputTypeHidden(Literal cLiteral, string id, string value)
        {
            string control = "<input type=\"hidden\" id=\""+id+"\" value = \""+value+"\">";

            cLiteral.Text = control;
        }

        public bool IsGroupValid(string groupName)
        {
            bool result = false;

            foreach (System.Web.UI.IValidator validator in this.GetValidators(groupName))
            {
                if (!validator.IsValid)
                {
                    result = false;
                    break;
                }

                result = true; 
            }

            return result;
        }

        public void SendInputHidden(Literal lit, string id, string value)
        {
            
            lit.Text = string.Format(@"<input name=""{0}"" id=""{0}"" type=""hidden"" value=""{1}""/>", id, value);
        }

    }
}