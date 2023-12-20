using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model.Models;

namespace Application.Commands
{
    public class UpdateUserCommand : IRequest , IEntity
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public byte[]? Avatar { get; set; }
        public bool? IsOnline { get; set; }
        public Guid? Role_Id { get; set; }
    }

    public class UpdateFragmentCommand : IRequest, IEntity
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Category_Id { get; set; }
        public string[]? Tag_Id { get; set; }
    }
    public class UpdateRoleCommand : IRequest, IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateTagCommand : IRequest, IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class UpdateCategoryCommand : IRequest, IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
