using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cognitas.Framework.UserInterface
{
    public abstract class PageBase : System.Web.UI.Page
    {

        #region Constants

        private const string ID_INPUT_HIDDEN_ENTITY = "EntityIDHidden";
        private const string ID_INPUT_HIDDEN_HASHOBJECT = "HashObject";

        public const int DEFAULT_ID = -1;


        #endregion Constants

        #region Properties

        public int EntityID
        {
            get
            {
                if (this.ViewState[ID_INPUT_HIDDEN_ENTITY] == null)
                    this.ViewState.Add(ID_INPUT_HIDDEN_ENTITY, DEFAULT_ID);
                return Int32.Parse(this.ViewState[ID_INPUT_HIDDEN_ENTITY].ToString());
            }
            set
            {
                this.ViewState.Add(ID_INPUT_HIDDEN_ENTITY, value);
            }
            
        }

        public bool IsNew
        {
            get
            {
                return this.EntityID == DEFAULT_ID;
            }
        }

        public string ObjectHash
        {
            get
            {
                if (this.ViewState[ID_INPUT_HIDDEN_HASHOBJECT] == null)
                    this.ViewState.Add(ID_INPUT_HIDDEN_HASHOBJECT, string.Empty);
                return this.ViewState[ID_INPUT_HIDDEN_HASHOBJECT].ToString();
            }
            set
            {
                this.ViewState.Add(ID_INPUT_HIDDEN_HASHOBJECT, value);
            }
        }
            
            

        #endregion Properies

        

        #region Methods

        public void Page_Load(object sender, EventArgs e)
        {
            
            if(!this.IsPostBack)
            {

                this.InitPageBase();

            }
        }

        private void InitPageBase()
        {
            
        }
        #endregion Methods
    }
}
