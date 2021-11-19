using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenFood.Models
{
    public class NganLuongClass
    {
        private string _paymentMethod;
        private string _bankCode;
        public NganLuongClass(string v1, string v2)
        {
            _paymentMethod = v1;
            _bankCode = v2;
        }
        public string getPaymentMethod()
        {
            return _paymentMethod;
        }
        public void setPaymentMethod(string _paymentMethod)
        {
            this._paymentMethod = _paymentMethod;
        }
        public string getBankCode()
        {
            return _bankCode;
        }
        public void setBankCode(string _bankCode)
        {
            this._bankCode = _bankCode;
        }
    }
}