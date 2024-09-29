# HakatonBAGNET

## Схема работы приложения
![alt text](s1.jpg)

## Используемые технологии

### База данных
В качестве СУБД используется PostgreSQL 16

#### Диаграмма Базы данных
![alt text](s2.png)

### Бэкенд
Для реализации доступа к данным телеграм бот использует написанную Web API. При её разработке был использован фреймворк Asp .NET Core и .NET 8.0.

#### Установленные Библиотеки
* Swashbuckle.AspNetCore 6.4.0
* Microsoft.EntityFrameworkCore 8.0.8
* Microsoft.EntityFrameworkCore.Relational 8.0.8
* Npsql.EntityFrameworkCore.PostgreSQL 8.0.8
* Npsql 8.0.4



### Телеграм бот
При написание телеграм бота использовался язык python.

#### Установленные Библиотеки
* Aiogram3
* requests 
* asyncio
* json

### Инструкция по запуску проекта