//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenerateSOADLL.DataAccess
{
    using System;
    
    public partial class fn_SOADailyWithheldTransactions_Result
    {
        public int settlement_batch_id { get; set; }
        public Nullable<int> merchant_id { get; set; }
        public Nullable<System.DateTime> transaction_date { get; set; }
        public string reconcile_tx_id { get; set; }
        public string auth_code { get; set; }
        public Nullable<decimal> tx_amount { get; set; }
        public Nullable<decimal> computed_merchant_mdr_amount { get; set; }
        public Nullable<decimal> computed_merchant_wht_amount { get; set; }
        public Nullable<decimal> computed_pay_to_merchant_amount { get; set; }
        public System.DateTime settlement_date { get; set; }
    }
}