using Application;
using Application.Commands;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UpdateFragmentDto : IMapWith<UpdateFragmentCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public Guid? Category_Id { get; set; }
        public string[]? Tag_Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFragmentDto, UpdateFragmentCommand>()
                .ForMember(fragmentCommand => fragmentCommand.Title,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Title))
                .ForMember(fragmentCommand => fragmentCommand.Content,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Content))
                .ForMember(fragmentCommand => fragmentCommand.Tag_Id,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Tag_Id))
                .ForMember(fragmentCommand => fragmentCommand.Category_Id,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Category_Id))
                .ForMember(fragmentCommand => fragmentCommand.Id,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Id));

        }
    }
}
