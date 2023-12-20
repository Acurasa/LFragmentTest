using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
using Model.Models;

namespace Application.Queries
{
    public class GetDetailsQueryHandler<TRequest, TDetailsVm> : IRequestHandler<TRequest, TDetailsVm>
    where TRequest : IRequest<TDetailsVm>
    where TDetailsVm : class, new()
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetDetailsQueryHandler(IApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task NotFoundExceptionFactory(IEntity? entity , IEntity request )
        {
            if (entity == null || entity.Id != request.Id)
                throw new NotFoundException(nameof(request), request.Id);
        }
        public async Task<TDetailsVm> Handle(TRequest request, CancellationToken cancellationToken)
        {
            switch (request)
            {
                case GetUserDetailsQuery userDetailsQuery:
                    var userEntity = await _db.Users.FirstOrDefaultAsync(user => user.Id == userDetailsQuery.Id);
                    await NotFoundExceptionFactory(userEntity, userDetailsQuery);
                    return _mapper.Map<UserDetailsVm>(userEntity) as TDetailsVm ?? throw new Exception($"Mapping \"{nameof(userDetailsQuery)}\", failed");

                case GetFragmentDetailsQuery fragmentDetailsQuery:
                    var fragmentEntity = await _db.Fragments.FirstOrDefaultAsync(fragment => fragment.Id == fragmentDetailsQuery.Id);
                    await NotFoundExceptionFactory(fragmentEntity, fragmentDetailsQuery);
                    return _mapper.Map<FragmentDetailsVm>(fragmentEntity) as TDetailsVm ?? throw new Exception($"Mapping \"{nameof(fragmentDetailsQuery)}\", failed");

                case GetRoleDetailsQuery roleDetailsQuery:
                    var roleEntity = await _db.Roles.FirstOrDefaultAsync(role => role.Id == roleDetailsQuery.Id);
                    await NotFoundExceptionFactory(roleEntity, roleDetailsQuery);
                    return _mapper.Map<RoleDetailsVm>(roleEntity) as TDetailsVm ?? throw new Exception($"Mapping \"{nameof(roleDetailsQuery)}\", failed");

                case GetCategoryDetailsQuery categoryDetailsQuery:
                    var categoryEntity = await _db.Categories.FirstOrDefaultAsync(category => category.Id == categoryDetailsQuery.Id);
                    await NotFoundExceptionFactory(categoryEntity, categoryDetailsQuery);
                    return _mapper.Map<CategoryDetailsVm>(categoryEntity) as TDetailsVm ?? throw new Exception($"Mapping \"{nameof(categoryDetailsQuery)}\", failed");

                case GetTagDetailsQuery tagDetailsQuery:
                    var tagEntity = await _db.Tags.FirstOrDefaultAsync(categoryEntity => categoryEntity.Id == tagDetailsQuery.Id);
                    await NotFoundExceptionFactory(tagEntity, tagDetailsQuery);
                    return _mapper.Map<TagDetailsVm>(tagEntity) as TDetailsVm ?? throw new Exception("Mapping of Tag Failed");

                default: throw new Exception("Mapping Error, Non of the types are mapped");
                    
            }
        }
    }
}
