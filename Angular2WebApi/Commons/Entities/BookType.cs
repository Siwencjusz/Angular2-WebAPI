using System.ComponentModel.DataAnnotations;

namespace Commons.Entities
{
    public class BookType:BaseEntity.BaseEntity
    {
        [Required, MaxLength(20, ErrorMessage = "Book Type must be 20 characters or less"), MinLength(3, ErrorMessage = "Book Type must be 3 characters or more")]
        public string Type { get; set; }
    }
}