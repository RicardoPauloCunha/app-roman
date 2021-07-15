using WebApi.Roman.Domains;
using System.Collections.Generic;

namespace WebApi.Roman.Interfaces
{
    public interface IProfessorRepository
    {
        List<Professores> ListarProfessores();
        List<Professores> ListarProfessoresPorArea(string equipe);
    }
}
