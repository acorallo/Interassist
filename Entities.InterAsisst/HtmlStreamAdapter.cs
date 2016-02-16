using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Entities.InterAsisst
{
    public class HtmlStreamAdapter
    {


        private HttpResponse _response;

        public HtmlStreamAdapter(String FileName, HttpResponse r)
        {
            this._response = r;

            this._response.Clear();

            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=test.csv"));
            this._response.ContentType = "text/csv";
            this._response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
            
           
 
        }

        public void WriteLine(string line)
        {
            this._response.Write(line + "\n");
        }
    }
}
