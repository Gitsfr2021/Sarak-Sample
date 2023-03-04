using System.ComponentModel.DataAnnotations;

namespace Sarak.Data.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
