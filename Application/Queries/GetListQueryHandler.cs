using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Model.Models;
using Application.Exceptions;
using System.Reflection;

namespace Application.Queries
{
    public class GetListQueryHandler : IRequestHandler<IRequest<IVm>, IVm>
    {
        private readonly IApplicationDbContext _db;
        private readonly IApplicationDbContext _mapper;

        GetListQueryHandler(IApplicationDbContext db, IApplicationDbContext mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IVm> Handle(IRequest<IVm> request, CancellationToken cancellationToken)
        {
            switch (request) 
            {
                case GetFragmentByUserIdListQuery getFragmentByUserIdListQuery:
                    var fragmentsByIdQuery = await _db.Fragments
                        .Where(fragment => fragment.User_Id == getFragmentByUserIdListQuery.UserId)
                        .Select(fragment => new GetFragmentLookup
                        {
                            Id = fragment.Id,
                            CreatedDate = fragment.CreatedDate,
                            Title = fragment.Title,
                            Content = fragment.Content
                        }).ToListAsync();
                    return new GetFragmentsListVm {Fragment = fragmentsByIdQuery};
                case GetFragmentLookup getFragmentLookup:
                    var fragmentsQuery = await _db.Fragments
                        .Where(fragmentQuery => fragmentQuery.Id == getFragmentLookup.Id)
                        .Select(fragmentQuery => new GetFragmentLookup
                        {
                            Id = fragmentQuery.Id,
                            CreatedDate = fragmentQuery.CreatedDate,
                            Title = fragmentQuery.Title
                        }).ToListAsync();
                    return new GetFragmentsListVm { Fragment = fragmentsQuery };
                case GetUserListQuery getUserUserListQuery:
                    var usersQuery = await _db.Users
                        .Where(userQuery=> userQuery.Id == getUserUserListQuery.Id)
                        .Select(userQuery => new GetUserLookup
                        {
                            Username = userQuery.Username,
                            Id = userQuery.Id,
                            IsOnline = userQuery.IsOnline
                            
                        })
                        .ToListAsync();
                    return new GetUsersListVm { Users = usersQuery };
                case GetTagDetailsQuery getTagDetailsQuery:
                    var tagQuery = await _db.Tags
                        .Where(tagsQuery => tagsQuery.Id == getTagDetailsQuery.Id)
                        .Select(tagsQuery => new GetTagLookup
                        {
                            Id = tagsQuery.Id,
                            Name = tagsQuery.Name,
                        }
                        )
                        .ToListAsync();
                    return new GetTagListVm { Tags = tagQuery };

                default: throw new NotFoundException(nameof(request), 0);
            }
        }
    }
}
