using FluentScheduler;
using SolarDR.MailSender;


const string apiAdres = "https://localhost:7249/api/persons";

APIWorker worker = new APIWorker(apiAdres);

Console.WriteLine("Введите почту mail ru");
var email = Console.ReadLine();
Console.WriteLine("Ваша почта:");
Console.WriteLine(email);

Console.WriteLine("Если почта неправильная - перезапустите программу!");
//TO DO 
//Билдер который собирает Options

Options options = new Options() {Email = email };

DRSorter sorter = new DRSorter();

EmailSender emailSender = new EmailSender(options, sorter, worker);
await emailSender.SendMessageAsync();
while (true)
{
    
    JobManager.Initialize();
    JobManager.AddJob(
        async () => await emailSender.SendMessageAsync(),
        s => s.ToRunEvery(1).Days().At(10, 00) // At(часы , минуты) сейчас стоит отправка на 10 утра
    );
    Console.ReadLine();
}




