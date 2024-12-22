У Диспетчері пакетів NuGet необхідно встановити наступні пакети:
Microsoft.EntityFrameworkCore.Design(8.0.11)
Microsoft.EntityFrameworkCore.Tools(8.0.11)
Pomelo.EntityFrameworkCore.MySql(8.0.2)

Зазіпований sql дамп БД знаходться у файлі DB/sto.zip

для створення Моделей та БД контексту для ВАШОГО варіанту еобхідно виконати наступну команду у консолі диспетчера пакетів:

Scaffold-DbContext "Server=localhost;Database=your_dn_name;User=youe_user_name;Password=your_password;" Pomelo.EntityFrameworkCore.MySql -o Models -Force

підставивши ваші данні (your_dn_name,youe_user_name,your_password)