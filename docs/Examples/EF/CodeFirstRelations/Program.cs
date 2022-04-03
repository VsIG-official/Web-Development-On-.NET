using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL;

namespace CodeFirstRelations
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationSettings.AppSettings["DataDirectory"];
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            using (BooksContext db = new BooksContext("BooksDB"))
            {
                // testing 1 to 1
                foreach (Book book in db.Books.ToList()) // db.Books.Include("Info")
                    Console.WriteLine($"Id: {book.Id}  Title: {book.Title}  Published: {book.Info.Published}");
                Console.WriteLine();


                // testing 1 to many
                Console.WriteLine("\n\n");
                var query1 = db.Books;
                Console.WriteLine(query1.ToString());
                var query2 = db.Books.Include("Reader");
                Console.WriteLine(query2.ToString());
                Console.WriteLine("\n\n");

                foreach (Book book in db.Books.ToList()) // db.Books.Include("Reader")
                    Console.WriteLine("{0} - {1}", book.Title, book.Reader != null ? book.Reader.Name : "");
                Console.WriteLine();

                foreach (Reader reader in db.Readers/*.Include("Books")*/.ToList())
                {
                    Console.WriteLine($"Reader: {reader.Name}");
                    foreach (Book book in reader.Books)
                    {
                        Console.WriteLine($"{book.Title} - {book.Author}");
                    }
                    Console.WriteLine();
                }

                // testing many to many
                foreach (var gener in db.Genres.OrderBy(t => t.Id).ToList())
                {
                    Console.WriteLine($"Genre: {gener.GenreName}");
                    foreach (var book in gener.Books.OrderBy(t => t.Id).ToList())
                    {
                        Console.WriteLine($"----{book.Title}");
                    }
                    Console.WriteLine();
                }

                foreach (var book in db.Books.OrderBy(t => t.Id).ToList())
                {
                    Console.WriteLine($"Book: {book.Title}");
                    foreach (var gener in book.Genres.OrderBy(t => t.Id).ToList())
                    {
                        Console.WriteLine($"----{gener.GenreName}");
                    }
                    Console.WriteLine();
                }

            }

            UpdateDeleteOneToOne();
            UpdateDeleteOneToMany();
            UpdateDeleteManyToMany();

            Console.ReadKey();
        }

        static void UpdateDeleteOneToOne()
        {
            // insert test data
            using (BooksContext db = new BooksContext("BooksDB"))
            {
                db.Books.Add(new Book { Id = 9, Title = "Title", Author = "Kozlov" });
                db.Infos.Add(new BookInfo { Id = 9, Published = 2000 });
                db.Details.Add(new BookDetail { Id = 9, Applied = 2000 });
                db.SaveChanges();
            }

            // update
            using (BooksContext db = new BooksContext("BooksDB"))
            {

                Book book = db.Books.FirstOrDefault(b => b.Title == "Title");
                if (book != null)
                {
                    book.Title = "New title";
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                BookInfo bookInfo = db.Infos.FirstOrDefault(p => p.Book.Title == "New title");
                if (bookInfo != null)
                {
                    bookInfo.Published = 2017;
                    db.Entry(bookInfo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                // check update
                foreach (Book b in db.Books.ToList()) // db.Books.Include("Info")
                    Console.WriteLine($"Id: {b.Id}  Title: {b.Title}  Published: {b.Info.Published}");
                Console.WriteLine();
            }



            //delete
            using (BooksContext db = new BooksContext("BooksDB"))
            {
                // both records in master and slave tables deleted
                Book book = db.Books.FirstOrDefault(b => b.Title == "New title");
                if (book != null)
                {
                    db.Infos.Remove(book.Info);
                    db.Details.Remove(book.Detail);
                    db.Books.Remove(book);
                    db.SaveChanges();
                }

                // check delete
                foreach (Book b in db.Books.ToList()) // db.Books.Include("Info")
                    Console.WriteLine($"Id: {b.Id}  Title: {b.Title}  Published: {b.Info.Published}");
                Console.WriteLine();

                //or
                // the record in slave tables deleted
                BookInfo bookInfo = db.Infos.FirstOrDefault(p => p.Book.Title == "New title");
                if (bookInfo != null)
                {
                    db.Infos.Remove(bookInfo);
                    db.SaveChanges();
                }

            }

        }

        static void UpdateDeleteOneToMany()
        {
            // update
            using (BooksContext db = new BooksContext("BooksDB"))
            {
                Reader oldReader = db.Readers.FirstOrDefault(b => b.Name == "Vasya");
                Reader newReader = db.Readers.FirstOrDefault(b => b.Name == "Senya");

                if ((oldReader != null) && (newReader != null))
                {
                    Console.WriteLine("Vasya books - {0}", db.Books.Count(b => b.Reader.Name == "Vasya"));
                    Console.WriteLine("Senya books - {0}", db.Books.Count(b => b.Reader.Name == "Senya"));

                    Book book = db.Books.FirstOrDefault(b => b.Reader.Name == oldReader.Name);
                    if (book != null)
                    {
                        book.Reader = newReader;
                        db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                Console.WriteLine("Vasya books - {0}", db.Books.Count(b => b.Reader.Name == "Vasya"));
                Console.WriteLine("Senya books - {0}", db.Books.Count(b => b.Reader.Name == "Senya"));

            }

            //delete
            using (BooksContext db = new BooksContext("BooksDB"))
            {
                // both records in master and slave tables deleted
                Reader reader = db.Readers.FirstOrDefault();
                if (reader != null)
                {
                    try
                    {
                        db.Readers.Remove(reader);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Type t;
                        while (e != null)
                        {
                            t = e.GetType();
                            Console.WriteLine($" {t.Name} - {e.Message}");
                            e = e.InnerException;
                        }
                    }
                }

                
            }
        }

        static void UpdateDeleteManyToMany()
        {
            // delete record from table GenreBooks (delete only link, not the book or the genre at all)
            using (BooksContext db = new BooksContext("BooksDB"))
            {
                Console.WriteLine();
                Console.WriteLine("Books of ganre 'animals' - {0}", db.Books.Count(b => b.Genres.Count(c => c.GenreName == "animals") != 0));
                Console.WriteLine("Genres of book 'cat 2' - {0}", db.Genres.Count(b => b.Books.Count(c => c.Title == "cat 2") != 0));

                Book book = db.Books.First(p => p.Title == "cat 2");
                Genre genre = book.Genres.First(p => p.GenreName == "animals");
                genre.Books.Remove(book);
                db.SaveChanges();

                Console.WriteLine("Books of ganre 'animals' - {0}", db.Books.Count(b => b.Genres.Count(c => c.GenreName == "animals") != 0));
                Console.WriteLine("Genres of book 'cat 2' - {0}", db.Genres.Count(b => b.Books.Count(c => c.Title == "cat 2") != 0));

            }
        }

    }
}


