### Архитектура 
Архитектура - порты-адаптеры. MVC, WebAPI через адаптеры. MailSender по апи забирает у WebAPI список 
людей с др, проверяет есть ли сегодня у кого др, если есть - отправляет сообщение на почту.

MVC можно запустить отдельно. - Home - Person - AddPerson в меню хедер. Person выдает список всех 
людей, в котором можно изменить, добавить фото, удалить и посмотреть страницу с детальной информацией.
На детальной странице отображаются фото, которое там же и можно удалить.

MailSender работает в связке с WebAPI. Почту указать в консоли, работает только с mail.ru

Валидацию не делал.

### Запуск проекта в докере

Докер композ в папке MVC.

docker-compose up -d

### Миграции:
dotnet ef migrations add InitialCreate -s SolarDR.MVC -p SolarDR.Infrastructure.Core
dotnet ef database update -s SolarDR.MVC -p SolarDR.Infrastructure.Core

### Если необходим pgAdmin:

Заходим http://localhost/browser/ Пароль pgAdmin adminpassword

Регистрируем сервер app.db

В connection указываем host - postgres / maintenance database - postgres / user - postgres / port - 5432 / password - postgres

### Если десктоп pgAdmin / DBeaver:

Регистрируем сервер app.db

В connection указываем host - localhost / maintenance database - postgres / user - postgres / port - 5433 / password - postgres
