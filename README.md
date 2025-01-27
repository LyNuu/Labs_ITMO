# Object-Oriented Programming Lab Works in C#

Welcome to this repository! Here, you can explore laboratory works focused on **Object-Oriented Programming** using the **C#** language.

This repository contains a wide range of works, from simple visualizations to the design of **multi-layered architectures**.

Feel free to dive into the materials and explore the different aspects of object-oriented design and development in C#.














# -------------------------------------------------------------------------
# Лабораторная 1

## Отрабатываемый материал

Инкапсуляция, сокрытие, композиция, полиморфизм

## Цель

Освоить основные принципы ООП, применить на практике знания о работе с объектно-ориентированным кодом на C#

## Задание

- Реализовать объектную модель симулятора транспортного маршрута поездов
- Покрыть полученное решение модульными тестами

## Формулировка

В некотором абстрактном городе был запущен проект по строительству транспортной системы использующей поезда на магнитной
подушке. Для сокращения расходов на эксплуатацию системы, было принято решение использовать автоматизированные
транспортные маршруты, самостоятельно контролирующие передвижения поездов без необходимости нанимать машинистов.
В рамках проектирования данной транспортной системы, возникла необходимость моделирования этих транспортных
маршрутов, для того чтобы удостовериться в корректности их работы и предотвратить инциденты.

Вам как разработчикам была поставлена задача разработать данный симулятор.

## Функциональные требования

Основной информацией, которую должен выдавать ваш симулятор, является результат прохождения маршрута. Данный результат
может быть как успешным, так и нет ([подробнее](#станции)). Также результат должен содержать информацию об общем
времени, затраченном для прохождения пути.

### Поезда

В рамках симулятора поезда имеют следующие атрибуты:

- масса
- скорость
- ускорение
- максимально допустимая сила

Поезда должны уметь рассчитывать время прохождения определённого расстояния, эти вычисления должны основываться на
текущей скорости и ускорении поезда. Скорость и ускорение поезда изначально имеют нулевые значения.

Также к поездам можно приложить какую-либо силу, это происходит
на [силовых магнитных путях](#силовые-магнитные-пути). Приложение к поезду силы приводит к перерасчёту его
ускорения (рассчитываемого по формуле $ускорение={сила \over масса}$). При попытке приложить к поезду силу, превышающую
максимально допустимую, операция возвращает неудачу.

В данном симуляторе используются крайне упрощённые законы физики – поезда двигаются по законам материальной точки.

Поездам также задаётся точность – временной промежуток, на который разбиваются вычисления итогового времени прохождения
расстояния. Соответственно расчёт итогового времени прохождения расстояния должны происходить итеративно.

Каждая итерация расчёта времени предполагает расчёт результирующей скорости

$$результирующая\ скорость = текущая\ скорость + ускорение * точность$$

И расчёт пройденного расстояния

$$пройденное\ расстояние = результирующая\ скорость * точность$$

После расчёта пройденного расстояния, оно вычитается из оставшегося. Итерации продолжаются пока оставшееся расстояние не
будет меньше или равно нулю.

Следует принимать во внимание граничные случаи прохождения расстояния, когда поезд не имеет ни скорости, ни ускорения,
или же когда скорость поезда становится отрицательной. В таких случаях прохождение расстояния завершается неудачей.

### Участок маршрута

Маршрут транспортной системы состоит из участков, они представляют собой магнитные пути по которым могут передвигаться
поезда. Существуют несколько различных участков маршрута и поведение поезда на них отличается друг от друга.

Результатом прохождения поезда по участку пути, может являться либо успех, содержащий время прохождения, либо неудача.

#### Обычные магнитные пути

Обычные магнитные пути имеют продолжительность, которая влияет на время их прохождения. Успех прохождения через такие
пути определяется успехом прохождения поездом их расстояния.

#### Силовые магнитные пути

Силовые магнитные пути, как следует из названия, прикладывают к поезду силу на всём своём протяжении, эта сила может
быть как положительной, так и отрицательной (в таком случае поезд будет замедляться).

Так же как и обычные, силовые пути имеют продолжительность, влияющую на время их прохождения и успех их прохождения
определяется успехом прохождения поедом их расстояния.

#### Станции

Ещё одним видом участка маршрута являются станции. Когда поезд прибывает на станцию, происходит высадка и посадка
пассажиров. Факторы загруженности на высадку и посадку влияют на время прохождения станции поездом.

На станциях расположены силовые модули, тормозящие поезда до их остановки и разгоняющие их до скорости, с которой поезд
на неё прибыл. Но возможности этих модулей ограничены, станции имеют лимит по скорости приходящего поезда, поезда,
приходящие со скоростью, превышающую её не будут остановлены, что соответственно обозначает неудачу прохождения данного
участка маршрута.

### Маршрут

Маршрут является набором его участков и отвечает за логику прохождения поезда по этим участкам, а также обработку
результатов этих прохождений.

По завершению маршрута, поезд должен остановиться, для этого маршрут имеет механику схожую со станциями. На конце
маршрута расположены силовые модули также имеющие лимиты по скорости. Поэтому, если после прохождения всех участков
маршрута, поезд имеет скорость, превышающую допустимую – прохождение пути будет неудачно.

## Нефункциональные требования

- Ваша реализация должна соответствовать основным принципам ООП, вы должны корректно инкапсулировать логику и сокрывать
  не нужные извне состояния.
- Типы маршрута и его участков должны быть иммутабельными
- В реализации не должны использоваться исключения при обнаружении неудачных исходов подразумеваемых бизнес логикой

## Тестовые сценарии

### Сценарий 1

Маршрут:

- силовой путь, ускоряющий поезд до допустимой скорости маршрута
- обычный путь

Результат: успех

### Сценарий 2

Маршрут:

- силовой путь, ускоряющий поезд более допустимой скорости маршрута
- обычный путь

Результат: неудача

### Сценарий 3

Маршрут:

- силовой путь, ускоряющий поезд до допустимой скорости маршрута и станции
- обычный путь
- станция
- обычный путь

Результат: успех

### Сценарий 4

Маршрут:

- силовой путь, ускоряющий поезд более допустимой скорости станции
- станция
- обычный путь

Результат: неудача

### Сценарий 5

Маршрут:

- силовой путь, ускоряющий поезд более допустимой скорости маршрута, но до допустимой скорости станции
- обычный путь
- станция
- обычный путь

Результат: неудача

### Сценарий 6

Маршрут:

- силовой путь, ускоряющий поезд более допустимой скорости станции
- обычный путь
- силовой путь, замедляющий поезд до допустимой скорости станции
- станция
- обычный путь
- силовой путь, ускоряющий поезд более допустимой скорости маршрута
- обычный путь
- силовой путь, замедляющий поезд до допустимой скорости маршрута

Результат: успех

### Сценарий 7

Маршрут:

- обычный путь

Результат: неудача

### Сценарий 8

Маршрут:

- силовой путь длины X, прикладывающий силу Y
- силовой путь длины X, прикладывающий силу -2Y

Результат: неудача

## Определение готовности

- Реализованы все функциональные и нефункциональные требования
- Реализованы все тестовые сценарии, реализация успешно проходит эти тесты







# -------------------------------------------------------------------------

# Лабораторная 2

## Отрабатываемый материал

Основные принципы ООП, SOLID, GRASP, порождающие паттерны

## Цель

Отработать реализацию порождающих паттернов, применить их совместно с ранее изученным материалом.

## Задание

- реализовать модель конструктора образовательных программ
- покрыть полученное решение тестами

## Формулировка

Некоторый абстрактный университет проектирует систему для формирования и редактирования образовательных программ. Вам
необходимо спроектировать предметную область для реализации данного функционала.

В системе присутствуют: пользователи, лабораторные, лекционные материалы, критерии оценивания, предметы, сами
образовательные программы.

## Функциональные требования

### Пользователь

- Имеет идентификатор и имя
- Привязан к последующим создаваемым сущностям в качестве автора

### Лабораторная работа

- Имеет: идентификатор, наименование, описание, критерии оценивания, количество баллов
- Также имеет автора
- Лабораторную работу можно создать на основе уже существующей, в таком случае она должна хранить идентификатор
  лабораторной, взятой за основу
- Лабораторная может быть изменена, но сделать это может только её автор, при этом количество баллов неизменно

### Лекционные материалы

- Имеют: идентификатор, наименование, краткое описание, контент (строковый)
- Также имеют автора
- Лекционные материалы можно создать на основе уже существующих, в таком случае они должны хранить идентификатор
  лекционных материалов, взятых за основу
- Лекционные материалы могут быть изменены, но сделать это может только их автор

### Предмет

- Имеет: идентификатор, название, список лабораторных работ, список лекционных материалов
- Также имеет автора
- К предметам привязан зачётный формат: экзамен или зачет
- В случае, когда предмет имеет экзамен, он должен содержать количество баллов
- В случае, когда предмет имеет зачёт, он должен содержать информацию о минимальном количестве баллов, необходимых для
  получения этого зачёта
- Предмет можно создать на основе уже существующих, в таком случае он должен хранить идентификатор предмета, взятого за
  основу
- Предмет может быть изменён, но сделать это может только его автор, при этом списко лаборторных работ поменять нельзя, как и количество баллов за экзамен
- Суммарное количество баллов предмета должно ровнятся 100

### Образовательная программа

- Имеет: идентификатор, название, список предметов
- Предметы должны быть привязаны к определённым семестрам
- Также имеет ответственное лицо, руководителя программы

## Нефункциональные требования

- Реализации создания сущностей на основе предыдущих должны использовать различные порождающие паттерны
- Для сущностей должны быть реализованы репозитории, хранящие созданные объекты и осуществляющие поиск по их
  идентификаторам
- При использовании абстракций, не должно быть необходимости указывать автора каждый раз при сборке новых сущностей

> Репозиторий – тип, ответсвенный за хранение, добавление и поиск каких-либо сущностей. В данной лабораторной вам необхоимо сделать in-memory реализацию (основанную на листе или словаре, например), которая просто позволяет отслеживать определённые сущности и потом их искать.

## Тестовые сценарии

- Попытки изменения сущностей не автором – возвращают ошибки
- После создания сущностей на основе существующих, копии должны содержать идентификаторы исходника
- При создании предмета, с количеством баллов не равное 100 – возвращается ошибка

## Определение готовности

- реализованы все функциональные и не функциональные требования
- реализованы все необходимые юнит-тесты
- в реализации лабораторной используются порождающие паттерны
- реализация не нарушает принципы SOLID, следует основным концепциям ООП

# -------------------------------------------------------------------------

# Лабораторная 3

# Отрабатываемый материал

Многослойные архитектуры, паттерны

# Цель

Проверить освоение студентом многослойных архитектур

# Задание

Реализовать систему банкомата

# Функциональные требования

- создание счета
- просмотр баланса счета
- снятие денег со счета
- пополнение счета
- просмотр истории операций

# Не функциональные требования

- интерактивный консольный интерфейс
- возможность выбора режима работы (пользователь, администратор)
    - при выборе пользователя должны быть запрошены данные счета (номер, пин)
    - при выборе администратора должен быть запрошен системный пароль
        - при некорректном вводе пароля - система прекращает работу
- системный пароль должен быть параметризуем
- при попытке выполнения некорректных операций, должны выводиться сообщения об ошибке
- данные должны быть персистентно сохранены в базе данных (PostgreSQL)
- использование каких-либо ORM библиотек - запрещено
- приложение должно иметь хексагональную архитектуру
    - опционально: можно реализовать луковую архитектуру с богатой доменной моделью.

# Test cases

- снятие денег со счёта
    - при достаточном балансе проверить что сохраняется счёт с корректно обновлённым балансом
    - при недостаточном балансе сервис должен вернуть ошибку
- пополнение счёта
    - проверить что сохраняется счёт с корректно обновлённым балансом

данные тесты должны проверять бизнес логику, они не должны как-либо зависить от базы данных или консольного
представления.

в данных тестах необходимо использовать моки репозиториев.

# Ссылки

https://spectreconsole.net/

https://www.npgsql.org/

https://www.nuget.org/packages/NSubstitute

Так же можете воспользоваться вспомогательной библиотекой, содержащей расширения для более удобного задания параметров
команд.

https://github.com/itmo-is-dev/platform/tree/master/src/Itmo.Dev.Platform.Postgres

https://www.nuget.org/packages/Itmo.Dev.Platform.Postgres

### Для желающих попробовать DependencyInjection

https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage (очень плохие практики в примерах
кода, использовать только как шоукейс технологии)

# Примеры

https://github.com/is-oop-y27/workshop-5
