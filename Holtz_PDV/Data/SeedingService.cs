using Holtz_PDV.Models;
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
            if(_context.Clientes.Any()) //verifica se contém elementos
            {
                return; //DB has been seeded
            }
            //Clientes
            Cliente c1 = new Cliente() { CliCod = 1, CliRaz = "João Silva", CliNomFan = "", CliEnd = "Rua X", CliCpfCnpj = "123.456.789-08" };
            Cliente c2 = new Cliente() { CliCod = 2, CliRaz = "Bruno Pereira", CliNomFan = "", CliEnd = "Rua Y", CliCpfCnpj = "323.336.719-01" };
            Cliente c3 = new Cliente() { CliCod = 3, CliRaz = "Bruna Carol", CliNomFan = "", CliEnd = "Rua Z", CliCpfCnpj = "421.006.129-02" };
            Cliente c4 = new Cliente() { CliCod = 3, CliRaz = "JASPI SISTEMAS", CliNomFan = "JASPI", CliEnd = "Rua Monteiro Lobato", CliCpfCnpj = "81.286.951/0001-05" };
            Cliente c5 = new Cliente() { CliCod = 3, CliRaz = "LIVRARIA A ESTUNDATIL", CliNomFan = "A ESTUNDATIL", CliEnd = "Avenida", CliCpfCnpj = "12.121.423/0001-45" };


            _context.Clientes.AddRange(c1, c2, c3, c4, c5);

            _context.SaveChanges();
        }
    }
}
