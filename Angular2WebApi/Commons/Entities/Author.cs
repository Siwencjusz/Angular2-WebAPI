using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commons.Entities
{
    public class Author:BaseEntity.BaseEntity
    {
        [Required, MaxLength(20, ErrorMessage = "Name must be 20 characters or less"), MinLength(3, ErrorMessage = "Name must be 3 characters or more")]
        public string Name { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Surname must be 20 characters or less"), MinLength(3, ErrorMessage = "Surname must be 3 characters or more")]
        public string Surname { get; set; }
        public List<Book> AuthorOfBooks { get; set; }
    }
}