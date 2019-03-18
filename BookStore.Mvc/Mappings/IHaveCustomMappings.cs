using AutoMapper;

namespace BookStore.Mvc.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}