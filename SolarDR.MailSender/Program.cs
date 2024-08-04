﻿using FluentScheduler;
using SolarDR.MailSender;
using System.Collections.Specialized;
using System.Net;
using System.Text;



const string apiAdres = "https://localhost:7249/api/persons";

APIWorker worker = new APIWorker(apiAdres);

Console.WriteLine("Введите почту mail ru");
var email = Console.ReadLine();
Console.WriteLine("Ваша почта:");
Console.WriteLine(email);

Console.WriteLine("Если почта не правильная - перезапустите программу! Мне еще с SPA на реакте разбираться! :)");


Options options = new Options() {Email = email };

DRSorter sorter = new DRSorter();

EmailSender emailSender = new EmailSender(options, sorter, worker);
while (true)
{
    
    JobManager.Initialize();
    JobManager.AddJob(
        async () => await emailSender.SendMessageAsync(),
        s => s.ToRunEvery(1).Days().At(10, 00) // At(часы , минуты) сейчас стоит отправка на 10 утра
    );
    Console.ReadLine();
}




