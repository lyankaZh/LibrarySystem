CREATE DATABASE Library4;
GO 

use Library4

CREATE TABLE Languages(
LanguageId int Identity(1,1) CONSTRAINT LanguageId_PK PRIMARY KEY,
LanguageName nvarchar(max) not null
)

CREATE TABLE Genres(
GenreId int Identity(1,1) CONSTRAINT GenreId_PK PRIMARY KEY,
GenreName nvarchar(max) not null
)

CREATE TABLE Publishers(
PublisherId int Identity(1,1) CONSTRAINT PublisherId_PK PRIMARY KEY,
PublisherName nvarchar(max) not null,
Country nvarchar(max) null,
City nvarchar(max) null)

CREATE TABLE Users(
[Login] nvarchar(128) CONSTRAINT User_PK PRIMARY KEY,
[Password] nvarchar(max) not null
)

CREATE TABLE Readers(
ReaderId int Identity(1,1) CONSTRAINT ReaderId_PK PRIMARY KEY,
FirstName nvarchar(max) not null,
MiddleName nvarchar(max) null,
LastName nvarchar(max) not null,
[Address] nvarchar(max) null,
PhoneNumber nvarchar(max) null,
RegistrationDate datetime null,
)

CREATE TABLE Authors(
AuthorId int Identity(1,1) CONSTRAINT AuthorId_PK PRIMARY KEY,
FirstName nvarchar(max) not null,
MiddleName nvarchar(max) null,
LastName nvarchar(max) not null)

CREATE TABLE Books(
BookId int Identity(1,1) CONSTRAINT BookId_PK PRIMARY KEY,
Name nvarchar(max) not null,
[Year] int not null,
Pages int not null,
Location nvarchar(max) null,
GenreId int null,
LanguageId int null,
PublisherId int null,

CONSTRAINT FK_Books_Genre FOREIGN KEY (GenreId) REFERENCES Genres(GenreId) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Books_Language FOREIGN KEY (LanguageId) REFERENCES Languages(LanguageId) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Books_Publisher FOREIGN KEY (PublisherId) REFERENCES Publishers(PublisherId) ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE BookAuthors(
BookId int not null,
AuthorId int not null,
CONSTRAINT PK_BooksAuthors PRIMARY KEY (BookId, AuthorId),

CONSTRAINT FK_Books_Book FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Books_Author FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE BorrowInfo(
OrderId int Identity(1,1) CONSTRAINT BorrowId_PK PRIMARY KEY,
BookId int not null,
ReaderId int not null,
BorrowDate datetime not null,
BorrowPeriodInDays int not null,
ReturningDate datetime null,

CONSTRAINT FK_Borrow_Book FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Borrow_Reader FOREIGN KEY (ReaderId) REFERENCES Readers(ReaderId) ON DELETE CASCADE ON UPDATE CASCADE
)

