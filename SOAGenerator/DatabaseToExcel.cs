using SOAGenerator.DataAccess;
using System;
using System.Data;
using System.Linq;

namespace SOAGenerator
{
    class DatabaseToExcel
    {
        //public DataTable getDate_Merchant(string merchant, DateTime? date)
        //{
        //    int merchant1 = int.Parse(merchant);


        //    DataTable dtTable = new DataTable();
        //    DataRow drRow;


        //    dtTable.Columns.Add("merchant_id", typeof(string));


        //    dtTable.Columns.Add("merchantname", typeof(string));
        //    //dtTable.Columns.Add("contactperson", typeof(string));
        //    dtTable.Columns.Add("TIN", typeof(string));
        //    dtTable.Columns.Add("address", typeof(string));
        //    dtTable.Columns.Add("city", typeof(string));
        //    //dtTable.Columns.Add("emailcontact", typeof(string));

        //    dtTable.Columns.Add("settlement_date", typeof(string));
        //    dtTable.Columns.Add("tx_amount", typeof(decimal));
        //    dtTable.Columns.Add("computedmdr", typeof(decimal));
        //    dtTable.Columns.Add("computedwht", typeof(decimal));
        //    dtTable.Columns.Add("transdate", typeof(string));
        //    dtTable.Columns.Add("paytomerchant", typeof(decimal));
        //    dtTable.Columns.Add("stat", typeof(string));
        //    //dtTable.Columns.Add("BF", typeof(decimal));
        //    //dtTable.Columns.Add("CF", typeof(decimal));
        //    //dtTable.Columns.Add("transactiontotalamount", typeof(decimal));

        //    using (M3_DEVEntities myContext = new M3_DEVEntities())
        //    {
        //        var myEntitySet = (from t in myContext.tpa_settlementtransaction
        //                           join u in myContext.tpa_settlement_batch on t.settlement_batch_id equals u.settlement_batch_id
        //                           //join setcut in myContext.bil_SettlementCutOff on t.merchant_id equals setcut.merchant_id
        //                           join merc in myContext.m3_merchant on t.merchant_id equals merc.merchant_id  into mercX
        //                           from merc in mercX.DefaultIfEmpty()
        //                           //join merccon in myContext.m3_merchant_contact on t.merchant_id equals merccon.merchant_id into mercconX
        //                           //from merccon in mercconX.DefaultIfEmpty()
        //                           where t.merchant_id == merchant1 &&  u.settlement_date == date
        //                           select new
        //                           {
        //                               t.merchant_id,

        //                               merc.registration_name,
        //                               merc.biz_address1,
        //                               merc.biz_address2,
        //                               merc.biz_address3,
        //                               merc.biz_city,
        //                               merc.biz_state,
        //                               //merccon.firstname,
        //                               //merccon.lastname,
        //                               //merccon.email,
        //                               //setcut.settlement_date,
        //                               //setcut.TransactionAmount,
        //                               //setcut.BFAmount,
        //                               //setcut.CFAmount,

        //                               merc.tax_id,
        //                               u.settlement_date,
        //                               t.tx_amount,
        //                               t.computed_merchant_mdr_amount,
        //                               t.computed_merchant_wht_amount,
        //                               t.transaction_date,
        //                               t.computed_pay_to_merchant_amount,
        //                               t.transactiontype



        //                           });

        //        foreach (var myEntityRow in myEntitySet)
        //        {
        //            //string fullname = myEntityRow.firstname + " " + myEntityRow.lastname;
        //            string addr = myEntityRow.biz_address1 + " " + myEntityRow.biz_address2 +  " " + myEntityRow.biz_address3;

        //            drRow = dtTable.NewRow();

        //            drRow["merchant_id"] = myEntityRow.merchant_id;


        //            drRow["merchantname"] = myEntityRow.registration_name;
        //            //drRow["contactperson"] = fullname;
        //            drRow["TIN"] = myEntityRow.tax_id;
        //            drRow["address"] = addr;
        //            drRow["city"] = myEntityRow.biz_city;
        //            //drRow["emailcontact"] = myEntityRow.email;

        //            drRow["settlement_date"] = myEntityRow.settlement_date.ToString();
        //            drRow["tx_amount"] = myEntityRow.tx_amount;
        //            drRow["computedmdr"] = myEntityRow.computed_merchant_mdr_amount;
        //            drRow["computedwht"] = myEntityRow.computed_merchant_wht_amount;
        //            drRow["transdate"] = myEntityRow.transaction_date.ToString();
        //            drRow["paytomerchant"] = myEntityRow.computed_pay_to_merchant_amount;
        //            drRow["stat"] = myEntityRow.transactiontype.ToString();
        //            //drRow["BF"] = myEntityRow.BFAmount;
        //            //drRow["CF"] = myEntityRow.CFAmount;
        //            //drRow["transactiontotalamount"] = myEntityRow.TransactionAmount;

        //            dtTable.Rows.Add(drRow);
        //        }
        //    }
        //    return dtTable;
        //}

        //public DataTable getFraudDetails(string merchant, DateTime? date)
        //{
        //    int merchant1 = int.Parse(merchant);


        //    DataTable dtTable = new DataTable();
        //    DataRow drRow;


        //    dtTable.Columns.Add("merchant_id", typeof(string));

        //    //dtTable.Columns.Add("merchantname", typeof(string));
        //    //dtTable.Columns.Add("contactperson", typeof(string));
        //    //dtTable.Columns.Add("TIN", typeof(string));
        //    //dtTable.Columns.Add("address", typeof(string));
        //    //dtTable.Columns.Add("city", typeof(string));
        //    //dtTable.Columns.Add("emailcontact", typeof(string));

        //    //dtTable.Columns.Add("settlement_date", typeof(string));
        //    dtTable.Columns.Add("transdate", typeof(string));
        //    dtTable.Columns.Add("txnid", typeof(string));
        //    dtTable.Columns.Add("tx_amount", typeof(decimal));
        //    dtTable.Columns.Add("computedmdr", typeof(decimal));
        //    dtTable.Columns.Add("computedwht", typeof(decimal));       
        //    dtTable.Columns.Add("paytomerchant", typeof(decimal));
        //    //dtTable.Columns.Add("stat", typeof(string));
        //    //dtTable.Columns.Add("BF", typeof(decimal));
        //    //dtTable.Columns.Add("CF", typeof(decimal));
        //    //dtTable.Columns.Add("transactiontotalamount", typeof(decimal));

        //    using (M3_DEVEntities myContext = new M3_DEVEntities())
        //    {
        //        var myEntitySet = (from t in myContext.bil_SettlementFraud
        //                           //join u in myContext.tpa_settlement_batch on t.settlement_batch_id equals u.settlement_batch_id
        //                           //join setcut in myContext.bil_SettlementCutOff on t.merchant_id equals setcut.merchant_id
        //                           join merc in myContext.m3_merchant on t.merchant_id equals merc.merchant_id into mercX
        //                           from merc in mercX.DefaultIfEmpty()
        //                           //join merccon in myContext.m3_merchant_contact on t.merchant_id equals merccon.merchant_id into mercconX
        //                           //from merccon in mercconX.DefaultIfEmpty()
        //                           where t.merchant_id == merchant1 && t.settlement_date == date
        //                           select new
        //                           {
        //                               t.merchant_id,
        //                               t.transaction_date,
        //                               t.reconcile_tx_id,
        //                               t.tx_amount,
        //                               t.computed_merchant_mdr_amount,
        //                               t.computed_merchant_wht_amount,
        //                               t.computed_pay_to_merchant_amount

        //                               //merccon.firstname,
        //                               //merccon.lastname,
        //                               //merccon.email,
        //                               //setcut.settlement_date,
        //                               //setcut.TransactionAmount,
        //                               //setcut.BFAmount,
        //                               //setcut.CFAmount,





        //                           });

        //        foreach (var myEntityRow in myEntitySet)
        //        {
        //            //string fullname = myEntityRow.firstname + " " + myEntityRow.lastname;


        //            drRow = dtTable.NewRow();

        //            drRow["merchant_id"] = myEntityRow.merchant_id;
        //            drRow["transdate"] = myEntityRow.transaction_date.ToString();
        //            drRow["txnid"] = myEntityRow.reconcile_tx_id.ToString();
        //            drRow["tx_amount"] = myEntityRow.tx_amount;
        //            drRow["computedmdr"] = myEntityRow.computed_merchant_mdr_amount;
        //            drRow["computedwht"] = myEntityRow.computed_merchant_wht_amount;                    
        //            drRow["paytomerchant"] = myEntityRow.computed_pay_to_merchant_amount;



        //            dtTable.Rows.Add(drRow);
        //        }
        //    }
        //    return dtTable;
        //}

        //public DataTable getMerchantContact(string merchantID)
        //{ 
        //                int merchant1 = int.Parse(merchantID);


        //    DataTable dtTable = new DataTable();
        //    DataRow drRow;



        //    dtTable.Columns.Add("contactperson", typeof(string));
        //    dtTable.Columns.Add("emailcontact", typeof(string));

        //    using (M3_DEVEntities myContext = new M3_DEVEntities())
        //    {
        //        var myEntitySet = (from t in myContext.m3_merchant_contact
        //                           where t.merchant_id == merchant1
        //                           select new
        //                          {
        //                              t.firstname,
        //                              t.lastname,
        //                              t.email
        //                          });

        //        foreach (var myEntityRow in myEntitySet)
        //        {
        //            string fullname = myEntityRow.firstname + " " + myEntityRow.lastname;


        //            drRow = dtTable.NewRow();

        //            drRow["contactperson"] = fullname;
        //            drRow["emailcontact"] = myEntityRow.email;
        //            dtTable.Rows.Add(drRow);
        //        }
        //    }
        //    return dtTable;

        //}

        //public DataTable getallTransaction(DateTime? date, string merchant = "")
        //{
        //    DataTable dtTable = new DataTable();
        //    DataRow drRow;

        //    dtTable.Columns.Add("merchant_id", typeof(string));
        //    dtTable.Columns.Add("merchantname", typeof(string));
        //    dtTable.Columns.Add("TIN", typeof(string));
        //    dtTable.Columns.Add("address", typeof(string));
        //    dtTable.Columns.Add("city", typeof(string));
        //    dtTable.Columns.Add("settlement_date", typeof(string));
        //    dtTable.Columns.Add("tx_amount", typeof(decimal));
        //    dtTable.Columns.Add("computedmdr", typeof(decimal));
        //    dtTable.Columns.Add("computedwht", typeof(decimal));
        //    dtTable.Columns.Add("transdate", typeof(string));
        //    dtTable.Columns.Add("paytomerchant", typeof(decimal));
        //    //dtTable.Columns.Add("stat", typeof(int));
        //    dtTable.Columns.Add("AuthCode_TxnType", typeof(string));
        //    dtTable.Columns.Add("TransactID", typeof(string));


        //    using (M3_DEVEntities myContext = new M3_DEVEntities())
        //    {
        //        var myEntitySet = (from t in myContext.tpa_settlementtransaction
        //                           join u in myContext.tpa_settlement_batch on t.settlement_batch_id equals u.settlement_batch_id
        //                           join merc in myContext.m3_merchant on t.merchant_id equals merc.merchant_id into mercX
        //                           from merc in mercX.DefaultIfEmpty()
        //                           //join stat in myContext.tpa_SettlementTransactionStatus on t.transactiontype equals stat.transactionstatusid into statX
        //                           //from stat in statX.DefaultIfEmpty()
        //                           where u.settlement_date == date
        //                           select new
        //                           {
        //                               t.merchant_id,
        //                               merc.registration_name,
        //                               merc.biz_address1,
        //                               merc.biz_address2,
        //                               merc.biz_address3,
        //                               merc.biz_city,
        //                               merc.biz_state,
        //                               merc.tax_id,

        //                               u.settlement_date,

        //                               t.tx_amount,
        //                               t.computed_merchant_mdr_amount,
        //                               t.computed_merchant_wht_amount,
        //                               t.transaction_date,
        //                               t.computed_pay_to_merchant_amount,
        //                               t.transactiontype,
        //                               t.auth_code,
        //                               t.reconcile_tx_id,
        //                               //stat = stat.Description



        //                           });

        //        if (!string.IsNullOrEmpty(merchant))
        //        {
        //            int merchant1 = int.Parse(merchant);
        //            myEntitySet = myEntitySet.Where(t => t.merchant_id == merchant1 && t.settlement_date == date);
        //        }


        //        foreach (var myEntityRow in myEntitySet)
        //        {
        //            string addr = myEntityRow.biz_address1 + " " + myEntityRow.biz_address2 + " " + myEntityRow.biz_address3;
        //            //string auth_txncode = myEntityRow.auth_code + " - " + myEntityRow.stat;
        //            drRow = dtTable.NewRow();

        //            drRow["merchant_id"] = myEntityRow.merchant_id;
        //            drRow["merchantname"] = myEntityRow.registration_name;
        //            drRow["TIN"] = myEntityRow.tax_id;
        //            drRow["address"] = addr;
        //            drRow["city"] = myEntityRow.biz_city;
        //            drRow["settlement_date"] = myEntityRow.settlement_date.ToString();
        //            drRow["tx_amount"] = myEntityRow.tx_amount;
        //            drRow["computedmdr"] = myEntityRow.computed_merchant_mdr_amount;
        //            drRow["computedwht"] = myEntityRow.computed_merchant_wht_amount;
        //            drRow["transdate"] = myEntityRow.transaction_date.ToString();
        //            drRow["paytomerchant"] = myEntityRow.computed_pay_to_merchant_amount;
        //            //drRow["stat"] = myEntityRow.transactiontype;
        //            drRow["AuthCode_TxnType"] = auth_txncode;
        //            drRow["TransactID"] = myEntityRow.reconcile_tx_id.ToString();

        //            dtTable.Rows.Add(drRow);
        //        }
        //    }
        //    return dtTable;
        //}

        //public DataTable getDate_Merchant(DateTime? date, string merchant = "")
        //{
        //    DataTable dtTable = new DataTable();
        //    DataRow drRow;

        //    dtTable.Columns.Add("merchant_id", typeof(string));
        //    dtTable.Columns.Add("merchantname", typeof(string));
        //    dtTable.Columns.Add("TIN", typeof(string));
        //    dtTable.Columns.Add("address", typeof(string));
        //    dtTable.Columns.Add("city", typeof(string));
        //    dtTable.Columns.Add("settlement_date", typeof(string));
        //    dtTable.Columns.Add("tx_amount", typeof(decimal));
        //    dtTable.Columns.Add("computedmdr", typeof(decimal));
        //    dtTable.Columns.Add("computedwht", typeof(decimal));
        //    //dtTable.Columns.Add("transdate", typeof(string));
        //    dtTable.Columns.Add("paytomerchant", typeof(decimal));
        //    dtTable.Columns.Add("CurrentBal", typeof(decimal));

        //    //dtTable.Columns.Add("stat", typeof(int));
        //    //dtTable.Columns.Add("AuthCode_TxnType", typeof(string));
        //    //dtTable.Columns.Add("TransactID", typeof(string));
        //    dtTable.Columns.Add("transnetamount", typeof(decimal));
        //    dtTable.Columns.Add("Chargeback_NetAmount", typeof(decimal));
        //    dtTable.Columns.Add("Refund_NetAmount", typeof(decimal));
        //    dtTable.Columns.Add("AdjustmentAmount", typeof(decimal));
        //    dtTable.Columns.Add("RemainingBalance", typeof(decimal));
        //    dtTable.Columns.Add("Fraud_NetAmount", typeof(decimal));


        //    using (M3_DEVEntities myContext = new M3_DEVEntities())
        //    {
        //        var myEntitySet = (from t in myContext.bil_SettlementCutOff
        //                           join merc in myContext.m3_merchant on t.merchant_id equals merc.merchant_id into mercX
        //                           from merc in mercX.DefaultIfEmpty()
        //                           where t.settlement_date == date
        //                           select new
        //                           {
        //                               t.merchant_id,
        //                               merc.registration_name,
        //                               merc.biz_address1,
        //                               merc.biz_address2,
        //                               merc.biz_address3,
        //                               merc.biz_city,
        //                               merc.biz_state,
        //                               merc.tax_id,

        //                               t.settlement_date,

        //                               t.Transaction_NetAmount,
        //                               t.Transaction_MerchantMDRAmount,
        //                               t.Transaction_MerchantWHTAmount,
        //                               //t.transaction_date,
        //                               t.AmountPaid,

        //                               t.CurrentBalance,
        //                               t.RemainingBalance,

        //                               t.Chargeback_NetAmount,
        //                               t.Refund_NetAmount,
        //                               t.AdjustmentAmount,

        //                               t.Fraud_NetAmount
        //                               //t.transactiontype,
        //                               //t.auth_code,
        //                               //t.reconcile_tx_id,
        //                               //stat = stat.Description



        //                           });

        //        if (!string.IsNullOrEmpty(merchant))
        //        {
        //            int merchant1 = int.Parse(merchant);
        //            myEntitySet = myEntitySet.Where(t => t.merchant_id == merchant1 && t.settlement_date == date);
        //        }


        //        foreach (var myEntityRow in myEntitySet)
        //        {
        //            string addr = myEntityRow.biz_address1 + " " + myEntityRow.biz_address2 + " " + myEntityRow.biz_address3;
        //            //string auth_txncode = myEntityRow.auth_code + " - " + myEntityRow.stat;
        //            drRow = dtTable.NewRow();

        //            drRow["merchant_id"] = myEntityRow.merchant_id;
        //            drRow["merchantname"] = myEntityRow.registration_name;
        //            drRow["TIN"] = myEntityRow.tax_id;
        //            drRow["address"] = addr;
        //            drRow["city"] = myEntityRow.biz_city;
        //            drRow["settlement_date"] = myEntityRow.settlement_date.ToString();
        //            drRow["tx_amount"] = myEntityRow.Transaction_NetAmount;
        //            drRow["computedmdr"] = myEntityRow.Transaction_MerchantMDRAmount;
        //            drRow["computedwht"] = myEntityRow.Transaction_MerchantWHTAmount;
        //            //drRow["transdate"] = myEntityRow.transaction_date.ToString();
        //            drRow["paytomerchant"] = myEntityRow.AmountPaid;
        //            drRow["CurrentBal"] = myEntityRow.CurrentBalance;
        //            drRow["transnetamount"] = decimal.Parse(myEntityRow.Transaction_NetAmount.ToString()) - (decimal.Parse(myEntityRow.Chargeback_NetAmount.ToString()) + decimal.Parse(myEntityRow.Refund_NetAmount.ToString()) + decimal.Parse(myEntityRow.AdjustmentAmount.ToString()));
        //            drRow["Chargeback_NetAmount"] = myEntityRow.Chargeback_NetAmount;
        //            drRow["Refund_NetAmount"] = myEntityRow.Refund_NetAmount;
        //            drRow["AdjustmentAmount"] = myEntityRow.AdjustmentAmount;
        //            drRow["RemainingBalance"] = myEntityRow.RemainingBalance;
        //            drRow["Fraud_NetAmount"] = myEntityRow.Fraud_NetAmount;

        //            //drRow["stat"] = myEntityRow.transactiontype;
        //            //drRow["AuthCode_TxnType"] = auth_txncode;
        //            //drRow["TransactID"] = myEntityRow.reconcile_tx_id.ToString();

        //            dtTable.Rows.Add(drRow);
        //        }
        //    }
        //    return dtTable;
        //}


        public DataTable getDailySoaHeaders(DateTime? date, string merchant = "")
        {
            DataTable dtTable = new DataTable();
            DataRow drRow;

            dtTable.Columns.Add("merchant_id", typeof(string));
            dtTable.Columns.Add("settlement_date", typeof(string));

            dtTable.Columns.Add("registration_name", typeof(string));
            dtTable.Columns.Add("TIN", typeof(string));
            dtTable.Columns.Add("Address", typeof(string));
            dtTable.Columns.Add("City", typeof(string));

            dtTable.Columns.Add("CurrentBalance", typeof(decimal));
            dtTable.Columns.Add("Trans_NetAmount", typeof(decimal));
            //dtTable.Columns.Add("Chargeback_NetAmount", typeof(decimal));
            //dtTable.Columns.Add("Refund_NetAmount", typeof(decimal));            
            //dtTable.Columns.Add("Adjust_NetAmount", typeof(decimal));
            dtTable.Columns.Add("PayToMerchant", typeof(decimal));
            dtTable.Columns.Add("Remaining_Bal", typeof(decimal));
            dtTable.Columns.Add("Fraud_NetAmount", typeof(decimal));

            using (M3_DEVEntities myContext = new M3_DEVEntities())
            {
                var myEntitySet = (from t in myContext.bil_SettlementCutOff
                                   join merc in myContext.m3_merchant on t.merchant_id equals merc.merchant_id into mercX
                                   from merc in mercX.DefaultIfEmpty()
                                   where t.settlement_date == date
                                   select new
                                   {
                                       t.merchant_id,
                                       t.settlement_date,

                                       merc.registration_name,
                                       merc.tax_id,
                                       Address = merc.biz_address1 + " " + merc.biz_address2 + " " + merc.biz_address3,
                                       merc.biz_city,

                                       t.CurrentBalance,
                                       Transaction_Amount = t.Transaction_NetAmount - (t.Chargeback_NetAmount + t.Refund_NetAmount + t.AdjustmentAmount),

                                       t.AmountPaid,
                                       t.RemainingBalance,
                                       t.Fraud_NetAmount
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
                    drRow["settlement_date"] = myEntityRow.settlement_date;

                    drRow["registration_name"] = myEntityRow.registration_name;
                    drRow["TIN"] = myEntityRow.tax_id;
                    drRow["Address"] = myEntityRow.Address;
                    drRow["City"] = myEntityRow.biz_city;

                    drRow["CurrentBalance"] = myEntityRow.CurrentBalance;
                    drRow["Trans_NetAmount"] = myEntityRow.Transaction_Amount;
                    //drRow["Chargeback_NetAmount"] = myEntityRow.c;
                    //drRow["Refund_NetAmount"] = myEntityRow.merchant_id;
                    drRow["PayToMerchant"] = myEntityRow.AmountPaid;
                    drRow["Remaining_Bal"] = myEntityRow.RemainingBalance;
                    drRow["Fraud_NetAmount"] = myEntityRow.Fraud_NetAmount;

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

            using (M3_DEVEntities myContext = new M3_DEVEntities())
            {
                var myEntitySet = (from t in myContext.vw_SOADailyTransaction
                                   join settran in myContext.tpa_settlementtransaction on t.transactionid equals settran.reconcile_tx_id into settranX
                                   from settran in settranX.DefaultIfEmpty()
                                   where t.statementdate == date
                                   select new
                                   {
                                       settran.merchant_id,
                                       t.statementdate,
                                       t.transactiondate,
                                       t.transactionid,
                                       t.transactiontype,
                                       t.transactioncode,
                                       t.transactionamount,
                                       t.transactionMDR,
                                       t.transactionWHT,
                                       t.netamount
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

                    dtTable.Rows.Add(drRow);
                }
            }
            return dtTable;
        }
    }

}
