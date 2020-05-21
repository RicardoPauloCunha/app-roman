using Senai.Desenvolvimento.Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Desenvolvimento.Roman.Interfaces
{
    interface ITemaRepository
    {
        /// <summary>
        /// Cadastra um tema
        /// </summary>
        /// <param name="tema"></param>
        void Cadastrar(TemasViewModel tema);

        /// <summary>
        /// Lista os temas
        /// </summary>
        /// <returns>Retorna uma lista de todos os temas cadastrados</returns>
        List<Temas> ListarTemas();

        /// <summary>
        /// Altera um tema que tenha o mesmo id recebido como parâmetro.
        /// </summary>
        /// <param name="id"></param>
        void Alterar(TemasViewModel tema);

        /// <summary>
        /// Lista os temas ativos
        /// </summary>
        /// <returns>Retorna uma lista de temas ativos</returns>
        List<Temas> TemasAtivos();
    }
}
