using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore3.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Трое из Простоквашино", Author = "Э. Успенский", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Муму", Author = "И. Тургенев", Price = 100 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });
            db.Books.Add(new Book { Name = "Палата №7", Author = "А. Чехов", Price = 170 });
            db.Books.Add(new Book { Name = "Три сестры", Author = "А. Чехов", Price = 150 });
            db.Books.Add(new Book { Name = "Мойдодыр", Author = "К. Чуковский", Price = 230 });
            db.Books.Add(new Book { Name = "Муха Цокотуха", Author = "К. Чуковский", Price = 140 });
            db.Books.Add(new Book { Name = "Краденое солнце", Author = "К. Чуковский", Price = 170 });
            db.Books.Add(new Book { Name = "Доктор Айболит", Author = "К. Чуковский", Price = 155 });
            db.Books.Add(new Book { Name = "Сказка о царе Султане", Author = "А. Пушкин", Price = 280 });
            db.Books.Add(new Book { Name = "Дубровский", Author = "А. Пушкин", Price = 360 });


            base.Seed(db);
        }
    }
}