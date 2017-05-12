using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterAssistMVC.Models;

namespace InterAssistMVC.Helper
{
    public class Html
    {
        public static MvcHtmlString MenuBootstap(Models.Menu m)
        {
            MvcHtmlString result = null;
            string parcialResult = string.Empty;

            foreach (MenuItem i in m.Items)
            {
                parcialResult = parcialResult + CreateMenuItem(i, 0);
            }


            result = new MvcHtmlString(parcialResult);

            return result;
          
        }

        private static string CreateMenuItem(MenuItem m, int level)
        {
            string result = string.Empty;

            TagBuilder LIbuilder = new TagBuilder("li");


            string innerA = String.Empty;

            if (m.BootstrapIcon != string.Empty)
                innerA = getITag(string.Empty, m.BootstrapIcon) + " " + m.Text;
            else
                innerA = m.Text;

            string innerLI = string.Empty;

            if (m.Item!=null && m.Item.Count>0)
            {

                innerA = innerA + getSpan(string.Empty, "fa arrow");

                innerLI = getATag(innerA, m.Action);

                string innerUL = string.Empty;
                
                foreach(MenuItem innetM in m.Item)
                {
                    innerUL = innerUL + CreateMenuItem(innetM, level + 1);
                }

                innerLI = innerLI + getULTag(innerUL, getClassByLevel(level + 1));
            }
            else
            {
                innerLI = getATag(innerA, m.Action);
            }

            LIbuilder.InnerHtml = innerLI;
                        
            result = LIbuilder.ToString(TagRenderMode.Normal);

            return result;
        }

        private static string getATag(string innerHtml, string Href)
        {
            var Abuilder = new TagBuilder("a");
            
            if(Href!=String.Empty)
            {
                Abuilder.MergeAttribute("href", Href);
            }


            Abuilder.InnerHtml = innerHtml;

            return Abuilder.ToString(TagRenderMode.Normal);
            
                        
        }

        private static string getITag(string innerHtml, string CssClass)
        {
            var Ibuilder = new TagBuilder("i");

            Ibuilder.InnerHtml = innerHtml;
            if(CssClass!=String.Empty)
            {
                Ibuilder.MergeAttribute("class", CssClass);
            }

            return Ibuilder.ToString(TagRenderMode.Normal);
        }
        
        private static string getULTag(string innerHtml, string CssClass)
        {
            var Ubuilder = new TagBuilder("ul");
            
            if(CssClass!=string.Empty)
            {
                Ubuilder.MergeAttribute("class", CssClass);
            }

            Ubuilder.InnerHtml = innerHtml;

            return Ubuilder.ToString(TagRenderMode.Normal);

        }

        private static string getSpan(string innerHtml, string CssClass)
        {
            var SpanBuilder = new TagBuilder("span");

            if (CssClass != string.Empty)
            {
                SpanBuilder.MergeAttribute("class", CssClass);
            }

            SpanBuilder.InnerHtml = innerHtml;
            

            return SpanBuilder.ToString(TagRenderMode.Normal);
        }

        private static string getClassByLevel(int level)
        {
            string result = string.Empty;


            if(level == 1)
            {
                result = "nav nav-second-level";
            }

            return result;
        }
        
    }
}