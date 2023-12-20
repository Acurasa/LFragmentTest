using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public Guid? Role_Id { get; set; }
    }
    public class CreateFragmentCommand : IRequest<Guid>
    {
        public Guid User_Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Category_Id { get; set; }
        public string[]? Tag_Id {get; set;}
    }

    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    
    }
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }

    }
    public class CreateTagCommand : IRequest<Guid>
    {
        public string Name { get; set; }

    }
   
}
