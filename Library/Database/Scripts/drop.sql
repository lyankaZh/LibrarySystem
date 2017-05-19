IF OBJECT_ID('dbo.BorrowInfo', 'U') IS NOT NULL
DROP TABLE BorrowInfo

IF OBJECT_ID('dbo.BookAuhors', 'U') IS NOT NULL
DROP TABLE BookAuhors

IF OBJECT_ID('dbo.Readers', 'U') IS NOT NULL
DROP TABLE Readers

use Library4
IF OBJECT_ID('dbo.Authors', 'U') IS NOT NULL
DROP TABLE Authors

IF OBJECT_ID('dbo.Genres', 'U') IS NOT NULL
DROP TABLE Genres

IF OBJECT_ID('dbo.Languages', 'U') IS NOT NULL
DROP TABLE Languages

IF OBJECT_ID('dbo.Publishers', 'U') IS NOT NULL
DROP TABLE BorrowInfo

IF OBJECT_ID('dbo.Books', 'U') IS NOT NULL
DROP TABLE Books

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
DROP TABLE Users
