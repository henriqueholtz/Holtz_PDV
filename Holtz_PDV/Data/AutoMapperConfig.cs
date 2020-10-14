﻿
using AutoMapper;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using System.Collections.Generic;
using X.PagedList;

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
        }
        //para PagedList.Mvc  https://stackoverflow.com/questions/26961860/using-automapper-with-pagedlist-mvc
    }
}
