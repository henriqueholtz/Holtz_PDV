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
            Cliente c1 = new Cliente() { CliCod = 1, CliRaz = "João Silva", CliNomFan = "", CliEnd = "Rua X", CliCpfCnpj = "123.456.789-08" };
            Cliente c2 = new Cliente() { CliCod = 2, CliRaz = "Bruno Pereira", CliNomFan = "", CliEnd = "Rua Y", CliCpfCnpj = "323.336.719-01" };
            Cliente c3 = new Cliente() { CliCod = 3, CliRaz = "Bruna Carol", CliNomFan = "", CliEnd = "Rua Z", CliCpfCnpj = "421.006.129-02" };
        }
    }
}
