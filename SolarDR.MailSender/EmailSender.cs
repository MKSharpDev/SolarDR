using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.MailSender
{
    public class EmailSender
    {
        private readonly Options _options;
        private readonly DRSorter _sorter;
        private readonly APIWorker _worker;

        public EmailSender(Options options, DRSorter sorter, APIWorker aPIWorker)
        {
            _options = options;
            _sorter = sorter;
            _worker = aPIWorker;
        }

        public async Task SendMessageAsync()
        {
            try
            {
                var persons = await _worker.GetPersonsAsync();
                
                var personForEmail = _sorter.SearchTodayBirthday(persons);
                if (personForEmail.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Сегодня дР!!");

                    foreach (var item in personForEmail)
                    {
                        sb.AppendLine($"{item.Name} {item.Name} {item.Date}");
                    }
                    var body = sb.ToString();

                    Console.WriteLine($"Email was sent at {DateTime.Now}");
                    string from = "bithd@moikomp.ru";
                    string to = _options.Email; // Адресс получателя приделах почтового сервера mail.ru
                    string head = "Hello Test!"; // Тема письма

                    string smtpserver = "mxs.mail.ru";
                    SmtpClient client = new SmtpClient(smtpserver, 25);

                    client.Send(from, to, head, body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
