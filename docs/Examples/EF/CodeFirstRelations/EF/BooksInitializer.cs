using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DAL
{
    class BooksContextInitializer : DropCreateDatabaseAlways<BooksContext>
    {
        protected override void Seed(BooksContext db)
        {
            // Book and BookInfo - 1 to 1
            // Reader and Book - 1 to many
            // Gener and Book - many to many

            Reader reader1 = new Reader { Name = "Vasya" };
            Reader reader2 = new Reader { Name = "Petya" };
            Reader reader3 = new Reader { Name = "Senya" };
            db.Readers.AddRange(new List<Reader> { reader1, reader2, reader3 });
                      
            List<Book> listBook = new List<Book>();
            // id нужно только для установки связи 1 к 1 между объектами перед помещением их в бд. на уровне бд id другие
            listBook.Add(new Book { Id = 1, Title = "dastish fantastish a", Author = "Pupkin", Reader = reader1 });
            listBook.Add(new Book { Id = 2, Title = "dastish fantastish b", Author = "Kozlov", Reader = reader2 });
            listBook.Add(new Book { Id = 3, Title = "dastish fantastish c", Author = "Ivanov", Reader = reader3 });
            listBook.Add(new Book { Id = 4, Title = "dastish fantastish d", Author = "Kozlov", Reader = reader1 });
            listBook.Add(new Book { Id = 5, Title = "cat 1", Author = "Pupkin", Reader = reader1 });
            listBook.Add(new Book { Id = 6, Title = "cat 2", Author = "Kozlov", Reader = reader3 });
            listBook.Add(new Book { Id = 7, Title = "cat 3", Author = "Ivanov", Reader = reader1 });
            listBook.Add(new Book { Id = 8, Title = "cat 4", Author = "Kozlov", Reader = reader2 });
            

            Genre genre1 = new Genre { GenreName = "fantastic" };
            Genre genre2 = new Genre { GenreName = "adventure" };
            Genre genre3 = new Genre { GenreName = "animals" };

            int i = 1;
            foreach (var book in listBook)
            {
                if (i % 3 == 1)
                    genre1.Books.Add(book); // 1 - 1, 4, 7
                if (i % 3 == 2)
                    genre2.Books.Add(book); // 2 - 2, 5, 8
                if (i % 3 == 0)
                    genre3.Books.Add(book); // 3 - 3, 6
                i++;
            }

            i = 1;
            foreach (var book in listBook)
            {
                if (i % 3 == 0)
                    genre1.Books.Add(book); // 1 - 3, 6
                if (i % 3 == 1)
                    genre2.Books.Add(book); // 2 - 1, 4, 7
                if (i % 3 == 2)
                    genre3.Books.Add(book); // 3 - 2, 5, 8
                i++;
            }

            db.Books.AddRange(listBook);
            db.Genres.AddRange(new List<Genre> { genre1, genre2, genre3 });

            db.Infos.Add(new BookInfo { Id = 1, Published = 2014 });
            db.Infos.Add(new BookInfo { Id = 2, Published = 2015 });
            db.Infos.Add(new BookInfo { Id = 3, Published = 2000 });
            db.Infos.Add(new BookInfo { Id = 4, Published = 2014 });
            db.Infos.Add(new BookInfo { Id = 5, Published = 2013 });
            db.Infos.Add(new BookInfo { Id = 6, Published = 2013 });
            db.Infos.Add(new BookInfo { Id = 7, Published = 2015 });
            db.Infos.Add(new BookInfo { Id = 8, Published = 2000 });

            db.Details.Add(new BookDetail { Id = 1, Applied = 2014 });
            db.Details.Add(new BookDetail { Id = 2, Applied = 2015 });
            db.Details.Add(new BookDetail { Id = 3, Applied = 2000 });
            db.Details.Add(new BookDetail { Id = 4, Applied = 2014 });
            db.Details.Add(new BookDetail { Id = 5, Applied = 2013 });
            db.Details.Add(new BookDetail { Id = 6, Applied = 2013 });
            db.Details.Add(new BookDetail { Id = 7, Applied = 2015 });
            db.Details.Add(new BookDetail { Id = 8, Applied = 2000 });

            User user1 = new User { Id = 10, Name = "Anna", LastName = "Ivanova" };
            User user2 = new User { Id = 11, Name = "Vera", LastName = "Kozlova" };
            User user3 = new User { Id = 12, Name = "Ivan", LastName = "Romanov" };
            User user4 = new User { Id = 13, Name = "Ruslan", LastName = "Sidorov" };
            Friend friend1 = new Friend { UserId = 10, FriendId = 11 };
            Friend friend2 = new Friend { UserId = 10, FriendId = 12 };
            Friend friend3 = new Friend { UserId = 12, FriendId = 13 };

            user1.Friends.Add(friend1);
            user1.Friends.Add(friend2);
            user3.Friends.Add(friend3);

            db.Users.AddRange(new List<User> { user1, user2, user3, user4 });

            //db.Friends.AddRange(new List<Friend> { friend1, friend2, friend3 });



        }
    }
}