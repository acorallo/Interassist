using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Usercontrols
{
    public partial class DecimalControl : System.Web.UI.UserControl
    {

        #region Constantes

        private const string VW_INTEGER = "_ws_digit";
        private const string WS_DECIMAL = "_ws_decimal";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        

        #endregion Constructores

        #region Miembros

        public int IntegerDigits
        {
            get
            {
                if (this.ViewState[VW_INTEGER] == null)
                    this.ViewState.Add(VW_INTEGER, 5);
                return Int32.Parse(this.ViewState[VW_INTEGER].ToString());
            }
            set
            {
                this.ViewState.Add(VW_INTEGER, value);
            }
        }

        public int DecimalDigits
        {
            get
            {
                if (this.ViewState[WS_DECIMAL] == null)
                    this.ViewState.Add(WS_DECIMAL, 2);
                return Int32.Parse(this.ViewState[WS_DECIMAL].ToString());
            }
            set
            {
                this.ViewState.Add(WS_DECIMAL, value);
            }
        }
    


        #endregion Miembros

        #region Propiedades

        public float? Value
        {
            get
            {
                float? result = null;
               
                if(this.txtInteger.Text!=string.Empty)
                {
                    result = float.Parse(this.txtInteger.Text + "." + this.txtDecimal.Text, System.Globalization.CultureInfo.InvariantCulture);   
                }

                return result;
            }
            set
            {
                if(value!=null)
                {
                    this.txtInteger.Text = ((int)value).ToString();
                    string strDecimal = FillZeros(((double)(value - (int)value) * Math.Pow(10, this.DecimalDigits)).ToString(), this.DecimalDigits);

                    if (strDecimal.Length <= this.DecimalDigits)
                        this.txtDecimal.Text = strDecimal;
                    else
                        this.txtDecimal.Text = strDecimal.Substring(0, this.DecimalDigits);
                        

                }

            }

        }

        public string FillZeros(string valor, int MaxLengt)
        {
            if (valor.Length < MaxLengt)
            {
                return FillZeros(valor + "0", MaxLengt);
            }
            else
            {
                return valor;
            }

            
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicializaComponentes();
                SetClientScript();
            }
        }

        private void AssignTextToControls()
        {
            this.lblDecimaSeparator.Text = Resource.DECIMAL_SEPARATOR;
        }

        private void InicializaComponentes()
        {
            this.txtInteger.MaxLength = this.IntegerDigits;
            this.txtDecimal.MaxLength = this.DecimalDigits;

            string functionLeaveInteger = "javascript:_leaveIntControl(" + this.txtInteger.ClientID + "," + this.txtDecimal.ClientID + ")";
            string functionOnKeyPressInteger = "javascript:_onKeyPressNumericControl(" +  this.txtDecimal.ClientID + ")";
            string functionOnKeyPressDecimal = "javascript:_onKeyPressNumericControl(null)";
            string functionLeaveDecimal = "javascript:_leaveDecControl("+this.txtInteger.ClientID+","+this.txtDecimal.ClientID+","+this.DecimalDigits+")";
            string functionGetDecimal = "javascript:_getDecimal(this)";

            this.txtInteger.Attributes.Add("onBlur", functionLeaveInteger);
            this.txtInteger.Attributes.Add("onkeypress", functionOnKeyPressInteger);
            this.txtDecimal.Attributes.Add("onkeypress", functionOnKeyPressDecimal);
            this.txtDecimal.Attributes.Add("onBlur", functionLeaveDecimal);
            this.txtDecimal.Attributes.Add("onFocus", functionGetDecimal);
        }


        private void SetClientScript()
        {

            string strfunction_GetValue;
            string strfunction_ResetValue;

            ClientScriptManager cs = this.Page.ClientScript;

            strfunction_GetValue = "function " + this.ClientID.ToString() + "_getValue() { \n";
            strfunction_GetValue += "  var entero = $('#" + this.txtInteger.ClientID.ToString() + "').val(); \n";
            strfunction_GetValue += "  var decimal = $('#" + this.txtDecimal.ClientID.ToString() + "').val(); \n";
            strfunction_GetValue += "  var result = '';\n";
            strfunction_GetValue += "  if(entero != '' || decimal != '')\n";
            strfunction_GetValue += "  {\n";
            strfunction_GetValue += "      result = entero + '.' + decimal;\n";
            strfunction_GetValue += "  }\n";
            strfunction_GetValue += "  return result;\n";
            strfunction_GetValue += " }\n";



            strfunction_ResetValue = "function " + this.ClientID.ToString() + "_resetValue() { \n";
            strfunction_ResetValue += "  $('#" + this.txtInteger.ClientID.ToString() + "').val(''); \n";
            strfunction_ResetValue += "  $('#" + this.txtDecimal.ClientID.ToString() + "').val(''); \n";

            strfunction_ResetValue += " }\n";


            cs.RegisterClientScriptBlock(this.GetType(), this.ClientID.ToString() + "_getValue", strfunction_GetValue, true);
            cs.RegisterClientScriptBlock(this.GetType(), this.ClientID.ToString() + "_resetValue", strfunction_ResetValue, true);

            
                  
        }

        #endregion Metodos



    }
}