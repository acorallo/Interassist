using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;


namespace Cognitas.Framework.UserInterface 
{
    public class CruEntityUserControl : UserControl
    {

        #region Constants


        private const int DEFAULT_ENTITY_ID = -1;
        private const string STRING_SESSION_ENTITY_ID = "ssEntityID";
        private const string STRING_SESSION_OBJECTHAS = "ssObjecthast";

        #endregion Constants

        #region Enumerators

        #endregion Enumerators

        #region Constructors
        #endregion Constructors

        #region Members

        #endregion Members

        #region Properties


        private string SESSION_ENTITY_ID
        {
            get
            {
                return this.ToString() + STRING_SESSION_ENTITY_ID;
            }
        }

        public int EntityID
        {
            get
            {
                if (Context.Session[SESSION_ENTITY_ID] == null)
                    Context.Session.Add(SESSION_ENTITY_ID, DEFAULT_ENTITY_ID);
                return Int32.Parse(Context.Session[SESSION_ENTITY_ID].ToString());
            }
            set
            {
                Context.Session.Add(SESSION_ENTITY_ID, value);
            }
        }

        public bool IsNewEntity
        {
            get
            {
                return (this.EntityID == DEFAULT_ENTITY_ID);
            }
        }

        public string ObjectHash
        {
            get
            {
                if (Context.Session[STRING_SESSION_OBJECTHAS] == null)
                    Context.Session.Add(STRING_SESSION_OBJECTHAS, string.Empty);
                return Context.Session[STRING_SESSION_OBJECTHAS].ToString();
            }
            set
            {
                Context.Session.Add(STRING_SESSION_OBJECTHAS, value);
            }
        }

        
    
        #endregion Properties

        #region Methods

        public void ResetValues()
        {
            this.EntityID = DEFAULT_ENTITY_ID;
            this.ObjectHash = string.Empty;
        }

        #endregion Methods
    }
}
