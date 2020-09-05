using Holtz_PDV.Models;
using Holtz_PDV.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Data
{
    public class SeedingService
    {
        private readonly Holtz_PDVContext _context;
        public SeedingService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Clientes.Any() || _context.Estados.Any() || _context.Cidades.Any() || _context.Produtos.Any()) //verifica se contém elementos
            {
                return; //DB has been seeded
            }

            //Estados
            Estado e1 = new Estado() { EstCod = 1, EstNom = "PARANÁ", EstUf = UF.PR };
            Estado e2 = new Estado() { EstCod = 2, EstNom = "SANTA CATARINA", EstUf = UF.SC };
            Estado e3 = new Estado() { EstCod = 3, EstNom = "RIO GRANDE DO SUL", EstUf = UF.RS };
            Estado e4 = new Estado() { EstCod = 4, EstNom = "SÃO PAULO", EstUf = UF.SP };
            Estado e5 = new Estado() { EstCod = 5, EstNom = "MATO GROSSO", EstUf = UF.MT };
            Estado e6 = new Estado() { EstCod = 6, EstNom = "MATO GROSSO DO SUL", EstUf = UF.MS };
            Estado e7 = new Estado() { EstCod = 7, EstNom = "MINAS GERAIS", EstUf = UF.MG };
            Estado e8 = new Estado() { EstCod = 8, EstNom = "RIO DE JANEIRO", EstUf = UF.RJ };

            //Cidades
            Cidade cd1 = new Cidade() { CidCod = 1, CidNom = "PALOTINA", CidIBGE = 4117909, EstCod = 1 };
            Cidade cd2 = new Cidade() { CidCod = 2, CidNom = "MARIPÁ", CidIBGE = 4115358, EstCod = 1 };
            Cidade cd3 = new Cidade() { CidCod = 3, CidNom = "RIO DE JANEIRO", CidIBGE = 3304557, EstCod = 8 };
            Cidade cd4 = new Cidade() { CidCod = 4, CidNom = "ITAQUIRAI", CidIBGE = 5004601, EstCod = 6 };
            Cidade cd5 = new Cidade() { CidCod = 5, CidNom = "DOURADOS", CidIBGE = 5003702, EstCod = 6 };
            Cidade cd6 = new Cidade() { CidCod = 6, CidNom = "SCHROEDER", CidIBGE = 4217402, EstCod = 2 };

            //Clientes
            Cliente c1 = new Cliente() { CliCod = 1, CliRaz = "João Silva", CliNomFan = "", CliCpfCnpj = "123.456.789-08", CliBai = "BAIRRO A", CliRua = "RUA A", CidCod = 1 };
            Cliente c2 = new Cliente() { CliCod = 2, CliRaz = "Bruno Pereira", CliNomFan = "", CliCpfCnpj = "323.336.719-01", CliBai = "BAIRRO A", CliRua = "RUA B", CliSts = Status_AtivoInativo.ATIVO, CidCod = 2 };
            Cliente c3 = new Cliente() { CliCod = 3, CliRaz = "Bruna Carol", CliNomFan = "", CliCpfCnpj = "421.006.129-02", CliBai = "BAIRRO A", CliRua = "RUA C", CliSts = Status_AtivoInativo.INATIVO, CidCod = 3 };
            Cliente c4 = new Cliente() { CliCod = 4, CliRaz = "JASPI SISTEMAS", CliNomFan = "JASPI", CliCpfCnpj = "81.286.951/0001-05", CliBai = "BAIRRO D", CliRua = "RUA D", CliSts = Status_AtivoInativo.ATIVO, CidCod = 4 };
            Cliente c5 = new Cliente() { CliCod = 5, CliRaz = "LIVRARIA A ESTUNDATIL", CliNomFan = "A ESTUNDATIL", CliCpfCnpj = "12.121.423/0001-45", CliBai = "BAIRRO E", CliRua = "RUA E", CliSts = Status_AtivoInativo.ATIVO, CidCod = 4 };

            //Produtos
            Produto p1 = new Produto { ProCod = 1, ProNom = "Notebook i3", ProVlrCus = 1500, ProVlrVen = 1800 };
            Produto p2 = new Produto { ProCod = 2, ProNom = "PenDrive 8gb", ProVlrCus = 25, ProVlrVen = 30 };
            Produto p3 = new Produto { ProCod = 3, ProNom = "Monitor 19'", ProVlrCus = 420, ProVlrVen = 510 };
            Produto p4 = new Produto { ProCod = 4, ProNom = "Memória RAM DDR4 4gb", ProVlrCus = 250, ProVlrVen = 350 };
            Produto p5 = new Produto { ProCod = 5, ProNom = "Mouse USB", ProVlrCus = 25, ProVlrVen = 32 };
            Produto p6 = new Produto { ProCod = 6, ProNom = "Mouse USB s/ Fio", ProVlrCus = 45, ProVlrVen = 56 };
            Produto p7 = new Produto { ProCod = 7, ProNom = "Teclado USB", ProVlrCus = 40, ProVlrVen = 50 };
            Produto p8 = new Produto { ProCod = 8, ProNom = "Teclado USB s/ Fio", ProVlrCus = 75, ProVlrVen = 88 };
            Produto p9 = new Produto { ProCod = 9, ProNom = "Processador i3", ProVlrCus = 750, ProVlrVen = 880 };
            Produto p10 = new Produto { ProCod = 10, ProNom = "Processador i5", ProVlrCus = 1050, ProVlrVen = 1320 };

            //Marcas
            Marca m1 = new Marca { MarCod = 1, MarNom = "Dell" };
            Marca m2 = new Marca { MarCod = 2, MarNom = "Acer" };
            Marca m3 = new Marca { MarCod = 3, MarNom = "Kingston" };
            Marca m4 = new Marca { MarCod = 4, MarNom = "Positivo" };


            _context.Estados.AddRange(e1, e2, e3, e4, e5, e6, e7, e8);
            _context.Cidades.AddRange(cd1, cd2, cd3, cd4, cd5, cd6);
            _context.Clientes.AddRange(c1, c2, c3, c4, c5);
            _context.Produtos.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            _context.Marcas.AddRange(m1, m2, m3, m4);

            _context.SaveChanges();
        }
    }
}
