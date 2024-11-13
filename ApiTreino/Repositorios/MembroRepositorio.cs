using ApiTreino.Data.Context;
using ApiTreino.Models;
using ApiTreino.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace ApiTreino.Repositorios
{
    public class MembroRepositorio : iMembroRepositorio
    {
        private readonly MembroContext _membroContext;
        public MembroRepositorio(MembroContext membroContext)
        {

            _membroContext = membroContext;
        
        }

        public async Task<List<MembroModel>> BuscarTodosMembros()
        {
            return await _membroContext.membro.ToListAsync();
        }  

        public async Task<MembroModel> BuscarPorMembro(string nome)
        {
            return await _membroContext.membro.FirstOrDefaultAsync(x=> x.nome == nome);
        }


        public async Task<MembroModel> Adicionar(MembroModel membro)
        {
            await _membroContext.membro.AddAsync(membro);
            await _membroContext.SaveChangesAsync();

            return (membro);
        
        }

        

        public async Task<MembroModel> Atualizar(MembroModel membro, string nome)
        {
            MembroModel membroPorNome = await BuscarPorMembro(nome);

            if (membroPorNome == null)
            {
                throw new Exception($"Membro: {nome} não encontrado");
            }
            
            membroPorNome.idade = membro.idade;
            membroPorNome.casado = membro.casado;

            _membroContext.membro.Update(membroPorNome);
            await _membroContext.SaveChangesAsync();

            return membroPorNome;
        }

        public async Task<bool> Apagar(string nome)
        {
            MembroModel membroPorNome = await BuscarPorMembro(nome);

                if (membroPorNome == null)
                {
                    throw new Exception($"Membro; {nome} não encontrado");
                }

                _membroContext.membro.Remove(membroPorNome);
                await _membroContext.SaveChangesAsync();
                return true;
            }

        }


        
    
}

