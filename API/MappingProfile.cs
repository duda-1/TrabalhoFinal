using AutoMapper;
using TrabalhoFinal._1_Service.DTO;
using TrabalhoFinal._3_Entidade;
using TrabalhoFinal._3_Entidade.DTO;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLivroDTO, Livro>().ReverseMap();
            CreateMap<CreateClienteDTO, Cliente>().ReverseMap();
            CreateMap<CreateCarrinhoDTO, Carrinho>().ReverseMap();
        }
    }
}
