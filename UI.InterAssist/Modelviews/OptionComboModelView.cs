using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssist.Modelviews
{

    public delegate void MapDel<T>(OptionComboModelView O, T Item);

    public class OptionComboModelView : Modelview
    {

        public string id { get; set; }
        public string value { get; set; }

        public static List<OptionComboModelView> getAllOptions<T> (List<T> listObjects, MapDel<T> mapFunction)
        {
            List<OptionComboModelView> resultList = new List<OptionComboModelView>();

            foreach (T t in listObjects)
            {
                OptionComboModelView o = new OptionComboModelView();
                mapFunction.Invoke(o, t);
                resultList.Add(o);
            }

            return resultList;
        }

        

    }
}