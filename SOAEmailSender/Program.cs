using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GenerateSOADLL;
using GenerateSOADLL.DataAccess;
using System.Threading;


namespace SOAEmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                args = new string[] { DateTime.Now.ToShortDateString() };

            DateTime date;
            if (DateTime.TryParse(args[0], out date))
            {
                int[] mid;
                Console.WriteLine("Fetching Merchant Settlement Cutoff");
                using (M3_PROEntities entity = new M3_PROEntities())
                {
                    mid = (from sb in entity.bil_SettlementCutOff
                           where sb.settlement_date == date && sb.SOASendEmail
                           select sb.merchant_id).ToArray();
                }

                ConverterSOA converter = new ConverterSOA();
                string path = string.Empty;

                foreach (int m in mid)
                {
                    Console.WriteLine("Creating PDF...");
                    path = converter.Launch(date.ToShortDateString(), m.ToString());

                    if (!string.IsNullOrEmpty(path))
                    {
                        try
                        {
                            using (M3_PROEntities entity = new M3_PROEntities())
                            {
                                Console.WriteLine("Fetching merchant contact/s");

                                if (Properties.Settings.Default.MultipleRecipients == true)
                                {
                                    #region Multiple Recipients
                                    var mercontact = (from mer in entity.m3_merchant
                                                      join contact in entity.m3_merchant_contact on mer.merchant_id equals contact.merchant_id into mercon
                                                      from mc in mercon.DefaultIfEmpty()
                                                      where mer.merchant_id == m && mc.IsPrimary == true
                                                      select new
                                                      {
                                                          email = mc.email,
                                                          mer.CorporateID
                                                      }).ToArray();

                                    string multipleRecipients = "";
                                    int? corporateid = 0;

                                    foreach (var c in mercontact)
                                    {
                                        multipleRecipients += c.email+"|";
                                        corporateid = c.CorporateID;
                                    }

                                    m3_EmailSender emailsender = new m3_EmailSender();
                                    emailsender.Body = Properties.Settings.Default.Body;
                                    emailsender.Subject = Properties.Settings.Default.Subject;
                                    emailsender.RetryCount = 0;
                                    emailsender.Status = 1;
                                    emailsender.CreatedOn = DateTime.Now;
                                    emailsender.CorporateID = corporateid;
                                    emailsender.merchant_id = m;
                                    entity.m3_EmailSender.Add(emailsender);
                                    entity.SaveChanges();

                                    Console.WriteLine("Checking email sender");
                                    if (emailsender.EmailSenderID > 0)
                                    {
                                        foreach (var email in multipleRecipients.Split('|'))
                                        {
                                            if (email.Length > 0)
                                            {
                                                string test = email;
                                                m3_EmailRecipient emailreceipient = new m3_EmailRecipient();
                                                emailreceipient.EmailSenderID = emailsender.EmailSenderID;
                                                emailreceipient.Email = email ?? string.Empty;
                                                emailreceipient.RecipientType = 1;
                                                entity.m3_EmailRecipient.Add(emailreceipient);
                                            }
                                        }

                                        m3_EmailAttachment emailattachment = new m3_EmailAttachment();
                                        emailattachment.EmailSenderID = emailsender.EmailSenderID;
                                        emailattachment.FilePath = path;
                                        emailattachment.FilePathType = 1;
                                        entity.m3_EmailAttachment.Add(emailattachment);

                                        entity.SaveChanges();
                                    }

                                    Console.WriteLine(path + " Success");

                                    #endregion
                                }

                                else
                                {
                                    #region Single Recipient
                                    var mercontact = (from mer in entity.m3_merchant
                                                      join contact in entity.vw_MerchantFirstContact on mer.merchant_id equals contact.merchant_id into mercon
                                                      from mc in mercon.DefaultIfEmpty()
                                                      where mer.merchant_id == m
                                                      select new
                                                      {
                                                          email = mc.email,
                                                          mer.CorporateID
                                                      }).FirstOrDefault();

                                    m3_EmailSender emailsender = new m3_EmailSender();
                                    emailsender.Body = Properties.Settings.Default.Body;
                                    emailsender.Subject = Properties.Settings.Default.Subject;
                                    emailsender.RetryCount = 0;
                                    emailsender.Status = 1;
                                    emailsender.CreatedOn = DateTime.Now;
                                    emailsender.CorporateID = mercontact.CorporateID;
                                    emailsender.merchant_id = m;
                                    entity.m3_EmailSender.Add(emailsender);
                                    entity.SaveChanges();

                                    Console.WriteLine("Checking email sender");
                                    if (emailsender.EmailSenderID > 0)
                                    {
                                        m3_EmailRecipient emailreceipient = new m3_EmailRecipient();
                                        emailreceipient.EmailSenderID = emailsender.EmailSenderID;
                                        emailreceipient.Email = mercontact.email ?? string.Empty;
                                        emailreceipient.RecipientType = 1;
                                        entity.m3_EmailRecipient.Add(emailreceipient);

                                        m3_EmailAttachment emailattachment = new m3_EmailAttachment();
                                        emailattachment.EmailSenderID = emailsender.EmailSenderID;
                                        emailattachment.FilePath = path;
                                        emailattachment.FilePathType = 1;
                                        entity.m3_EmailAttachment.Add(emailattachment);

                                        entity.SaveChanges();

                                    }

                                    #endregion
                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(path + " Failed");
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            Console.WriteLine("Finish");
            Thread.Sleep(5000);

        }
    }
}
