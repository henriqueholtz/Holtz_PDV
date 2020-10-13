
using AutoMapper;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;

namespace Holtz_PDV.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Estado, EstadoFromViewModel>().ReverseMap();
            CreateMap<Cidade, CidadeFromViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteFromViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoFromViewModel>().ReverseMap();
            CreateMap<Marca, MarcaFromViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoFromViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoFromViewModel>();
        }
    }
}
