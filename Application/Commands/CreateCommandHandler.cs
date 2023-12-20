using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Model.Models;

namespace Application.Commands
{
    public class CreateCommandHandler : IRequestHandler<IRequest<Guid>, Guid>
    {
        private readonly IApplicationDbContext _db;
        public CreateCommandHandler(IApplicationDbContext db) => _db = db;

        public async Task<Guid> Handle(IRequest<Guid> request, CancellationToken cancellationToken)
        {

            switch (request)
            {
                case CreateUserCommand createUserCommand:
                    var user = new User
                    {
                        Id = Guid.NewGuid(),
                        Username = createUserCommand.Username,
                        PasswordHash = createUserCommand.PasswordHash,
                        Role_Id = createUserCommand?.Role_Id,
                        CreatedDate = DateTime.UtcNow,
                        Avatar = null,
                        IsOnline = true,
                    };
                    return await PersistentManager(user, cancellationToken);

                case CreateFragmentCommand createFragmentCommand:
                    var fragment = new Fragment
                    {
                        Id = Guid.NewGuid(),
                        Title = createFragmentCommand.Title,
                        Category_Id = createFragmentCommand.Category_Id,
                        Content = createFragmentCommand.Content,
                        Tag_Id = createFragmentCommand.Tag_Id,
                        User_Id = createFragmentCommand.User_Id,
                        Alias = this.GetHashCode(),
                        CreatedDate = DateTime.UtcNow,
                        Expires = DateTime.UtcNow.AddMonths(1),
                        UpdatedDate = DateTime.UtcNow
                    };
                    return await PersistentManager(fragment, cancellationToken);

                case CreateRoleCommand createRoleCommand:
                    var role = new Role
                    {
                        Id =Guid.NewGuid() ,
                        Name = createRoleCommand.Name,
                    };
                    return await PersistentManager(role, cancellationToken);

                case CreateTagCommand createTagCommand:
                    var tag = new Tag
                    {
                        Id = Guid.NewGuid(),
                        Name = createTagCommand.Name,
                    };
                    return await PersistentManager(tag, cancellationToken);
                case CreateCategoryCommand createCategoryCommand:
                    var category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = createCategoryCommand.Name,
                    };
                    return await PersistentManager(category, cancellationToken);
                default:
                    throw new InvalidOperationException("Unsupported Request Type");
            }
        }

        public async Task<Guid> PersistentManager(IEntity entity, CancellationToken cancellationToken)
        {
            Guid id;
            switch (entity)

            {
                case User user:
                    await _db.Users.AddAsync(user, cancellationToken);
                    id = user.Id; break;
                case Fragment fragment:
                    await _db.Fragments.AddAsync(fragment, cancellationToken);
                    id = fragment.Id; break;
                case Role role:
                    await _db.Roles.AddAsync(role, cancellationToken);
                    id = role.Id; break;
                case Tag tag:
                    await _db.Tags.AddAsync(tag, cancellationToken);
                    id = tag.Id; break;
                case Category category:
                    await _db.Categories.AddAsync(category, cancellationToken);
                    id = category.Id; break;
                default:
                    throw new InvalidOperationException("Unsupported Request Type");
            }
            await _db.SaveChangesAsync(cancellationToken);
            return id;
        }
    }
}