using ApiTreino.Data.Context;
using ApiTreino.Repositorios;
using ApiTreino.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiTreino.Models;
using Org.BouncyCastle.Crypto.Digests;

namespace ApiTreino.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly iMembroRepositorio _membrorepositorio;

        public MembroController(iMembroRepositorio membrorepositorio)
        {
            _membrorepositorio = membrorepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MembroModel>>> BuscarTodosMembros()
        {
            List<MembroModel> membros = await _membrorepositorio.BuscarTodosMembros();
            return Ok(membros);

        }

        [HttpGet("PesquisarPor{nome}")]

        public async Task<ActionResult<MembroModel>> BuscaPorMemBro(string nome)
        {
            MembroModel membro = await _membrorepositorio.BuscarPorMembro(nome);

            if (membro == null)
            { 
                return NotFound($"Membro: {nome} não encontrado");
            }

            return Ok(membro);
        }


        [HttpPost]

        public async Task<ActionResult<MembroModel>> Adicionar([FromBody] MembroModel membro)
        {
            if (membro == null)
                return BadRequest("Dados de membro não são válidos");

            var membroadicionado = await _membrorepositorio.Adicionar(membro);

            return Ok(membroadicionado);

        }

        [HttpPut("{nome}")]

        public async Task<ActionResult<MembroModel>> Atualizar([FromBody] MembroModel membro, string nome)
        {
            if (membro == null)
            {
                return BadRequest("Nome de membro não encontrado.");
            }
            var membroAtualizado = await _membrorepositorio.Atualizar(membro, nome);

            if (membroAtualizado != null)
            {
                return Ok(membroAtualizado);
            }



            return NotFound($"Membro:{nome} não encontrado");


        }


        [HttpDelete("{nome}")]
        public async Task<ActionResult> ApagarMembro(string nome)
        {
            try
            {
                bool sucesso = await _membrorepositorio.Apagar(nome);

                if (sucesso)
                {
                    return Ok($"Membro: {nome} apagado com sucesso");

                }

                return NotFound($"Membro: {nome} não encontrado");

            }
            catch (Exception ex )
            
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        
        
        
        }
        
           
        

     }


        

 }

