using Application.ViewModel.Entity;
using AutoMapper;
using Domain.Model;

namespace Application.Mapper
{
    public partial class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            //LoginMapper();

            CreateMap<LoginCadastroViewModel, LoginCadastroDomain>().ReverseMap();

            CreateMap<AtivarContaViewModel, AtivarContaDomain>().ReverseMap();
        }

    }
}