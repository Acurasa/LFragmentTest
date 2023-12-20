using Application;
using Application.Commands;
using AutoMapper;
using Model.Models;
using Persistence;
namespace WebApi.Models
{
    public class CreateFragmentDto : IMapWith<CreateFragmentCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Tag_Id { get; set; }  
        public Guid Category_Id { get; set; }

            public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFragmentDto, CreateFragmentCommand>()
                .ForMember(fragmentCommand => fragmentCommand.Title,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Title))
                .ForMember(fragmentCommand => fragmentCommand.Content,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Content))
                .ForMember(fragmentCommand => fragmentCommand.Tag_Id,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Tag_Id))
                .ForMember(fragmentCommand => fragmentCommand.Category_Id,
                opt => opt.MapFrom(fragmentDto => fragmentDto.Category_Id));

        }
    }
}
