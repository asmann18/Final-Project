using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce
{
    public class CommentAutoMapper:Profile
    {
        public CommentAutoMapper()
        {
            CreateMap<Comment, CommentGetDto>().ReverseMap();
            CreateMap<Comment, CommentPostDto>().ReverseMap();
            CreateMap<Comment, CommentRelationDto>().ReverseMap();

            CreateMap<CommentGetDto, CommentRelationDto>().ReverseMap();

        }
    }
}
