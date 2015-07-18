using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository
{
    [Serializable]
    public abstract class Filter
    {

        #region Constants

        public const int NULL_ID = -1;

        #endregion Constants

        #region Members

        protected long _startRow = 1;
        protected long _pageSize = -1;
        protected long _filtredRowsQtty = -1;
        protected bool _isPaged = false;
        private string _orderBY = string.Empty;

        #endregion Members

        #region Properties

        public long StartRow
        {
            get { return _startRow; }
            set { _startRow = value; }
        }

        public long PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public long FiltredRowsQtty
        {
            get { return _filtredRowsQtty; }
            set { _filtredRowsQtty = value; }
        }

        public bool IsPaged
        {
            get { return _isPaged; }
            set { _isPaged = value; }
        }

        public string OrderBY
        {
            get { return _orderBY; }
            set { _orderBY = value; }
        }

        #endregion Properties

        #region Metodos

        public void Reset()
        {
            this._startRow = 1;
            this._pageSize = -1;
            this._filtredRowsQtty = -1;
            this._isPaged = false;
            this._orderBY = string.Empty;
            this.ResetElements();
        }

        protected abstract void ResetElements();

        #endregion Metodos
    }

}
