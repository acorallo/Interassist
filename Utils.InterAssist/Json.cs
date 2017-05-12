using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Utils.InterAssist
{
    public class Json
    {
        #region Constants

        public static readonly string JSON_META_DATA_SCOPE = "metadata";
        public static readonly string JSON_DATA_SCOPE = "data";

        #endregion Constants

        #region Methods

        private string RenderRowByType(object r, Type type)
        {
            string result = string.Empty;

            try
            {
                switch (type.Name)
                {
                    case "String":
                        result = r.ToString().Trim();
                        break;
                    case "Decimal":
                        result = String.Format((new System.Globalization.CultureInfo("en-US")), "{0:0.00}", r);
                        break;
                    default:
                        result = r.ToString().Trim();
                        break;
                }
            }
            catch
            {
                result = r.ToString().Trim();
            }


            return result;
        }

        private string DataRowToJson(DataRow row, DataColumnCollection dataColumns)
        {
            string result = string.Empty;

            StringBuilder st = new StringBuilder();
            st.Append("{");

            for (int i = 0; i < dataColumns.Count; i++)
            {
                st.Append("\"");
                st.Append(dataColumns[i].ColumnName.Trim().ToLower());
                st.Append("\"");
                st.Append(":");
                st.Append(" ");
                st.Append("\"");
                st.Append(RenderRowByType(row[i], dataColumns[i].DataType));
                st.Append("\"");
                st.Append(",");


            }


            result = st.ToString().TrimEnd(',') + "}";

            return result;
        }

        public string RenderMetadata(DataColumnCollection dataColumns, string MetaDataName)
        {
            string result = String.Empty;

            var jsonString = new StringBuilder();

            jsonString.Append("\"");
            jsonString.Append(MetaDataName);
            jsonString.Append("\"");
            jsonString.Append(":");
            jsonString.Append(" ");
            jsonString.Append("[");
            jsonString.Append("{");


            foreach (DataColumn column in dataColumns)
            {
                jsonString.Append("\"");
                jsonString.Append(column.ColumnName.ToLower());
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append("\"");
                jsonString.Append(column.DataType.Name.ToLower());
                jsonString.Append("\"");
                jsonString.Append(",");

            }

            result = jsonString.ToString().TrimEnd(',') + "}" + "]";

            return result;
        }

        public string DataTableToJson(DataTable table, string DataName, string MetaDataName)
        {

            string result = string.Empty;
            if (table != null)
            {
                var jsonString = new StringBuilder();

                jsonString.Append("{");
                jsonString.Append(RenderMetadata(table.Columns, MetaDataName));
                jsonString.Append(",");
                jsonString.Append("\"");
                jsonString.Append(DataName);
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append(" ");
                jsonString.Append("[");


                foreach (DataRow r in table.Rows)
                {
                    jsonString.Append(DataRowToJson(r, table.Columns));
                    jsonString.Append(",");
                }

                result = jsonString.ToString().TrimEnd(',') + "]" + "}";

            }
            else
            {
                result = "Null";
            }

            return result;
        }

        public string DataTableToJson(DataTable table)
        {
            return DataTableToJson(table, JSON_DATA_SCOPE, JSON_META_DATA_SCOPE);
        }

        #endregion Methods
    }
}
