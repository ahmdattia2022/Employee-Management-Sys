using AutoMapper;
using WebApplication1.DAL.Entities;

namespace WebApplication1.BL.AutoMapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
