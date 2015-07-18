using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssist.Classes
{
    public class SessionHelper
    {

        public const int DEFAULT_ID = -1;

        
        private const string SESSION_ID_PRESTADOR = "ss_prestador";
        private const string SESSION_ID_OPERADOR = "ss_operador";
        private const string SESSION_ID_AFILIADO = "ss_afiliado";

        private const string SESSION_ID_AFILIADO_CASO = "ss_afiliado_caso";
        private const string SESSION_ID_CASO = "ss_caso";
        private const string SESSION_PREVIEW = "ss_session_preview";
        private const string SESSION_CURRENT_VIEW = "ss_session_current";

        private const string SESSION_ID_UPLOAD = "ss_upload";

        #region Propiedades

        public static int ID_UPLOAD
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_ID_UPLOAD] == null)
                    HttpContext.Current.Session.Add(SESSION_ID_UPLOAD, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_UPLOAD].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_ID_UPLOAD, value);
            }
        }

        public static int ID_PRESTADOR
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_ID_PRESTADOR] == null)
                    HttpContext.Current.Session.Add(SESSION_ID_PRESTADOR, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_PRESTADOR].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_ID_PRESTADOR, value);
            }
        }

        public static int ID_CASO_AFILIADO
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_ID_AFILIADO_CASO] == null)
                    HttpContext.Current.Session.Add(SESSION_ID_AFILIADO_CASO, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_AFILIADO_CASO].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_ID_AFILIADO_CASO, value);
            }
        }

        public static int ID_CASO
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_ID_CASO] == null)
                    HttpContext.Current.Session.Add(SESSION_ID_CASO, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_CASO].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_ID_CASO, value);
            }
        }

        public static int ID_OPERADOR
        {
            get
            {
                if(HttpContext.Current.Session[SESSION_ID_OPERADOR]==null)
                    HttpContext.Current.Session.Add (SESSION_ID_OPERADOR, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_OPERADOR].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add (SESSION_ID_OPERADOR, value);
            }
        }

        public static int ID_AFILIADO
        {
            get{
                if(HttpContext.Current.Session[SESSION_ID_AFILIADO]==null)
                    HttpContext.Current.Session.Add (SESSION_ID_AFILIADO, DEFAULT_ID);
                return Int32.Parse(HttpContext.Current.Session[SESSION_ID_AFILIADO].ToString());

            }
            set
            {
                HttpContext.Current.Session.Add (SESSION_ID_AFILIADO, value);
            }
        }

        public static string PREVIEW
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_PREVIEW] == null)
                    HttpContext.Current.Session.Add(SESSION_PREVIEW, string.Empty);
                return HttpContext.Current.Session[SESSION_PREVIEW].ToString();

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_PREVIEW, value);
            }
        }

        public static string CURRENT_VIEW
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_CURRENT_VIEW] == null)
                    HttpContext.Current.Session.Add(SESSION_CURRENT_VIEW, string.Empty);
                return HttpContext.Current.Session[SESSION_CURRENT_VIEW].ToString();

            }
            set
            {
                HttpContext.Current.Session.Add(SESSION_CURRENT_VIEW, value);
            }
        }


        #endregion Propiedades
    }
}