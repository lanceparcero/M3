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
    using System.Collections.Generic;
    
    public partial class m3_merchant_contact
    {
        public long SeqID { get; set; }
        public int merchant_id { get; set; }
        public string prefix { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string position { get; set; }
        public string office_phone_no { get; set; }
        public string mobile_phone_no { get; set; }
        public string email { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> terminate_date { get; set; }
        public Nullable<int> audit_id { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<bool> IsPrimary { get; set; }
    
        public virtual m3_merchant m3_merchant { get; set; }
    }
}