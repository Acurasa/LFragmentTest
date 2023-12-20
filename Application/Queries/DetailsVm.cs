using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model.Models;
namespace Application.Queries
{
    public class UserDetailsVm : IMapWith<User>, IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[]? Avatar { get; set; }
        public bool? IsOnline { get; set; }
        public int? Role_Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>().ForMember(userVm => userVm.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Username,
                opt => opt.MapFrom(user => user.Username))
                .ForMember(userVm => userVm.PasswordHash,
                opt => opt.MapFrom(user => user.PasswordHash))
                .ForMember(userVm => userVm.CreatedDate,
                opt => opt.MapFrom(user => user.CreatedDate))
                .ForMember(userVm => userVm.Email,
                opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.IsOnline,
                opt => opt.MapFrom(user => user.IsOnline))
                .ForMember(userVm => userVm.Role_Id,
                opt => opt.MapFrom(user => user.Role_Id))
                .ForMember(userVm => userVm.Avatar,
                opt => opt.MapFrom(user => user.Avatar));
        }
    }

    public class FragmentDetailsVm : IMapWith<Fragment>, IEntity
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime Expires { get; set; }
        public int? Alias { get; set; }
        public Guid User_Id { get; set; }
        public int? Category_Id { get; set; }
        public string[]? Tag_Id { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fragment, FragmentDetailsVm>().ForMember(fragmentVm => fragmentVm.Id,
                opt => opt.MapFrom(fragment => fragment.Id))
                .ForMember(fragmentVm => fragmentVm.Content,
                opt => opt.MapFrom(fragment => fragment.Content))
                .ForMember(fragmentVm => fragmentVm.User_Id,
                opt => opt.MapFrom(fragment => fragment.User_Id))
                .ForMember(fragmentVm => fragmentVm.CreatedDate,
                opt => opt.MapFrom(fragment => fragment.CreatedDate))
                .ForMember(fragmentVm => fragmentVm.Expires,
                opt => opt.MapFrom(fragment => fragment.Expires))
                .ForMember(fragmentVm => fragmentVm.Title,
                opt => opt.MapFrom(fragment => fragment.Title))
                .ForMember(fragmentVm => fragmentVm.Tag_Id,
                opt => opt.MapFrom(fragment => fragment.Tag_Id))
                .ForMember(fragmentVm => fragmentVm.UpdatedDate,
                opt => opt.MapFrom(fragment => fragment.UpdatedDate))
                .ForMember(fragmentVm => fragmentVm.Category_Id,
                opt => opt.MapFrom(fragment => fragment.Category_Id))
                .ForMember(fragmentVm => fragmentVm.Alias,
                opt => opt.MapFrom(fragment => fragment.Alias));

        }
    }

    public class CategoryDetailsVm : IMapWith<Category>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailsVm>()
                .ForMember(categoryVm => categoryVm.Id,
                opt => opt.MapFrom(category => category.Id))
                .ForMember(categoryVm => categoryVm.Id,
                opt => opt.MapFrom(category => category.Name));
        }
    }

    public class TagDetailsVm : IMapWith<Tag>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagDetailsVm>()
                .ForMember(tagVm => tagVm.Id,
                opt => opt.MapFrom(tag => tag.Id))
                .ForMember(tagVm => tagVm.Id,
                opt => opt.MapFrom(tag => tag.Name));
        }
    }
    public class RoleDetailsVm : IMapWith<Role>, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleDetailsVm>()
                .ForMember(roleVm => roleVm.Id,
                opt => opt.MapFrom(role => role.Id))
                .ForMember(roleVm => roleVm.Id,
                opt => opt.MapFrom(role => role.Name));
        }
    }
}
