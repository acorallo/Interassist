using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cognitas.Framework.Repository.Interfaces
{
    
    public interface IRepository
    {

        Dataservices Dataservice { get; }

        string UObjectID { get; }
        
        

        /// <summary>
        /// Persist de object into the repository
        /// </summary>
        /// <returns></returns>
        bool Persist(); 
        
        /// <summary>
        /// Determinate whether the object exist or not in the respository
        /// </summary>
        /// <returns>Is true when the object hasn't ever been persisted in the respository before.</returns>
        bool IsNew {get;}       
        
        /// <summary>
        /// 
        /// </summary>
        bool HasChange();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void Reload();

        /// <summary>
        /// Unike ID
        /// </summary>
        int ID { get;}

        
        DataRow ObjectToRow();
        

        
    }
}
