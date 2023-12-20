using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model.Models
{
    public class Fragment : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set;}
        public DateTime? UpdatedDate { get; set;}
        public DateTime Expires { get; set; }
        public int? Alias { get; set; }
        [Required]
        public Guid User_Id { get; set; }
        public int? Category_Id { get; set; }
        [Required]
        public string[]? Tag_Id { get; set; }
    }
}
