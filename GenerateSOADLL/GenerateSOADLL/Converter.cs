using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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



namespace GenerateSOADLL
{
    class Converter
    {
        public string Launch(string SettlementDate = "", string MerchantID = "")
        {
            //SPIRE initialize
            DateTime filterStartDate;
            bool isDate = DateTime.TryParse(SettlementDate, out filterStartDate);

            if (isDate)
            {
                MemoryStream memstr = new MemoryStream();
                DatabaseToExcel _excel = new DatabaseToExcel();
                var outputfilt = "";
                using (M3_PROEntities mycontext = new M3_PROEntities())
                {
                    DataTable settlementtransactions = _excel.getDailySoaHeaders(filterStartDate, MerchantID);
                    DataTable transactions = _excel.getDailySoaTransactions(filterStartDate, MerchantID); //M3Maintenance.getallTransaction(getDateFrom(), MerchantTransID);

                    //DataTable fraudtransactions = _excel.getFraudDetails(textBox1.Text, getDateFrom()); //M3Maintenance.getFraudDetails(MerchantTransID, getDateFrom());
                    int startrow = 19;
                    int no_ = 1;
                    int m3ID = int.Parse(MerchantID);
                    decimal transPeriod = 0;
                    decimal PayPeriod = 0;
                    DateTime settlementdate = DateTime.Parse(settlementtransactions.Rows[0].ItemArray[1].ToString());
                    //DateTime otherdate = DateTime.Parse(settlementtransactions.Rows[0].ItemArray[9].ToString());
                    string transactid = "";
                    outputfilt = Settings.Default.DestinationPath.ToString() + "\\SOA" + settlementdate.ToString("yyyyMMdd") + "-" + settlementtransactions.Rows[0].ItemArray[0];

                    FileInfo newFile = new FileInfo(Settings.Default.SourceFilePath.ToString() + "\\GHL Daily Transaction Statement.xlsx");
                    //var outputfilt = Settings.Default.DestinationPath.ToString() + "\\SOA" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ".xlsx";
                    //FileStream filustureamu = File.OpenRead(Settings.Default.SourceFilePath.ToString() + "\\GHL Daily Transaction Statement.xlsx");
                    ExcelPackage pck = new ExcelPackage(newFile);
                    //Add the Content sheet
                    var ws = pck.Workbook.Worksheets[1];
                    ws.View.ShowGridLines = false;

                    m3_merchant_contact merccon = mycontext.m3_merchant_contact.FirstOrDefault(t => t.merchant_id == m3ID);
                    tpa_settlement_batch batchid = mycontext.tpa_settlement_batch.FirstOrDefault(t => t.settlement_date == settlementdate);
                    tpa_settlementtransaction tpasettlementtrans = mycontext.tpa_settlementtransaction.FirstOrDefault(c => c.merchant_id == m3ID && c.settlement_batch_id == batchid.settlement_batch_id);

                    //if (getDateFrom() != null)
                    //{

                    if (settlementtransactions.Rows.Count != 0)
                    {

                        ws.Cells["K4:L4"].Merge = true;
                        ws.Cells["K4"].Value = settlementtransactions.Rows[0].ItemArray[0];
                        ws.Cells["K5:L5"].Merge = true;
                        ws.Cells["K5"].Value = settlementdate.ToString("yyyyMMdd") + "-" + settlementtransactions.Rows[0].ItemArray[0];
                        ws.Cells["K6:L6"].Merge = true;
                        ws.Cells["K6"].Value = settlementdate.ToString("MM/dd/yyyy");


                        ws.Cells["B9"].Value = settlementtransactions.Rows[0].ItemArray[2];
                        ws.Cells["B10"].Value = (merccon.firstname != null ? merccon.firstname.ToString() : "") + " " + (merccon.lastname != null ? merccon.lastname.ToString() : "");
                        ws.Cells["B11"].Value = settlementtransactions.Rows[0].ItemArray[3];
                        ws.Cells["B12"].Value = settlementtransactions.Rows[0].ItemArray[4];
                        ws.Cells["B13"].Value = settlementtransactions.Rows[0].ItemArray[5];
                        ws.Cells["B14"].Value = merccon.email != null ? merccon.email.ToString() : "";

                        ws.Cells["L9"].Value = settlementdate.ToString("MM/dd/yyyy");
                        ws.Cells["L10"].Value = decimal.Parse(settlementtransactions.Rows[0].ItemArray[6].ToString());
                        ws.Cells["L11"].Value = decimal.Parse(settlementtransactions.Rows[0].ItemArray[7].ToString());
                        ws.Cells["L12"].Value = decimal.Parse(settlementtransactions.Rows[0].ItemArray[8].ToString());
                        ws.Cells["L13"].Value = decimal.Parse(settlementtransactions.Rows[0].ItemArray[9].ToString());
                        ws.Cells["L14"].Value = decimal.Parse(settlementtransactions.Rows[0].ItemArray[10].ToString());




                        if (transactions.Rows.Count != 0)
                        {
                            ws.InsertRow(19, (transactions.Rows.Count), 19);
                            ws.Cells[((startrow + transactions.Rows.Count) + 1), 9].Formula = string.Format("=SUM(I" + startrow + ":I{0})", (startrow + transactions.Rows.Count));
                            ws.Cells[((startrow + transactions.Rows.Count) + 1), 10].Formula = string.Format("=SUM(J" + startrow + ":J{0})", (startrow + transactions.Rows.Count));
                            ws.Cells[((startrow + transactions.Rows.Count) + 1), 11].Formula = string.Format("=SUM(K" + startrow + ":K{0})", (startrow + transactions.Rows.Count));
                            ws.Cells[((startrow + transactions.Rows.Count) + 1), 12].Formula = string.Format("=SUM(L" + startrow + ":L{0})", (startrow + transactions.Rows.Count));

                            for (int i = 0; i < transactions.Rows.Count; i++)
                            {
                                //DataTable transactions = M3Maintenance.getallTransaction(getDateFrom(), TBMerchantID.Text);

                                transactid = transactions.Rows[i].ItemArray[1].ToString();

                                for (int j = 0; j < 7; j++)
                                {

                                    ws.Cells[startrow, 1].Value = no_;
                                    ws.Cells[startrow, 2].Value = transactions.Rows[i].ItemArray[0].ToString();
                                    ws.Cells["C" + startrow + ":D" + startrow].Merge = true;
                                    ws.Cells[startrow, 3].Value = transactions.Rows[i].ItemArray[1].ToString();
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
                        }
                    }



                    //if (fraudtransactions.Rows.Count != 0)
                    //{
                    //    int startrowfraud = startrow + 7;
                    //    ws.InsertRow(startrowfraud, (fraudtransactions.Rows.Count), startrowfraud);
                    //    ws.Cells[((startrowfraud + fraudtransactions.Rows.Count) + 1), 9].Formula = string.Format("=SUM(I" + startrow + ":I{0})", (startrowfraud + fraudtransactions.Rows.Count));
                    //    ws.Cells[((startrowfraud + fraudtransactions.Rows.Count) + 1), 10].Formula = string.Format("=SUM(J" + startrow + ":J{0})", (startrowfraud + fraudtransactions.Rows.Count));
                    //    ws.Cells[((startrowfraud + fraudtransactions.Rows.Count) + 1), 11].Formula = string.Format("=SUM(K" + startrow + ":K{0})", (startrowfraud + fraudtransactions.Rows.Count));
                    //    ws.Cells[((startrowfraud + fraudtransactions.Rows.Count) + 1), 12].Formula = string.Format("=SUM(L" + startrow + ":L{0})", (startrowfraud + fraudtransactions.Rows.Count));
                    //    DateTime frauddate = DateTime.Parse(fraudtransactions.Rows[0].ItemArray[1].ToString());
                    //    no_ = 1;
                    //    for (int i = 0; i < fraudtransactions.Rows.Count; i++)
                    //    {

                    //        for (int j = 0; j < 7; j++)
                    //        {
                    //            ws.Cells[startrowfraud, 1].Value = no_;
                    //            ws.Cells[startrowfraud, 2].Value = frauddate.ToString("MM/dd/yyyy");
                    //            ws.Cells[startrowfraud, 2].Style.Font.Color.SetColor(Color.Black);
                    //            //ws.Cells["C" + startrowfraud + ":D" + startrowfraud].Merge = true;
                    //            ws.Cells[startrowfraud, 3].Value = fraudtransactions.Rows[i].ItemArray[2];

                    //            ws.Cells[startrowfraud, 7].Value = fraudtransactions.Rows[i].ItemArray[3];
                    //            ws.Cells[startrowfraud, 8].Value = "Withheld";
                    //            ws.Cells[startrowfraud, 9].Value = fraudtransactions.Rows[i].ItemArray[4];
                    //            ws.Cells[startrowfraud, 10].Value = fraudtransactions.Rows[i].ItemArray[5];
                    //            ws.Cells[startrowfraud, 11].Value = fraudtransactions.Rows[i].ItemArray[6];
                    //            ws.Cells[startrowfraud, 12].Value = fraudtransactions.Rows[i].ItemArray[7];

                    //        }
                    //        no_++;
                    //        startrowfraud++;
                    //    }

                    //}

                    //ws.Cells["K13"].Value = PayPeriod;
                    //ws.Cells["B1:E1"].Style.Font.Bold = true;
                    //foreach (var item in collection)
                    //{

                    //}

                    pck.SaveAs(new FileInfo(outputfilt + ".xlsx"));
                }

                return outputfilt;
            }
            else
            {

                return null;
            }

        } 
    }
}
