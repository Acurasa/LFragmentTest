using MediatR;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Application.Commands
{
    public class UpdateCommandHandler : IRequestHandler<IRequest>
    {
        private readonly IApplicationDbContext _db;
        public UpdateCommandHandler(IApplicationDbContext db) => _db = db;

        private async Task NotFoundExceptionFactory(IEntity? entity, IEntity request)
        {
            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(request), request.Id);
        }
        public async Task Handle(IRequest request, CancellationToken cancellationToken)
        {
            switch (request)
            {
                case UpdateUserCommand updateUserCommand:

                    var userEntity = await _db.Users.FirstOrDefaultAsync(user => user.Id == updateUserCommand.Id, cancellationToken);

                    await NotFoundExceptionFactory(userEntity, updateUserCommand);

                    if (userEntity is User user)
                    {
                        user.Username ??= updateUserCommand.Username;
                        user.IsOnline ??= updateUserCommand.IsOnline;
                        user.Role_Id ??= updateUserCommand.Role_Id;
                        user.Email ??= updateUserCommand.Email;
                        user.Avatar ??= updateUserCommand.Avatar;
                        user.PasswordHash ??= updateUserCommand.PasswordHash;
                    }
                    break;
                case UpdateFragmentCommand updateFragmentCommand:

                    var fragmentEntity = await _db.Fragments.FirstOrDefaultAsync(fragment => fragment.Id == updateFragmentCommand.Id, cancellationToken);

                    await NotFoundExceptionFactory(fragmentEntity, updateFragmentCommand);

                    if (fragmentEntity is Fragment fragment)
                    {
                        if (fragment.Content != updateFragmentCommand.Content && updateFragmentCommand is not null)
                        {
                            fragment.UpdatedDate = DateTime.UtcNow;
                            fragment.Expires = DateTime.UtcNow.AddMonths(1);
                            fragment.Content = updateFragmentCommand.Content;
                        }
                        fragment.Category_Id ??= updateFragmentCommand.Category_Id;
                        fragment.Tag_Id ??= updateFragmentCommand.Tag_Id;
                    }
                    break;

                case UpdateRoleCommand updateRoleCommand:

                    var roleEntity = await _db.Roles.FirstOrDefaultAsync(role => role.Id == updateRoleCommand.Id, cancellationToken);
                    await NotFoundExceptionFactory(roleEntity, updateRoleCommand);
                    if (roleEntity is Role role)
                        role.Name ??= updateRoleCommand.Name;
                    break;

                case UpdateTagCommand updateTagCommand:

                    var tagEntity = await _db.Tags.FirstOrDefaultAsync(tag => tag.Id == updateTagCommand.Id, cancellationToken);
                    await NotFoundExceptionFactory(tagEntity, updateTagCommand);
                    if (tagEntity is Tag tag)
                        tag.Name ??= updateTagCommand.Name;
                    break;
                case UpdateCategoryCommand updateCategoryCommand:

                    var categoryEntity = await _db.Categories.FirstOrDefaultAsync(category => category.Id == updateCategoryCommand.Id, cancellationToken);
                    await NotFoundExceptionFactory(categoryEntity, updateCategoryCommand);
                    if (categoryEntity is Category category)
                    {
                        category.Name ??= updateCategoryCommand.Name;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unsupported Request Type");
            }
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}


