use Library4

SET IDENTITY_INSERT Genres ON;
INSERT INTO Genres(GenreId,GenreName) 
VALUES
(1,'Comedy'),
(2,'Drama'),
(3,'Fantasy'),
(4,'Tragedy'),
(5,'Tragicomedy');
SET IDENTITY_INSERT Genres OFF;

SET IDENTITY_INSERT Languages ON;
INSERT INTO Languages(LanguageId, LanguageName) 
VALUES
(1,'English'),
(2,'German'),
(3,'Spanish'),
(4,'Ukrainian'),
(5,'French');
SET IDENTITY_INSERT Languages OFF;


SET IDENTITY_INSERT Publishers ON;
INSERT INTO Publishers(PublisherId, PublisherName , Country , City) 
VALUES
(1,'ABC','USA','Las Vegas'),
(2,'Union','UK','London'),
(3,'BiBaBu','Germany','Berlin'),
(4,'Ababagalamaga','Ukrain','Lviv'),
(5,'Mordor','Monako','Monako');
SET IDENTITY_INSERT Publishers OFF;


SET IDENTITY_INSERT Readers ON;
INSERT INTO Readers(ReaderId, FirstName ,MiddleName, LastName , [Address] , PhoneNumber, RegistrationDate) 
VALUES
(1,'Derek', 'Terner','Shepard','Left Str. 2/12','0879515111', '01.05.2017'),
(2,'John','William','Snow','Main Str. 6/6','0912548654','01.02.2016'),
(3,'Mikle','Stephan','Smith','Memory Str. 4/20','0123456789','05.12.2016'),
(4,'Alex','Sebastian','Bing','Solo Str. 3/22','0987654321','03.07.2016'),
(5,'Whalter','Omeli','White','BLue Str. 22/8','0359575155','11.11.2017');
SET IDENTITY_INSERT Readers OFF;


SET IDENTITY_INSERT Books ON;
INSERT INTO Books(BookId, Name, [Year], Pages, Location, GenreId, LanguageId, PublisherId)
VALUES
(1, 'Harry Potter',2007,600,'3.2.2',3,4,4),
(2, 'Anatomy',2012,900,'1.4.6',1,2,3),
(3, 'Cooking Time', 2017,125,'2.2.2',4,4,4),
(4, 'Kobzar',1987,250,'4.1.1',1,1,1),
(5, 'FEM',2004,300,'1.2.2',2,3,2);
SET IDENTITY_INSERT Books OFF;

SET IDENTITY_INSERT Authors ON;
INSERT INTO Authors(AuthorId, FirstName, LastName)
VALUES
(1,'Taras','Shevchenko'),
(2,'Jamie','Oliver'),
(3,'Joanne','Rowling'),
(4,'George','Shynkarenko'),
(5,'Gregory','House');
SET IDENTITY_INSERT Authors OFF;

INSERT INTO BorrowInfo (BorrowDate, BorrowPeriodInDays, ReturningDate, BookId, ReaderId)
VALUES
('10.04.2017',15,'10.05.2017',4,5),
('08.02.2017',30,'10.05.2017',4,4),
('03.06.2016',10,'03.12.2016',5,4);


INSERT INTO BorrowInfo (BorrowDate, BorrowPeriodInDays, BookId, ReaderId)
VALUES
('10.05.2017',20,1,1),
('07.05.2017',10,2,3);

INSERT INTO BookAuthors(BookId, AuthorId)
VALUES
(1,3),
(2,4),
(2,5),
(3,4),
(4,1),
(5,2);