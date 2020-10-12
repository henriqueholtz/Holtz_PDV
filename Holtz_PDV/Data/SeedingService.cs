using Holtz_PDV.Models;
using Holtz_PDV.Models.Enums;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Data
{
    public class SeedingService
    {
        private readonly Holtz_PDVContext _context;
        private readonly IEFCore _repo;

        public SeedingService(Holtz_PDVContext context, IEFCore repo)
        {
            _context = context;
            _repo = repo;
        }

        public void Seed()
        {
            if (!_context.Estados.Any())
            { //Estados
                Estado e1 = new Estado() { EstNom = "PARANÁ", EstUf = UF.PR };
                Estado e2 = new Estado() { EstNom = "SANTA CATARINA", EstUf = UF.SC };
                Estado e3 = new Estado() { EstNom = "RIO GRANDE DO SUL", EstUf = UF.RS };
                Estado e4 = new Estado() { EstNom = "SÃO PAULO", EstUf = UF.SP };
                Estado e5 = new Estado() { EstNom = "MATO GROSSO", EstUf = UF.MT };
                Estado e6 = new Estado() { EstNom = "MATO GROSSO DO SUL", EstUf = UF.MS };
                Estado e7 = new Estado() { EstNom = "MINAS GERAIS", EstUf = UF.MG };
                Estado e8 = new Estado() { EstNom = "RIO DE JANEIRO", EstUf = UF.RJ };
                //_repo.AddRange(new List<Estado>() { e1, e2, e3, e4, e5, e6, e7, e8 });
                //_repo.SaveChangeAsync();
                _context.Estados.AddRange(e1, e2, e3, e4, e5, e6, e7, e8);
            }

            if (!_context.Cidades.Any())
            {//Cidades
                _context.SaveChanges(); //pq Cidade depende dos estados
                Cidade cd1 = new Cidade() {CidNom = "PALOTINA", EstadoEstCod =  1};
                Cidade cd2 = new Cidade() {CidNom = "MARIPÁ", EstadoEstCod =  1};
                Cidade cd3 = new Cidade() { CidNom = "RIO DE JANEIRO", EstadoEstCod =  8};
                Cidade cd4 = new Cidade() {CidNom = "ITAQUIRAI", EstadoEstCod =  6};
                Cidade cd5 = new Cidade() {CidNom = "DOURADOS", EstadoEstCod =  5};
                Cidade cd6 = new Cidade() {CidNom = "SCHROEDER", EstadoEstCod =  2};
                Cidade cd7 = new Cidade() { CidNom = "CURITIBA", EstadoEstCod = 1 };
                Cidade cd8 = new Cidade() { CidNom = "TOLEDO", EstadoEstCod = 1 };
                Cidade cd9 = new Cidade() { CidNom = "CASCAVEL", EstadoEstCod = 1 };
                Cidade cd10 = new Cidade() { CidNom = "JOENVILE", EstadoEstCod = 2 };
                Cidade cd11 = new Cidade() { CidNom = "JARAGUA", EstadoEstCod = 2 };
                Cidade cd12 = new Cidade() { CidNom = "FLORIANÓPOLIS", EstadoEstCod = 2 };
                _context.Cidades.AddRange(cd1, cd2, cd3, cd4, cd5, cd6, cd7, cd8, cd9, cd10, cd11, cd12);
            }

            if (!_context.Clientes.Any())
            {//Clientes
                _context.SaveChanges(); //pq Clientes depende das Cidades
                Cliente c1 = new Cliente() { CliRaz = "João Silva", CliNomFan = "", CliCpfCnpj = "123.456.789-08", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA A", CidadeCidCod = 1 };
                Cliente c2 = new Cliente() { CliRaz = "Bruno Pereira", CliNomFan = "", CliCpfCnpj = "323.336.719-01", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA B", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2 };
                Cliente c3 = new Cliente() { CliRaz = "Bruna Carol", CliNomFan = "", CliCpfCnpj = "421.006.129-02", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA C", CliSts = Status_AtivoInativo.INATIVO, CidadeCidCod = 3 };
                Cliente c4 = new Cliente() { CliRaz = "JASPI SISTEMAS", CliNomFan = "JASPI", CliCpfCnpj = "81.286.951/0001-05", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO D", CliRua = "RUA D", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4 };
                Cliente c5 = new Cliente() { CliRaz = "LIVRARIA A ESTUNDATIL", CliNomFan = "A ESTUNDATIL", CliCpfCnpj = "12.121.423/0001-45", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 5 };
                Cliente c6 = new Cliente() { CliRaz = "Michel Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 6, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c7 = new Cliente() { CliRaz = "Miguel Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c8 = new Cliente() { CliRaz = "Larissa Dilkin", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 3, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c9 = new Cliente() { CliRaz = "Henrique Holtz", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c10 = new Cliente() { CliRaz = "EMPRESA X", CliNomFan = "X FANTASIA", CliCpfCnpj = "12.121.423/0001-45", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 5 };
                Cliente c11 = new Cliente() { CliRaz = "Maicol Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 6, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c12 = new Cliente() { CliRaz = "Miquelito Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c13 = new Cliente() { CliRaz = "Leticia Dilkin", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 3, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c14 = new Cliente() { CliRaz = "Ilson Holtz", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c15 = new Cliente() { CliRaz = "EMPRESA Y", CliNomFan = "Y FANTASIA", CliCpfCnpj = "12.121.423/0001-45", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 5 };
                Cliente c16 = new Cliente() { CliRaz = "Vennon Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 6, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c17 = new Cliente() { CliRaz = "Mateus Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c18 = new Cliente() { CliRaz = "Loivo Dilkin", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 3, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c19 = new Cliente() { CliRaz = "Nelsi Holtz", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c20 = new Cliente() { CliRaz = "LIVRARIA A ESTUNDATIL", CliNomFan = "A ESTUNDATIL", CliCpfCnpj = "12.121.423/0001-45", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 5 };
                Cliente c21 = new Cliente() { CliRaz = "Jeovane Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 6, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c22 = new Cliente() { CliRaz = "Jean Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c23 = new Cliente() { CliRaz = "Marcilene Dilkin", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 3, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c24 = new Cliente() { CliRaz = "Jhonatan Holtz", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c25 = new Cliente() { CliRaz = "Osvino Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 6, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c26 = new Cliente() { CliRaz = "Marcio Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 4, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c27 = new Cliente() { CliRaz = "Alisson Souza", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 3, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
                Cliente c28 = new Cliente() { CliRaz = "Jonatan Store", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 2, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
                _context.Clientes.AddRange(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20 , c21, c22, c23,c24,c25,c26,c27,c28);
            }

            if (!_context.Produtos.Any())
            {
                //Produtos
                Produto p1 = new Produto { ProNom = "Notebook i3", ProVlrCus = 1500, ProVlrVen = 1800 };
                Produto p2 = new Produto { ProNom = "PenDrive 8gb", ProVlrCus = 25, ProVlrVen = 30 };
                Produto p3 = new Produto { ProNom = "Monitor 19'", ProVlrCus = 420, ProVlrVen = 510 };
                Produto p4 = new Produto { ProNom = "Memória RAM DDR4 4gb", ProVlrCus = 250, ProVlrVen = 350 };
                Produto p5 = new Produto { ProNom = "Mouse USB", ProVlrCus = 25, ProVlrVen = 32 };
                Produto p6 = new Produto { ProNom = "Mouse USB s/ Fio", ProVlrCus = 45, ProVlrVen = 56 };
                Produto p7 = new Produto { ProNom = "Teclado USB", ProVlrCus = 40, ProVlrVen = 50 };
                Produto p8 = new Produto { ProNom = "Teclado USB s/ Fio", ProVlrCus = 75, ProVlrVen = 88 };
                Produto p9 = new Produto { ProNom = "Processador i3", ProVlrCus = 750, ProVlrVen = 880 };
                Produto p10 = new Produto { ProNom = "Processador i5", ProVlrCus = 1050, ProVlrVen = 1320 };
                Produto p11 = new Produto { ProNom = "Processador i3-4", ProVlrCus = 750, ProVlrVen = 880 };
                Produto p12 = new Produto { ProNom = "Processador i5-4", ProVlrCus = 1050, ProVlrVen = 1320 };
                Produto p13 = new Produto { ProNom = "Processador i3-5", ProVlrCus = 750, ProVlrVen = 880 };
                Produto p14 = new Produto { ProNom = "Processador i5-5", ProVlrCus = 1050, ProVlrVen = 1320 };
                Produto p15 = new Produto { ProNom = "Processador i3-6", ProVlrCus = 750, ProVlrVen = 880 };
                Produto p16 = new Produto { ProNom = "Processador i5-6", ProVlrCus = 1050, ProVlrVen = 1320 };
                _context.Produtos.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
                //_context.SaveChanges();
                //_repo.AddRange(new List<Produto>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });
                //_repo.SaveChange();
                }

            if (!_context.Marcas.Any())
            {
                //Marcas
                Marca m1 = new Marca { MarNom = "Dell" };
                Marca m2 = new Marca { MarNom = "Acer" };
                Marca m3 = new Marca { MarNom = "Kingston" };
                Marca m4 = new Marca { MarNom = "Positivo" };
                Marca m5 = new Marca { MarNom = "Fisher" };
                Marca m6 = new Marca { MarNom = "Faber" };
                Marca m7 = new Marca { MarNom = "AOC" };
                Marca m8 = new Marca { MarNom = "OMO" };
                Marca m9 = new Marca { MarNom = "XIAOMI" };
                Marca m10 = new Marca { MarNom = "IPHONE" };
                Marca m11 = new Marca { MarNom = "SAMSUNG" };
                Marca m12 = new Marca { MarNom = "IPÊ" };
                _context.Marcas.AddRange(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12);
                //_context.SaveChanges();
                //_repo.AddRange(new List<Marca>() { m1, m2, m3, m4 });
                //_repo.SaveChange();
            }

            if (!_context.Pedidos.Any())
            {
                Pedido p1 = new Pedido  { PedCliCod = 1,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p2 = new Pedido  { PedCliCod = 2,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.FECHADO };
                Pedido p3 = new Pedido  { PedCliCod = 3,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p4 = new Pedido  { PedCliCod = 4,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p5 = new Pedido  { PedCliCod = 5,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p6 = new Pedido  { PedCliCod = 6,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.FECHADO };
                Pedido p7 = new Pedido  { PedCliCod = 7,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p8 = new Pedido  { PedCliCod = 8,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p9 = new Pedido  { PedCliCod = 9,  PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.FECHADO };
                Pedido p10 = new Pedido { PedCliCod = 10, PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p11 = new Pedido { PedCliCod = 11, PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.ABERTO };
                Pedido p12 = new Pedido { PedCliCod = 12, PedDtaEms = DateTime.Now, PedDtaFat = DateTime.Now, PedSts = Status_Pedido.FECHADO };
                _context.Pedidos.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            }


                _context.SaveChanges();
            //_repo.SaveChange();
        }

    }
}
