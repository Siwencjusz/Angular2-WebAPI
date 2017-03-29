using System;
using System.ComponentModel.DataAnnotations;
using Commons.Entities;
using Commons.Entities.BaseEntity;

namespace Commons.DTOs
{
    public class BookDto : BaseEntity
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
