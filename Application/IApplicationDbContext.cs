using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;
namespace Application
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Fragment> Fragments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
