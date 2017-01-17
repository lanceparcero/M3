using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using GenerateSOADLL.DataAccess;

namespace GenerateSOADLL
{
    class DatabaseToExcel
    {
        public DataTable getDailySoaHeaders(DateTime? date, string merchant = "")
        {
            DataTable dtTable = new DataTable();
            DataRow drRow;
            #region SOA Headers
            dtTable.Columns.Add("merchant_id", typeof(string));
            dtTable.Columns.Add("settlement_date", typeof(string));
            dtTable.Columns.Add("registration_name", typeof(string));
            dtTable.Columns.Add("TIN", typeof(string));
            dtTable.Columns.Add("Address", typeof(string));
            dtTable.Columns.Add("City", typeof(string));
            dtTable.Columns.Add("CurrentBalance", typeof(decimal));
            dtTable.Columns.Add("TotalTransaction", typeof(decimal));
            dtTable.Columns.Add("TotalCBRF", typeof(decimal));
            dtTable.Columns.Add("TotalTransactionAdjustment", typeof(decimal));
            dtTable.Columns.Add("Others", typeof(decimal));
            dtTable.Columns.Add("LessPaid", typeof(decimal));
            dtTable.Columns.Add("BalanceCarryForward", typeof(decimal));
            dtTable.Columns.Add("TotalWithdeld", typeof(decimal));
            dtTable.Columns.Add("ContactName", typeof(string));
            dtTable.Columns.Add("ContactEmail", typeof(string));
            dtTable.Columns.Add("InternalCompanyName", typeof(string));
            dtTable.Columns.Add("Address1", typeof(string));
            dtTable.Columns.Add("Address2", typeof(string));
            dtTable.Columns.Add("Address3", typeof(string));
            dtTable.Columns.Add("taxid", typeof(string));
            dtTable.Columns.Add("businessregistionid", typeof(string));
            dtTable.Columns.Add("InternalEmail", typeof(string));
            dtTable.Columns.Add("InternalContact", typeof(string));
            #endregion
            using (M3_PROEntities myContext = new M3_PROEntities())
            {
                var myEntitySet = (from t in myContext.fn_SOADailyHeaders(date)
                                   select new
                                   {
                                       t.merchant_id,
                                       t.settlement_date,
                                       t.registration_name,
                                       t.tax_id,
                                       t.biz_address,
                                       t.biz_city,
                                       t.CurrentBalance,
                                       t.TotalTransactions,//Transaction Net Amount
                                       t.TotalCBRF,//(Chargeback/Refund)*-1
                                       t.TotalTransactionAdjustment,//Transaction Adjustment Net Amount
                                       t.Others,//Adjustment Amount
                                       t.AmountPaid,//Less Paid
                                       t.RemainingBalance,//Carry Forward
                                       t.Fraud_NetAmount,//Fraud Net Amount
                                       t.firstname,
                                       t.lastname,
                                       t.email,
                                       InternalCompany = t.Description,
                                       t.AddressLine1,
                                       t.AddressLine2,
                                       t.AddressLine3,
                                       inctaxid = t.TaxID,
                                       t.BusinessRegistrationID,
                                       internalemail = t.EmailAddress,
                                       internalcontact = t.ContactNumber
                                   });

                if (!string.IsNullOrEmpty(merchant))
                {
                    int merchant1 = int.Parse(merchant);
                    myEntitySet = myEntitySet.Where(t => t.merchant_id == merchant1 && t.settlement_date == date);
                }

                foreach (var myEntityRow in myEntitySet)
                {
                    string ContactName = myEntityRow.firstname + " " + myEntityRow.lastname;

                    drRow = dtTable.NewRow();

                    drRow["merchant_id"] = myEntityRow.merchant_id;
                    drRow["settlement_date"] = myEntityRow.settlement_date;
                    drRow["registration_name"] = myEntityRow.registration_name;
                    drRow["TIN"] = myEntityRow.tax_id;
                    drRow["Address"] = myEntityRow.biz_address;
                    drRow["City"] = myEntityRow.biz_city;
                    drRow["CurrentBalance"] = myEntityRow.CurrentBalance;
                    drRow["TotalTransaction"] = myEntityRow.TotalTransactions;
                    drRow["TotalCBRF"] = myEntityRow.TotalCBRF;
                    drRow["TotalTransactionAdjustment"] = myEntityRow.TotalTransactionAdjustment;
                    drRow["Others"] = myEntityRow.Others;
                    drRow["LessPaid"] = myEntityRow.AmountPaid;
                    drRow["BalanceCarryForward"] = myEntityRow.RemainingBalance;
                    drRow["TotalWithdeld"] = myEntityRow.Fraud_NetAmount;
                    drRow["ContactName"] = ContactName;
                    drRow["ContactEmail"] = myEntityRow.email;
                    drRow["InternalCompanyName"] = myEntityRow.InternalCompany;
                    drRow["Address1"] = myEntityRow.AddressLine1;
                    drRow["Address2"] = myEntityRow.AddressLine2;
                    drRow["Address3"] = myEntityRow.AddressLine3;
                    drRow["taxid"] = myEntityRow.inctaxid;
                    drRow["businessregistionid"] = myEntityRow.BusinessRegistrationID;
                    drRow["InternalEmail"] = myEntityRow.internalemail;
                    drRow["InternalContact"] = myEntityRow.internalcontact;

                    dtTable.Rows.Add(drRow);
                }
            }
            return dtTable;
        }

        public DataTable getDailySoaTransactions(DateTime? date, string merchant = "")
        {
            DataTable dtTable = new DataTable();
            DataRow drRow;

            dtTable.Columns.Add("transactiondate", typeof(string));
            dtTable.Columns.Add("transactionID", typeof(string));

            dtTable.Columns.Add("transactiontype", typeof(string));
            dtTable.Columns.Add("transactioncode", typeof(string));
            dtTable.Columns.Add("transactionamount", typeof(decimal));
            dtTable.Columns.Add("transactionMDR", typeof(decimal));

            dtTable.Columns.Add("transactionWHT", typeof(decimal));
            dtTable.Columns.Add("transactionNetAmount", typeof(decimal));
            dtTable.Columns.Add("country", typeof(string));
            dtTable.Columns.Add("productname", typeof(string));

            using (M3_PROEntities myContext = new M3_PROEntities())
            {
                var myEntitySet = (from t in myContext.vw_SOADailyTransaction
                                   where t.statementdate == date
                                   orderby t.transactiondate ascending
                                   select new
                                   {
                                       t.merchant_id,
                                       t.statementdate,
                                       t.transactiondate,
                                       t.transactionid,
                                       t.transactiontype,
                                       t.transactioncode,
                                       t.transactionamount,
                                       t.transactionMDR,
                                       t.transactionWHT,
                                       t.netamount,
                                       t.country,
                                       t.productname


                                   });

                if (!string.IsNullOrEmpty(merchant))
                {
                    int merchant1 = int.Parse(merchant);
                    myEntitySet = myEntitySet.Where(t => t.merchant_id == merchant1 && t.statementdate == date);
                }

                foreach (var myEntityRow in myEntitySet)
                {
                    drRow = dtTable.NewRow();

                    drRow["transactiondate"] = myEntityRow.transactiondate;
                    drRow["transactionID"] = myEntityRow.transactionid;

                    drRow["transactiontype"] = myEntityRow.transactiontype;
                    drRow["transactioncode"] = myEntityRow.transactioncode;
                    drRow["transactionamount"] = myEntityRow.transactionamount;
                    drRow["transactionMDR"] = myEntityRow.transactionMDR;

                    drRow["transactionWHT"] = myEntityRow.transactionWHT;
                    drRow["transactionNetAmount"] = myEntityRow.netamount;

                    drRow["country"] = myEntityRow.country;
                    drRow["productname"] = myEntityRow.productname;


                    dtTable.Rows.Add(drRow);
                }
            }
            return dtTable;
        }

        public DataTable getFraudDetails(DateTime? date, string merchant = "")
        {
            DataTable dtTable = new DataTable();
            DataRow drRow;


            dtTable.Columns.Add("merchant_id", typeof(string));
            dtTable.Columns.Add("transdate", typeof(string));
            dtTable.Columns.Add("txnid", typeof(string));
            dtTable.Columns.Add("auth_code_txntype", typeof(string));
            dtTable.Columns.Add("tx_amount", typeof(decimal));
            dtTable.Columns.Add("computedmdr", typeof(decimal));
            dtTable.Columns.Add("computedwht", typeof(decimal));
            dtTable.Columns.Add("paytomerchant", typeof(decimal));


            using (M3_PROEntities myContext = new M3_PROEntities())
            {
                var myEntitySet = (from t in myContext.fn_SOADailyWithheldTransactions(date)
                                   orderby t.transaction_date ascending
                                   select new
                                   {
                                       t.merchant_id,
                                       t.transaction_date,
                                       t.reconcile_tx_id,
                                       t.auth_code,
                                       t.tx_amount,
                                       t.computed_merchant_mdr_amount,
                                       t.computed_merchant_wht_amount,
                                       t.computed_pay_to_merchant_amount,
                                       t.settlement_date

                                   });

                if (!string.IsNullOrEmpty(merchant))
                {
                    int merchant1 = int.Parse(merchant);
                    myEntitySet = myEntitySet.Where(t => t.merchant_id == merchant1 && t.settlement_date == date);
                }

                foreach (var myEntityRow in myEntitySet)
                {

                    drRow = dtTable.NewRow();

                    drRow["merchant_id"] = myEntityRow.merchant_id;
                    drRow["transdate"] = myEntityRow.transaction_date.ToString();
                    drRow["txnid"] = myEntityRow.reconcile_tx_id.ToString();
                    drRow["auth_code_txntype"] = myEntityRow.auth_code.ToString();
                    drRow["tx_amount"] = myEntityRow.tx_amount;
                    drRow["computedmdr"] = myEntityRow.computed_merchant_mdr_amount;
                    drRow["computedwht"] = myEntityRow.computed_merchant_wht_amount;
                    drRow["paytomerchant"] = myEntityRow.computed_pay_to_merchant_amount;

                    dtTable.Rows.Add(drRow);
                }
            }
            return dtTable;
        }
    }
}
