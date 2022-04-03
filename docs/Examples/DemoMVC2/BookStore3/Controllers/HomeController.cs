using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore3.Models;
using System.Threading.Tasks;
// для EntityState.Modified
using System.Data.Entity;
using System.Threading;

using PagedList.Mvc;
using PagedList;
using System.IO;

namespace BookStore3.Controllers
{
   
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

       
        // /Home/Index
        public ActionResult Index()
        {
            ViewBag.Title = "Книжный магазин";
            return View(db.Books);
        }
        

        // /Home/Buy/1 или Home/Buy?id=1   1, 2, 3 - номер книги (параметр int id)
        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (db.Books.Find(id) == null)
            {
                return Redirect("/Home/Index");
            }

            ViewBag.BookId = id;
            ViewBag.Title = "Покупка";
            
            return View();
        }

        // кнопка submit на /Home/Buy/номер книги 1-3
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = getToday();
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

        // вызов Home/getToday/ запрещен
        private DateTime getToday()
        {
            return DateTime.Now;
        }

        // Home/EditBook/1
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // Home/CreateBook
        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                // or db.Entry(book).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // Home/DeleteBook/1
        [HttpGet]
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        // Атрибут ActionName("DeleteBook") указывает, что метод DeleteConfirmed будет восприниматься как действие Delete. 
        [HttpPost, ActionName("DeleteBook")]
        public ActionResult DeleteBookConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Home/Search
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost] // or ChildActionOnly
        public ActionResult BookSearch(string name)
        {
            Thread.Sleep(1000);
            var allbooks = db.Books.Where(a => a.Author.Contains(name)).ToList();
            if (allbooks.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allbooks);
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var authors = db.Books.Where(a => a.Author.Contains(term))
                            .Select(a => new { value = a.Author })
                            .Distinct();

            return Json(authors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
                return PartialView(book);
            return HttpNotFound();
        }

        // Home/IndexPaged
        public ActionResult IndexPaged(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.Books.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}
