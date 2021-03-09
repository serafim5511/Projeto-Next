using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Next.Models;

namespace ApiNext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosPessoaisController : ControllerBase
    {
        private readonly Context _context;

        public DadosPessoaisController(Context context)
        {
            _context = context;
        }

        // GET: api/DadosPessoais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosPessoais>>> GetDadosPessoais()
        {
            return await _context.DadosPessoais.ToListAsync();
        }

        // GET: api/DadosPessoais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DadosPessoais>> GetDadosPessoais(int id)
        {
            var dadosPessoais = await _context.DadosPessoais.FindAsync(id);

            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return dadosPessoais;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDadosPessoais(int id, DadosPessoais dadosPessoais)
        {
            if (id != dadosPessoais.Id)
            {
                return BadRequest();
            }

            _context.Entry(dadosPessoais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosPessoaisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DadosPessoais>> PostDadosPessoais(DadosPessoais dadosPessoais)
        {
            _context.DadosPessoais.Add(dadosPessoais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosPessoais", new { id = dadosPessoais.Id }, dadosPessoais);
        }

        // DELETE: api/DadosPessoais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DadosPessoais>> DeleteDadosPessoais(int id)
        {
            var dadosPessoais = await _context.DadosPessoais.FindAsync(id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            _context.DadosPessoais.Remove(dadosPessoais);
            await _context.SaveChangesAsync();

            return dadosPessoais;
        }
        [HttpGet("Login")]
        public async Task<ActionResult<DadosPessoais>> GetLogin(string Email, string senha)
        {  
            try
            {
                var cliente = await _context.DadosPessoais.Where(d => d.Email == Email && d.Senha == senha).Select(d => new Projeto_Next.Models.DadosPessoais
                {
                    Id = d.Id,
                    CPF = d.CPF,
                    Nome = d.Nome.ToUpper(),
                    DataNascimento = d.DataNascimento,
                    Email = d.Email,
                    Telefone = d.Telefone,
                    EnderecosResidencial = _context.EnderecoResidencial.Where(e => e.Id == d.Id).Select(d => new Projeto_Next.Models.EnderecoResidencial
                    {
                        Id = d.Id,
                        CEP = d.CEP,
                        Logradouro = d.Logradouro,
                        Numero = d.Numero,
                        Bairro = d.Bairro,
                        Cidade = d.Cidade,
                        UF = d.UF,
                        Tipo = d.Tipo,
                        Complemento = d.Complemento
                    }).FirstOrDefault(),
                    Senha = d.Senha
                }).FirstOrDefaultAsync();

                if (cliente == null)
                    return NotFound("Email ou senha errado.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Mensagem = "Ocorreu um erro" });
            }
        }

        [HttpGet("PesquisarCpf")]
        public async Task<ActionResult<DadosPessoais>> PesquisarCpf(string cpf)
        {
            try
            {
                var cliente = await _context.DadosPessoais.Where(d => d.CPF == cpf).Select(d => new Projeto_Next.Models.DadosPessoais
                {
                    Id = d.Id,
                    CPF = d.CPF,
                    Nome = d.Nome.ToUpper(),
                    DataNascimento = d.DataNascimento,
                    Email = d.Email,
                    Telefone = d.Telefone,
                    EnderecosResidencialId = d.EnderecosResidencialId,
                    EnderecosResidencial = _context.EnderecoResidencial.Where(e => e.Id == d.EnderecosResidencialId).Select(d => new Projeto_Next.Models.EnderecoResidencial
                    {
                        Id = d.Id,
                        CEP = d.CEP,
                        Logradouro = d.Logradouro,
                        Numero = d.Numero,
                        Bairro = d.Bairro,
                        Cidade = d.Cidade,
                        UF = d.UF,
                        Tipo = d.Tipo,
                        Complemento = d.Complemento
                    }).FirstOrDefault(),
                    Senha = d.Senha
                }).FirstOrDefaultAsync();

                if (cliente == null)
                    return NotFound("Cpf nao encontrado.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Mensagem = "Ocorreu um erro" });
            }
        }
        private bool DadosPessoaisExists(int id)
        {
            return _context.DadosPessoais.Any(e => e.Id == id);
        }
    }
}
