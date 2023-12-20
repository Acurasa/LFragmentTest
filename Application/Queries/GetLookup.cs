using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using AutoMapper;
namespace Application.Queries
{
    public class GetUserLookup : IMapWith<User>, IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool? IsOnline { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserLookup>()
            .ForMember(userDto => userDto.Id,
            opt => opt.MapFrom(user => user.Id))
            .ForMember(userDto => userDto.Username,
            opt => opt.MapFrom(user => user.Username))
            .ForMember(userDto => userDto.IsOnline,
            opt => opt.MapFrom(user => user.IsOnline));
        }
    }


    public class GetFragmentLookup : IMapWith<Fragment>, IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? Content { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fragment, GetFragmentLookup>()
            .ForMember(fragmentDto => fragmentDto.Id,
            opt => opt.MapFrom(fragment => fragment.Id))
            .ForMember(fragmentDto => fragmentDto.Title,
            opt => opt.MapFrom(fragment => fragment.Title))
            .ForMember(fragmentDto => fragmentDto.CreatedDate,
            opt => opt.MapFrom(fragment => fragment.CreatedDate))
            .ForMember(fragmentDto => fragmentDto.Content,
            opt => opt.MapFrom(fragment => fragment.Content));

        }
    }

    public class GetCategoryLookup : IMapWith<Category>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryLookup>()
            .ForMember(categoryDto => categoryDto.Id,
            opt => opt.MapFrom(category => category.Id))
            .ForMember(categoryDto => categoryDto.Name,
            opt => opt.MapFrom(category => category.Name));
        }
    }
    public class GetRoleLookup : IMapWith<Role>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryLookup>()
            .ForMember(roleDto => roleDto.Id,
            opt => opt.MapFrom(role => role.Id))
              .ForMember(roleDto => roleDto.Name,
            opt => opt.MapFrom(role => role.Name));
        }
    }

    public class GetTagLookup : IMapWith<Tag>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryLookup>()
            .ForMember(tagDto => tagDto.Id,
            opt => opt.MapFrom(tag => tag.Id))
              .ForMember(tagDto => tagDto.Name,
            opt => opt.MapFrom(tag => tag.Name));
        }
    }

}
