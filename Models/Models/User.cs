using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class User : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Range(1, 100)]
        public  string Username { get; set; }
        [Required]
        [Range(1, 100)]
        public  string PasswordHash { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[]? Avatar { get; set; }
        public bool? IsOnline {  get; set; }
        public Guid? Role_Id { get; set; }
    }
}
