using System.ComponentModel.DataAnnotations;

namespace Commons.Entities.BaseEntity
{
    public class BaseEntity:IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}