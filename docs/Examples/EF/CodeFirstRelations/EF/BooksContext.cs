using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class BooksContext:DbContext
    {
        public BooksContext()
        { }

        public BooksContext(string connectionString)
            : base(connectionString)
        { }

        static BooksContext()
        {
            Database.SetInitializer<BooksContext>(new BooksContextInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookInfo> Infos { get; set; } // but table named BookInfoes!!
        public DbSet<BookDetail> Details { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
    }
}

/*
  
  CREATE TABLE [dbo].[Books] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Author]   NVARCHAR (MAX) NULL,
    [Title]    NVARCHAR (MAX) NULL,
    [ReaderId] INT            NULL,
    CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Books_dbo.Readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [dbo].[Readers] ([Id])
);

    CREATE NONCLUSTERED INDEX [IX_ReaderId]
    ON [dbo].[Books]([ReaderId] ASC);

  CREATE TABLE [dbo].[BookInfoes] (
    [Id]        INT NOT NULL,
    [Published] INT NOT NULL,
    CONSTRAINT [PK_dbo.BookInfoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.BookInfoes_dbo.Books_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Books] ([Id])

    CREATE TABLE [dbo].[Genres] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [GenreName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED ([Id] ASC)
);

    CREATE TABLE [dbo].[GenreBooks] (
    [Genre_Id] INT NOT NULL,
    [Book_Id]  INT NOT NULL,
    CONSTRAINT [PK_dbo.GenreBooks] PRIMARY KEY CLUSTERED ([Genre_Id] ASC, [Book_Id] ASC),
    CONSTRAINT [FK_dbo.GenreBooks_dbo.Genres_Genre_Id] FOREIGN KEY ([Genre_Id]) REFERENCES [dbo].[Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.GenreBooks_dbo.Books_Book_Id] FOREIGN KEY ([Book_Id]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);

    CREATE TABLE [dbo].[Readers] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Readers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

    CREATE TABLE [dbo].[AppUsers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [LastName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AppUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

    CREATE TABLE [dbo].[Friends] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [UserId]     INT NULL,
    [FriendId]   INT NULL,
    [AppUser_Id] INT NULL,
    CONSTRAINT [PK_dbo.Friends] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_dbo.Friends_dbo.AppUsers_FriendId] FOREIGN KEY ([FriendId]) REFERENCES [dbo].[AppUsers] ([Id]),
    CONSTRAINT [FK_dbo.Friends_dbo.AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUsers] ([Id]),
    CONSTRAINT [FK_dbo.Friends_dbo.AppUsers_AppUser_Id] FOREIGN KEY ([AppUser_Id]) REFERENCES [dbo].[AppUsers] ([Id])
);

 */
