using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore3.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 200000)]
        public int Price { get; set; }

        //[Required(ErrorMessage = "Поле Имя быть установлено")]
        //[StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        //public string Name { get; set; }
        //// автор книги
        //[Required(ErrorMessage = "Поле Автор быть установлено")]
        //public string Author { get; set; }
        //// цена
        //[Required(ErrorMessage = "Поле Цена быть установлено")]
        //[Range(1, 200000, ErrorMessage = "Недопустимая цена")]
        //public int Price { get; set; }
    }
}