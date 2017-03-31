using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Commons.Entities;
using Commons.Entities.BaseEntity;

namespace Commons.DTOs
{
    public class AuthorDto : BaseDto.BaseDto
    {
        [Required, MaxLength(20, ErrorMessage = "Name must be 20 characters or less"), MinLength(3, ErrorMessage = "Name must be 3 characters or more")]
        public string Name { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Surname must be 20 characters or less"), MinLength(3, ErrorMessage = "Surname must be 3 characters or more")]
        public string Surname { get; set; }
        public List<Book> AuthorOfBooks { get; set; }
    }
}