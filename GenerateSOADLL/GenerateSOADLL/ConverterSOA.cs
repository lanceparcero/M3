using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using GenerateSOADLL.DataAccess;
using GemBox.Spreadsheet;
using System.Drawing;


namespace GenerateSOADLL
{
    public class ConverterSOA
    {
        public string Launch(string SettlementDate = "", string MerchantID = "")
        {
            DateTime filterStartDate;
            bool isDate = DateTime.TryParse(SettlementDate, out filterStartDate);
            Console.WriteLine("Initialize Excel Details");
            if (isDate)
            {
                MemoryStream memstr = new MemoryStream();
                DatabaseToExcel _excel = new DatabaseToExcel();
                var outputfilt = "";
                using (M3_PROEntities mycontext = new M3_PROEntities())
                {
                    DataTable settlementtransactions = _excel.getDailySoaHeaders(filterStartDate, MerchantID);
                    DataTable transactions = _excel.getDailySoaTransactions(filterStartDate, MerchantID); 
                    DataTable fraudtransactions = _excel.getFraudDetails(filterStartDate, MerchantID); 
                    int startrow = 21;
                    int startrowfraud;
                    int startrowfooter;
                    int no_ = 1;
                    int m3ID = int.Parse(MerchantID);
                    DateTime settlementdate = DateTime.Parse(settlementtransactions.Rows[0].ItemArray[1].ToString());
                    string transactid = "";
                    outputfilt = Settings.Default.DestinationPath.ToString() + "\\SOA" + settlementdate.ToString("yyyyMMdd") + "-" + settlementtransactions.Rows[0].ItemArray[0];
                    FileInfo newFile = new FileInfo(Settings.Default.SourceFilePath.ToString() + "\\GHL Daily Transaction Statement.xlsx");
                    ExcelPackage pck = new ExcelPackage(newFile);
                    var ws = pck.Workbook.Worksheets[1];
                    ws.View.ShowGridLines = false;

                    if (settlementtransactions.Rows.Count != 0)
                    {
                        ws.Cells["K4:L4"].Merge = true;
                        ws.Cells["K5:L5"].Merge = true;
                        ws.Cells["K6:L6"].Merge = true;
                        ws.Cells["K4"].Value = settlementtransactions.Rows[0]["merchant_id"];
                        ws.Cells["K5"].Value = settlementdate.ToString("yyyyMMdd") + "-" + settlementtransactions.Rows[0]["merchant_id"];
                        ws.Cells["K6"].Value = settlementdate.ToString("MM/dd/yyyy");

                        ws.Cells["L9"].Value = decimal.Parse(settlementtransactions.Rows[0]["CurrentBalance"].ToString());
                        ws.Cells["L10"].Value = decimal.Parse(settlementtransactions.Rows[0]["TotalTransaction"].ToString());
                        ws.Cells["L11"].Value = decimal.Parse(settlementtransactions.Rows[0]["TotalCBRF"].ToString());
                        ws.Cells["L12"].Value = decimal.Parse(settlementtransactions.Rows[0]["TotalTransactionAdjustment"].ToString());
                        ws.Cells["L13"].Value = decimal.Parse(settlementtransactions.Rows[0]["Others"].ToString());
                        ws.Cells["L14"].Value = decimal.Parse(settlementtransactions.Rows[0]["LessPaid"].ToString());
                        ws.Cells["L15"].Value = decimal.Parse(settlementtransactions.Rows[0]["BalanceCarryForward"].ToString());
                        ws.Cells["L16"].Value = decimal.Parse(settlementtransactions.Rows[0]["TotalWithdeld"].ToString());
                        
                        ws.Cells["B4:D4"].Merge = true;
                        ws.Cells["B5:D5"].Merge = true;
                        ws.Cells["B6:D6"].Merge = true;
                        ws.Cells["B7:D7"].Merge = true;
                        ws.Cells["B8:D8"].Merge = true;
                        ws.Cells["B9:D9"].Merge = true;
                        ws.Cells["B4"].Value = settlementtransactions.Rows[0]["InternalCompanyName"];
                        ws.Cells["B5"].Value = settlementtransactions.Rows[0]["Address1"];
                        ws.Cells["B6"].Value = settlementtransactions.Rows[0]["Address2"];
                        ws.Cells["B7"].Value = settlementtransactions.Rows[0]["Address3"];
                        ws.Cells["B8"].Value = "Company Tax Registration No: " + settlementtransactions.Rows[0]["taxid"];
                        ws.Cells["B9"].Value = "Company No: " + settlementtransactions.Rows[0]["businessregistionid"];
                        ws.Cells["B11"].Value = settlementtransactions.Rows[0]["registration_name"];
                        ws.Cells["B12"].Value = settlementtransactions.Rows[0]["ContactName"];
                        ws.Cells["B13"].Value = settlementtransactions.Rows[0]["TIN"];
                        ws.Cells["B14"].Value = settlementtransactions.Rows[0]["Address"];
                        ws.Cells["B15"].Value = settlementtransactions.Rows[0]["City"];
                        ws.Cells["B16"].Value = settlementtransactions.Rows[0]["ContactEmail"];
                        ws.Cells["K19"].Value = transactions.Rows[0]["country"].ToString() == "PH" ? "WHT" : "GST";
                        ws.Cells["K26"].Value = ws.Cells["K19"].Value;

                        if (transactions.Rows.Count != 0)
                        {
                            ws.InsertRow(21, (transactions.Rows.Count), 21);
                          
                            for (int i = 0; i < transactions.Rows.Count; i++)
                            {
                                transactid = transactions.Rows[i].ItemArray[1].ToString();
                                for (int j = 0; j < 7; j++)
                                {
                                    ws.Cells[startrow, 1].Value = no_;
                                    ws.Cells[startrow, 2].Value = transactions.Rows[i].ItemArray[0].ToString();
                                    ws.Cells["C" + startrow + ":D" + startrow].Merge = true;
                                    ws.Cells[startrow, 3].Value = transactions.Rows[i].ItemArray[1].ToString();
                                    ws.Cells[startrow, 5].Value = transactions.Rows[i].ItemArray[9].ToString();
                                    ws.Cells[startrow, 7].Value = transactions.Rows[i].ItemArray[2].ToString();
                                    ws.Cells[startrow, 8].Value = transactions.Rows[i].ItemArray[3].ToString();
                                    ws.Cells[startrow, 9].Value = transactions.Rows[i].ItemArray[4];
                                    ws.Cells[startrow, 10].Value = transactions.Rows[i].ItemArray[5];
                                    ws.Cells[startrow, 11].Value = transactions.Rows[i].ItemArray[6];
                                    ws.Cells[startrow, 12].Value = transactions.Rows[i].ItemArray[7];
                                }
                                startrow++;
                                no_++;
                            }
                            decimal
                                        transactionamountsum,
                                        mdramountsum,
                                        whtamountsum,
                                        netamountsum;

                            transactionamountsum = Convert.ToDecimal(transactions.Compute("Sum(transactionamount)", ""));
                            mdramountsum = Convert.ToDecimal(transactions.Compute("Sum(transactionMDR)", ""));
                            whtamountsum = Convert.ToDecimal(transactions.Compute("Sum(transactionWHT)", ""));
                            netamountsum = Convert.ToDecimal(transactions.Compute("Sum(transactionNetAmount)", ""));

                            ws.Cells[((startrow) + 1), 9].Value = transactionamountsum;
                            ws.Cells[((startrow) + 1), 10].Value = mdramountsum;
                            ws.Cells[((startrow) + 1), 11].Value = whtamountsum;
                            ws.Cells[((startrow) + 1), 12].Value = netamountsum;
                        }
                    }


                    startrowfraud = startrow + 7;
                    if (fraudtransactions.Rows.Count != 0)
                    {
                        ws.InsertRow(startrowfraud, (fraudtransactions.Rows.Count), startrowfraud);
                        DateTime frauddate = DateTime.Parse(fraudtransactions.Rows[0].ItemArray[1].ToString());
                        no_ = 1;
                        for (int i = 0; i < fraudtransactions.Rows.Count; i++)
                        {

                            for (int j = 0; j < 7; j++)
                            {
                                ws.Cells[startrowfraud, 1].Value = no_;
                                ws.Cells[startrowfraud, 2].Value = frauddate.ToString("MM/dd/yyyy");
                                ws.Cells["C" + startrowfraud + ":D" + startrowfraud].Merge = true;
                                ws.Cells[startrowfraud, 3].Value = fraudtransactions.Rows[i].ItemArray[2];
                                ws.Cells[startrowfraud, 7].Value = fraudtransactions.Rows[i].ItemArray[3];
                                ws.Cells[startrowfraud, 8].Value = "Withheld";
                                ws.Cells[startrowfraud, 9].Value = fraudtransactions.Rows[i].ItemArray[4];
                                ws.Cells[startrowfraud, 10].Value = fraudtransactions.Rows[i].ItemArray[5];
                                ws.Cells[startrowfraud, 11].Value = fraudtransactions.Rows[i].ItemArray[6];
                                ws.Cells[startrowfraud, 12].Value = fraudtransactions.Rows[i].ItemArray[7];

                            }
                            no_++;
                            startrowfraud++;
                        }
                        decimal 
                                  fraudtxamountsum, 
                                  fraudcomputedmrdsum, 
                                  fraudcomputedwhtsum, 
                                  fraudpaytomerchantsum;
                                   

                                    fraudtxamountsum = Convert.ToDecimal(fraudtransactions.Compute("Sum(tx_amount)", ""));
                                    fraudcomputedmrdsum = Convert.ToDecimal(fraudtransactions.Compute("Sum(computedmdr)", ""));
                                    fraudcomputedwhtsum = Convert.ToDecimal(fraudtransactions.Compute("Sum(computedwht)", ""));
                                    fraudpaytomerchantsum = Convert.ToDecimal(fraudtransactions.Compute("Sum(paytomerchant)", ""));


                        ws.Cells[((startrowfraud) + 1), 9].Value = fraudtxamountsum;
                        ws.Cells[((startrowfraud) + 1), 10].Value = fraudcomputedmrdsum;
                        ws.Cells[((startrowfraud) + 1), 11].Value = fraudcomputedwhtsum;
                        ws.Cells[((startrowfraud) + 1), 12].Value = fraudpaytomerchantsum;

                    }
                    startrowfooter = startrowfraud + 6;
                    ws.Cells[startrowfooter, 1].Value = "For any inquiries related to your account, please email us at " + settlementtransactions.Rows[0]["InternalEmail"] + " or call us at " + settlementtransactions.Rows[0]["InternalContact"];
                    Console.WriteLine("Saving as Excel");
                    pck.SaveAs(new FileInfo(outputfilt + ".xlsx"));
                    string BenboxKey = Settings.Default.SerialNum;
                    SpreadsheetInfo.SetLicense(BenboxKey);
                    Console.WriteLine("Converting from XLS to PDF");
                    ExcelFile.Load(outputfilt + ".xlsx").Save(outputfilt + ".pdf");
                }

                return outputfilt + ".pdf";
            }
            else
            {
                return null;
            }

        }
    }
}
