using WebApi.Roman.Domains;
using System.Collections.Generic;

namespace Senai.Sprint5.Exercicio.Roman.Interfaces
{
    public interface IProjetoRepository
    {
        void Cadastrar(ProjetosViewModel projeto);
        List<Projetos> ListarProjetos();
    }
}
