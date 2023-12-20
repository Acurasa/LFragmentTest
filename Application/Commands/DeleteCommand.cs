using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteUserCommand : IRequest { public Guid Id { get; set; } }
    public class DeleteFragmentCommand : IRequest 
    {
        public Guid User_Id { get; set; }  
        public Guid Id { get; set; } 
    }

    public class DeleteCategoryCommand : IRequest { public Guid Id { get; set; } }
    public class DeleteTagCommand : IRequest { public Guid Id { get; set; } }
    public class DeleteRoleCommand : IRequest { public Guid Id { get; set; } }
}
