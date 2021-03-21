using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookEntity
    {
        public BookEntity() { }

        public int Id { get; set; }

        [Required(ErrorMessage ="Поле незаполнено")]
        [StringLength(20, ErrorMessage ="Символов должно быть не более 20")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле незаполнено")]
        [StringLength(20, ErrorMessage = "Символов должно быть не более 20")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Поле незаполнено")]
        [StringLength(20, ErrorMessage = "Символов должно быть не более 20")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Поле незаполнено")]
        public int Year { get; set; }

        [StringLength(50, ErrorMessage = "Символов должно быть не более 50")]
        public string Description { get; set; }
    }
}