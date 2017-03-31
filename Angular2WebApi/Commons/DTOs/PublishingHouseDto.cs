using System.ComponentModel.DataAnnotations;
using Commons.Entities.BaseEntity;

namespace Commons.DTOs
{
    public class PublishingHouseDto:BaseDto.BaseDto
    {
        [Required, MaxLength(20, ErrorMessage = "Publish house name must be 20 characters or less"), MinLength(3, ErrorMessage = "Publish house name must be 3 characters or more")]
        public string Name { get; set; }
        
    }
}