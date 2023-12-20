using MediatR;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm> , IEntity
    {
        public Guid Id { get; set; }
    }
    public class GetFragmentDetailsQuery : IRequest<FragmentDetailsVm>, IEntity
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; } 
    }

    public class GetTagDetailsQuery : IRequest<TagDetailsVm>, IEntity
    {
        public Guid Id { get; set; }
    }


    public class GetRoleDetailsQuery : IRequest<RoleDetailsVm>, IEntity
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsVm>, IEntity
    {
        public Guid Id { get; set; }
    }
}
