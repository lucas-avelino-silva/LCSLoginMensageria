using AutoMapper;

namespace Application.Mapper
{
    public partial class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            LoginMapper();
        }
    }
}