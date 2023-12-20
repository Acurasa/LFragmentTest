using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IVm
    {

    }

    public class GetFragmentsListVm : IVm
    {
        public IList<GetFragmentLookup> Fragment { get; set; } 
    }

    public class GetUsersListVm : IVm
    {
        public IList<GetUserLookup> Users { get; set; }
    }
    public class GetTagListVm : IVm
    {
        public IList<GetTagLookup> Tags { get; set; }
    }
    public class GetCategoryListVm : IVm
    {
        public IList<GetCategoryLookup> Categories { get; set; }
    }
    public class GetRoleListVm : IVm
    {

        public IList<GetRoleLookup> Roles { get; set; }

    }
}
