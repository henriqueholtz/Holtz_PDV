using Holtz_PDV.Models;
using Holtz_PDV.Models.Enums;
using Holtz_PDV.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Services
{
    public class ClienteService
    {
        private readonly Holtz_PDVContext _context;
        public ClienteService(Holtz_PDVContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Clientes.Include(inc => inc.Cidade).OrderBy(x => x.CliRaz).ToListAsync();
        }
        public IOrderedQueryable<Cliente> FindAllQueryable()
        {
            return _context.Clientes.Include(inc => inc.Cidade).AsNoTracking().OrderBy(x => x.CliRaz);
        }

        public async Task<Cliente> FindByCodAsync(int cod)
        {
            return await _context.Clientes.Include(obj => obj.Cidade).FirstOrDefaultAsync(x => x.CliCod == cod);
        }

        public async Task InsertAsync(Cliente obj)
        { //INSERT
            try
            {
                Format(obj); //UpperCase, and Format CPF/CNPJ
                obj.CidadeCidCod = obj.Cidade.CidCod;
                obj.Cidade = null; // para o EFCore não tentar inserir a cidade NOVAMENTE... 
                _context.Clientes.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        
        public async Task RemoveAsync(int cod)
        { //REMOVE
            try
            {
                var obj = await _context.Clientes.FindAsync(cod);
                _context.Clientes.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir este Cliente.");
            }
        }

        public async Task UpdateAsync(Cliente obj)
        { //UPDATE
            bool hasAny = await _context.Clientes.AnyAsync(x => x.CliCod == obj.CliCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {

                Format(obj); //UpperCase, and Format CPF/CNPJ
                //obj.Cidade = null; // para o EFCore não tentar atualizar a cidade tambem... 
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        private void Format_CPF_CNPJ(Cliente cliente)
        {
            //retornaSoNumeros
            if (cliente.CliTip == Tipo_Pessoa.FÍSICA)
            {
                //formataCPF
                string Cpf = cliente.CliCpfCnpj;
                Cpf = String.Join("", System.Text.RegularExpressions.Regex.Split(Cpf, @"[^\d]"));
                Cpf = Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00");
                cliente.CliCpfCnpj = Cpf;
            }
            else
            {
                //formata CNPJ
                string Cnpj = cliente.CliCpfCnpj;
                Cnpj = String.Join("", System.Text.RegularExpressions.Regex.Split(Cnpj, @"[^\d]"));
                Cnpj = Convert.ToUInt64(Cnpj).ToString(@"00\.000\.000\/0000\-00");
                cliente.CliCpfCnpj = Cnpj;
            }

        }

        private void Format(Cliente cliente)
        {
            Format_CPF_CNPJ(cliente);
            cliente.CliBai    = (cliente.CliBai == null)    ? "" : cliente.CliBai.ToUpper();
            cliente.CliNomFan = (cliente.CliNomFan == null) ? "" : cliente.CliNomFan.ToUpper();
            cliente.CliRaz    = (cliente.CliRaz == null)    ? "" : cliente.CliRaz.ToUpper();
            cliente.CliRua    = (cliente.CliRua == null)    ? "" : cliente.CliRua.ToUpper();
        }
    }
}
