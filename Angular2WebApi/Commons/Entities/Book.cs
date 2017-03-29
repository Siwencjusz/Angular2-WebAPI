using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Entities
{
    public class Book:BaseEntity.BaseEntity
    {
        [Required, MaxLength(20, ErrorMessage = "Book name must be 20 characters or less"), MinLength(3, ErrorMessage = "Book name must be 3 characters or more")]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseTime { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        public PublishingHouse PublishingHouse { get; set; }
        [Required]
        public  BookType BookType { get; set; }
    }
}
