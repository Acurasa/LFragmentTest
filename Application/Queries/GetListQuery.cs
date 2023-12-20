using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Queries
{
    public class GetFragmentByUserIdListQuery : IRequest<IVm>
    {
        public Guid UserId { get; set; }
    }
    public class GetFragmentListQuery : IRequest<IVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
    public class GetUserListQuery : IRequest<IVm>
    {
        public Guid Id { get; set; }
    }

    public class GetTagListQuery : IRequest<IVm>
    {
        public Guid Id;
    }

    public class GetRoleListQuery : IRequest<IVm>
    {
        public Guid Id;
    }

    public class GetCategoryListQuery : IRequest<IVm>
    {
        public Guid Id;
    }
}
