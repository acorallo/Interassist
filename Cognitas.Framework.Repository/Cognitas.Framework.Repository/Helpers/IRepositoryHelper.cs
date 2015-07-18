using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository.Exceptions;


namespace Cognitas.Framework.Repository.Helpers
{
    [Serializable]
    public abstract class IRepositoryHelper
    {

        #region Constants

        public const int NO_ACTIVO = 0;
        public const int ACTIVO = 1;
        public const int NULL_ID = -1;
        

        #endregion Constants

        #region Members

        protected string _UObjectID = string.Empty;
        protected Dataservices _dtService = null;
        protected int _id = NULL_ID;

        #endregion Members

        #region Properties


        public Dataservices Dataservice
        {
            get
            {
                if(this._dtService==null)
                    this._dtService = this.getDataService();

                return this._dtService;

            }
            
        }

        public string UObjectID
        {
            get
            {
                return this._UObjectID;
            }
        }

        public abstract Dataservices getDataService();
        public abstract DataRow ObjectToRow();

        public bool IsNew
        {
            get
            {
                return this._id == NULL_ID;
            }
        }

        public int ID
        {
            get { return this._id; }
        }


        public virtual bool Persist()
        {
            bool result = false;

            try
            {
                
                if (this.IsNew)
                {
                    this._UObjectID = Guid.NewGuid().ToString();
                    DataRow dr = this.ObjectToRow();
                    this._id = this.Dataservice.Create(dr);
                    result = true;
                }
                else
                {
                    DataRow dr = this.ObjectToRow();
                    result = this.Dataservice.Update(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return result;
        }

        #endregion Properties

        #region Metodos

        

        #endregion Metodos

    }
}
