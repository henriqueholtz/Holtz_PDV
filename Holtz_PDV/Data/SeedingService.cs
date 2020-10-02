using Holtz_PDV.Models;
using Holtz_PDV.Models.Enums;
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
        //public readonly IEFCore _repo;
        public SeedingService(Holtz_PDVContext context/*, IEFCore repo*/)
        {
            _context = context;
            //_repo = repo;
        }

        public void Seed()
        {


            //Estado e1 = new Estado() { EstNom = "PARANÁ", EstUf = UF.PR };
            //Estado e2 = new Estado() { EstNom = "SANTA CATARINA", EstUf = UF.SC };
            //Estado e3 = new Estado() { EstNom = "RIO GRANDE DO SUL", EstUf = UF.RS };
            //Estado e4 = new Estado() { EstNom = "SÃO PAULO", EstUf = UF.SP };
            //Estado e5 = new Estado() { EstNom = "MATO GROSSO", EstUf = UF.MT };
            //Estado e6 = new Estado() { EstNom = "MATO GROSSO DO SUL", EstUf = UF.MS };
            //Estado e7 = new Estado() { EstNom = "MINAS GERAIS", EstUf = UF.MG };
            //Estado e8 = new Estado() { EstNom = "RIO DE JANEIRO", EstUf = UF.RJ };

            //_repo.Add(e1);

            //_repo.Add(new Estado() { EstNom = "PARANÁ", EstUf = UF.PR });
            //_repo.Add(new Estado() { EstNom = "SANTA CATARINA", EstUf = UF.SC });
            //_repo.Add(new Estado() { EstNom = "RIO GRANDE DO SUL", EstUf = UF.RS });
            //_repo.Add(new Estado() { EstNom = "SÃO PAULO", EstUf = UF.SP });
            //_repo.Add(new Estado() { EstNom = "MATO GROSSO", EstUf = UF.MT });
            //_repo.Add(new Estado() { EstNom = "MATO GROSSO DO SUL", EstUf = UF.MS });
            //_repo.Add(new Estado() { EstNom = "MINAS GERAIS", EstUf = UF.MG });
            //_repo.Add(new Estado() { EstNom = "RIO DE JANEIRO", EstUf = UF.RJ });

            //_repo.Add(new Cidade() { CidNom = "MARIPÁ", CidIBGE = 4115358, EstadoEstCod = 0 });
            //_repo.Add(new Cidade() { CidNom = "PALOTINA", CidIBGE = 4117909, EstadoEstCod = 0 });
            //_repo.Add(new Cidade() { CidNom = "RIO DE JANEIRO", CidIBGE = 3304557, EstadoEstCod = 0 });
            //_repo.Add(new Cidade() { CidNom = "ITAQUIRAI", CidIBGE = 5004601, EstadoEstCod = 0 });
            //_repo.Add(new Cidade() { CidNom = "DOURADOS", CidIBGE = 5003702, EstadoEstCod = 0 });
            //_repo.Add(new Cidade() { CidNom = "SCHROEDER", CidIBGE = 4217402, EstadoEstCod = 0 });


            //_repo.SaveChangeAsync();

            if (_context.Estados.Any() || _context.Cidades.Any())
            {
                return;
            }

            //Estados
            Estado e1 = new Estado(0, "PARANÁ", UF.PR);
            Estado e2 = new Estado(0, "SANTA CATARINA", UF.SC );
            Estado e3 = new Estado(0, "RIO GRANDE DO SUL",  UF.RS );
            Estado e4 = new Estado(0, "SÃO PAULO", UF.SP );
            Estado e5 = new Estado(0, "MATO GROSSO",  UF.MT );
            Estado e6 = new Estado(0, "MATO GROSSO DO SUL",  UF.MS );
            Estado e7 = new Estado(0, "MINAS GERAIS", UF.MG );
            Estado e8 = new Estado(0, "RIO DE JANEIRO", UF.RJ );

            //Estado e1 = new Estado() { EstCod = 1, EstNom = "PARANÁ", EstUf = UF.PR };
            //Estado e2 = new Estado() { EstNom = "SANTA CATARINA", EstUf = UF.SC };
            //Estado e3 = new Estado() { EstNom = "RIO GRANDE DO SUL", EstUf = UF.RS };
            //Estado e4 = new Estado() { EstNom = "SÃO PAULO", EstUf = UF.SP };
            //Estado e5 = new Estado() { EstNom = "MATO GROSSO", EstUf = UF.MT };
            //Estado e6 = new Estado() { EstNom = "MATO GROSSO DO SUL", EstUf = UF.MS };
            //Estado e7 = new Estado() { EstNom = "MINAS GERAIS", EstUf = UF.MG };
            //Estado e8 = new Estado() { EstNom = "RIO DE JANEIRO", EstUf = UF.RJ };
            //}

            //if (!_context.Cidades.Any())
            //{
            //    //Cidades
            Cidade cd1 = new Cidade(0, "PALOTINA", 0 );
            Cidade cd2 = new Cidade(0, "MARIPÁ", 0 );
            Cidade cd3 = new Cidade(0, "RIO DE JANEIRO", 0 );
            Cidade cd4 = new Cidade(0, "ITAQUIRAI", 0 );
            Cidade cd5 = new Cidade(0, "DOURADOS", 0 );
            Cidade cd6 = new Cidade(0, "SCHROEDER", 0 );

            _context.Estados.AddRange(e1, e2, e3, e4, e5, e6, e7, e8);
            _context.Cidades.AddRange(cd1, cd2, cd3, cd4, cd5, cd6);
            _context.SaveChangesAsync();
            //}

            //if (!_context.Clientes.Any())
            //{
            //    //Clientes
            //    Cliente c1 = new Cliente() { CliRaz = "João Silva", CliNomFan = "", CliCpfCnpj = "123.456.789-08", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA A", CidadeCidCod = 0 };
            //    Cliente c2 = new Cliente() { CliRaz = "Bruno Pereira", CliNomFan = "", CliCpfCnpj = "323.336.719-01", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA B", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0 };
            //    Cliente c3 = new Cliente() { CliRaz = "Bruna Carol", CliNomFan = "", CliCpfCnpj = "421.006.129-02", CliTip = Tipo_Pessoa.FÍSICA, CliBai = "BAIRRO A", CliRua = "RUA C", CliSts = Status_AtivoInativo.INATIVO, CidadeCidCod = 0 };
            //    Cliente c4 = new Cliente() { CliRaz = "JASPI SISTEMAS", CliNomFan = "JASPI", CliCpfCnpj = "81.286.951/0001-05", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO D", CliRua = "RUA D", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0 };
            //    Cliente c5 = new Cliente() { CliRaz = "LIVRARIA A ESTUNDATIL", CliNomFan = "A ESTUNDATIL", CliCpfCnpj = "12.121.423/0001-45", CliTip = Tipo_Pessoa.JURÍDICA, CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0 };
            //    Cliente c6 = new Cliente() { CliRaz = "Michel Oscar", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0, CliCpfCnpj = "123.456.789-00", CliTip = Tipo_Pessoa.FÍSICA };
            //    Cliente c7 = new Cliente() { CliRaz = "Miguel Junior", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0, CliCpfCnpj = "451.261.411-10", CliTip = Tipo_Pessoa.FÍSICA };
            //    Cliente c8 = new Cliente() { CliRaz = "Larissa Dilkin", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0, CliCpfCnpj = "534.456.322-70", CliTip = Tipo_Pessoa.FÍSICA };
            //    Cliente c9 = new Cliente() { CliRaz = "Henrique Holtz", CliSts = Status_AtivoInativo.ATIVO, CidadeCidCod = 0, CliCpfCnpj = "123.652.666-02", CliTip = Tipo_Pessoa.FÍSICA };
            //    _context.Clientes.AddRange(c1, c2, c3, c4, c5, c6, c7, c8, c9);
            //}

            //if (!_context.Produtos.Any())
            //{
            //    //Produtos
            //    Produto p1 = new Produto { ProNom = "Notebook i3", ProVlrCus = 1500, ProVlrVen = 1800 };
            //    Produto p2 = new Produto { ProNom = "PenDrive 8gb", ProVlrCus = 25, ProVlrVen = 30 };
            //    Produto p3 = new Produto { ProNom = "Monitor 19'", ProVlrCus = 420, ProVlrVen = 510 };
            //    Produto p4 = new Produto { ProNom = "Memória RAM DDR4 4gb", ProVlrCus = 250, ProVlrVen = 350 };
            //    Produto p5 = new Produto { ProNom = "Mouse USB", ProVlrCus = 25, ProVlrVen = 32 };
            //    Produto p6 = new Produto { ProNom = "Mouse USB s/ Fio", ProVlrCus = 45, ProVlrVen = 56 };
            //    Produto p7 = new Produto { ProNom = "Teclado USB", ProVlrCus = 40, ProVlrVen = 50 };
            //    Produto p8 = new Produto { ProNom = "Teclado USB s/ Fio", ProVlrCus = 75, ProVlrVen = 88 };
            //    Produto p9 = new Produto { ProNom = "Processador i3", ProVlrCus = 750, ProVlrVen = 880 };
            //    Produto p10 = new Produto { ProNom = "Processador i5", ProVlrCus = 1050, ProVlrVen = 1320 };
            //    _context.Produtos.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            //}

            //if (!_context.Marcas.Any())
            //{
            //    //Marcas
            //    Marca m1 = new Marca { MarNom = "Dell" };
            //    Marca m2 = new Marca { MarNom = "Acer" };
            //    Marca m3 = new Marca { MarNom = "Kingston" };
            //    Marca m4 = new Marca { MarNom = "Positivo" };
            //    _context.Marcas.AddRange(m1, m2, m3, m4);
            //}
            //_context.SaveChangesAsync();
        }

    }
}
