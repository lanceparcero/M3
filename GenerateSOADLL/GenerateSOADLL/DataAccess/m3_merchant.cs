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
    
    public partial class m3_merchant
    {
        public m3_merchant()
        {
            this.m3_EmailSender = new HashSet<m3_EmailSender>();
        }
    
        public int merchant_id { get; set; }
        public string ghl_merchant_id { get; set; }
        public string merchant_status { get; set; }
        public string merchant_short_name { get; set; }
        public string registration_id { get; set; }
        public string registration_name { get; set; }
        public Nullable<System.DateTime> registration_date { get; set; }
        public string trading_name { get; set; }
        public string merchant_category_code { get; set; }
        public string tax_id { get; set; }
        public string biz_address1 { get; set; }
        public string biz_address2 { get; set; }
        public string biz_address3 { get; set; }
        public string biz_city { get; set; }
        public string biz_state { get; set; }
        public string biz_zip { get; set; }
        public string biz_country { get; set; }
        public string mail_address_as_biz { get; set; }
        public string mail_address1 { get; set; }
        public string mail_address2 { get; set; }
        public string mail_address3 { get; set; }
        public string mail_city { get; set; }
        public string mail_state { get; set; }
        public string mail_zip { get; set; }
        public string mail_country { get; set; }
        public string sales_code { get; set; }
        public string sales_geo_distribution { get; set; }
        public Nullable<decimal> max_tx_amount { get; set; }
        public Nullable<decimal> max_expected_weekly_sales { get; set; }
        public Nullable<int> account_bank { get; set; }
        public string account_bank_branch_name { get; set; }
        public string account_no { get; set; }
        public string account_name { get; set; }
        public string payment_method { get; set; }
        public string update_status { get; set; }
        public string update_description { get; set; }
        public Nullable<int> update_by_user_id { get; set; }
        public string update_by_username { get; set; }
        public Nullable<System.DateTime> update_by_date { get; set; }
        public Nullable<System.DateTime> terminate_date { get; set; }
        public int audit_id { get; set; }
        public Nullable<int> approve_by_user_id { get; set; }
        public string approve_by_username { get; set; }
        public Nullable<System.DateTime> approve_by_date { get; set; }
        public Nullable<int> approve_id { get; set; }
        public string actual_flag { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<int> CorporateID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<byte> MerchantAccountType { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<int> TemplateTMSID { get; set; }
        public string StoreCode { get; set; }
        public Nullable<int> AcquirerID { get; set; }
        public Nullable<bool> InitialInstallation { get; set; }
        public string BranchID { get; set; }
        public string ZuelligCode { get; set; }
        public string PfizerCode { get; set; }
        public Nullable<byte> BrandID { get; set; }
        public Nullable<byte> VendorID { get; set; }
        public Nullable<int> MSE { get; set; }
        public Nullable<int> MSO { get; set; }
        public Nullable<int> ReferredBy { get; set; }
        public Nullable<decimal> MDR { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> MASE { get; set; }
        public Nullable<int> ISO { get; set; }
        public string ISA { get; set; }
        public Nullable<byte> RentalType { get; set; }
        public Nullable<int> MerchantCategory { get; set; }
        public string ADAReferenceNo { get; set; }
        public Nullable<byte> ApplicationType { get; set; }
        public string BankAccount { get; set; }
        public Nullable<bool> BankClarif { get; set; }
        public Nullable<byte> BankReferral { get; set; }
        public Nullable<byte> BankStatus { get; set; }
        public string BlitzName { get; set; }
        public Nullable<byte> BusinessType { get; set; }
        public Nullable<bool> isFranchisee { get; set; }
        public Nullable<byte> ContractStatus { get; set; }
        public Nullable<byte> ContractTerm { get; set; }
        public Nullable<System.DateTime> DateAdminClarif { get; set; }
        public Nullable<System.DateTime> DateBankApproval { get; set; }
        public Nullable<System.DateTime> DateBankClarif { get; set; }
        public Nullable<System.DateTime> DateBankSubmission { get; set; }
        public Nullable<System.DateTime> DateCompletedDocs { get; set; }
        public string File201No { get; set; }
        public Nullable<System.DateTime> MSOSubmissionDate { get; set; }
        public Nullable<System.DateTime> ReleaseDateOrientationKit { get; set; }
        public Nullable<System.DateTime> ReturnDateOrientationKit { get; set; }
        public Nullable<bool> SalesBlitz { get; set; }
        public Nullable<byte> SchemeType { get; set; }
        public Nullable<System.DateTime> DateDeclined { get; set; }
        public Nullable<System.DateTime> DateCallOutJointCall { get; set; }
        public string AMPGHLReferralCode { get; set; }
        public string TypeOfCallReferral { get; set; }
        public string PersonInCharge { get; set; }
        public string DecisionMaker { get; set; }
        public Nullable<System.DateTime> AMPApprovalDate { get; set; }
        public Nullable<decimal> ApprovedLoanAmount { get; set; }
        public Nullable<long> RegistrationID { get; set; }
        public Nullable<int> ReferredByMSE { get; set; }
        public Nullable<int> ReferredByMSO { get; set; }
        public Nullable<int> TeleSales { get; set; }
        public Nullable<System.DateTime> ContractTerminationDate { get; set; }
        public string Coordinates { get; set; }
        public Nullable<byte> DocumentScheme { get; set; }
        public Nullable<System.DateTime> MSESubmissionDate { get; set; }
        public Nullable<int> MSPRentalCutOff { get; set; }
        public Nullable<int> MSPQuotaCutOff { get; set; }
        public Nullable<int> MSPRentalBilling { get; set; }
        public Nullable<int> MSPQuotaBilling { get; set; }
        public int merchant_status_id { get; set; }
        public Nullable<int> CreditTerms { get; set; }
        public int InternalCompanyID { get; set; }
        public Nullable<bool> AutosendInvoice { get; set; }
        public Nullable<bool> AutosendReceipt { get; set; }
        public Nullable<decimal> ADAMaxCap { get; set; }
        public Nullable<byte> ADAFrequency { get; set; }
        public Nullable<int> CollectionBankID { get; set; }
        public string BankFindingsRemarks { get; set; }
        public string CollectionBankAccount { get; set; }
        public Nullable<decimal> CollectionBankADAFee { get; set; }
        public Nullable<int> ADABankID { get; set; }
        public Nullable<byte> ADAStatus { get; set; }
        public string ADAmerchantbankcode { get; set; }
        public Nullable<bool> ADAEnabled { get; set; }
        public Nullable<bool> AutosendCreditNote { get; set; }
        public Nullable<bool> HighRiskIndustry { get; set; }
        public string RiskLevelClassification { get; set; }
        public Nullable<byte> SettlementFrequency { get; set; }
        public string SettlementFrequencyValue1 { get; set; }
        public Nullable<System.DateTime> DateMerchantSigned { get; set; }
        public string GIRO_merchantbankcode { get; set; }
        public string GIRO_bankcode { get; set; }
    
        public virtual ICollection<m3_EmailSender> m3_EmailSender { get; set; }
    }
}
