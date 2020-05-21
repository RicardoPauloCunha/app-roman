using Senai.Desenvolvimento.Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Desenvolvimento.Roman.Interfaces
{
    interface IProfessorRepository
    {
        /// <summary>
        /// Lista os professores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de todos os professores cadastrados</returns>
        List<Professores> ListarProfessores();

        /// <summary>
        /// Lista os professores pela área selecionada
        /// </summary>
        /// <returns>Retorna uma lista de professores filtrados por área</returns>
        List<Professores> ListarProfessoresPorArea(string equipe);
    }
}
