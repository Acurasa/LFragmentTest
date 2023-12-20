using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Exceptions;
using Model.Models;

namespace Application.Commands
{
    public class DeleteCommandHandler : IRequestHandler<IRequest>
    {
        private readonly IApplicationDbContext _db;
        public DeleteCommandHandler(IApplicationDbContext db) => _db = db;
        public async Task Handle(IRequest request, CancellationToken cancellationToken)
        {
            switch (request)
            {
                case DeleteUserCommand deleteUserCommand:
                    var user = await _db.Users.FindAsync(new object[] { deleteUserCommand.Id }, cancellationToken);
                    if (user == null || user.Id != deleteUserCommand.Id)
                        throw new NotFoundException(nameof(deleteUserCommand),deleteUserCommand.Id);
                    _db.Users.Remove(user);
                    break;
                case DeleteFragmentCommand deleteFragmentCommand:
                    var fragment = await _db.Fragments.FindAsync(new object[] { deleteFragmentCommand.Id }, cancellationToken);
                    if (fragment == null || fragment.Id != deleteFragmentCommand.Id)
                        throw new NotFoundException(nameof(deleteFragmentCommand), deleteFragmentCommand.Id);
                    _db.Fragments.Remove(fragment);
                    break;
                case DeleteTagCommand deleteTagCommand:
                    var tag = await _db.Tags.FindAsync(new object[] { deleteTagCommand.Id }, cancellationToken);
                    if (tag == null || tag.Id != deleteTagCommand.Id)
                        throw new NotFoundException(nameof(deleteTagCommand), deleteTagCommand.Id);
                    _db.Tags.Remove(tag);
                    break;
                case DeleteRoleCommand deleteRoleCommand:
                    var role = await _db.Roles.FindAsync(new object[] { deleteRoleCommand.Id }, cancellationToken);
                    if (role == null || role.Id == deleteRoleCommand.Id)
                        throw new NotFoundException(nameof(deleteRoleCommand), cancellationToken);
                    _db.Roles.Remove(role);
                    break;
                case DeleteCategoryCommand deleteCategoryCommand:
                    var category = await _db.Categories.FindAsync(new object[] { deleteCategoryCommand.Id }, cancellationToken);
                    if (category == null || category.Id != deleteCategoryCommand.Id)
                        throw new NotFoundException(nameof(deleteCategoryCommand), deleteCategoryCommand.Id);
                    _db.Categories.Remove(category);
                    break;
            }
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
