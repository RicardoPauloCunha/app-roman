using Senai.Desenvolvimento.Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sprint5.Exercicio.Roman.Interfaces
{
    interface IProjetoRepository
    {
        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="projeto"></param>
        void Cadastrar(ProjetosViewModel projeto);

        /// <summary>
        /// Lista projetos
        /// </summary>
        /// <returns>Retorna uma lista de projetos cadstrados</returns>
     List<Projetos> ListarProjetos();
    }
}
