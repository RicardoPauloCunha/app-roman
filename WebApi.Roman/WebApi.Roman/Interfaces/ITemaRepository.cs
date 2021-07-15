using WebApi.Roman.Domains;
using System.Collections.Generic;

namespace WebApi.Roman.Interfaces
{
    public interface ITemaRepository
    {
        void Cadastrar(TemasViewModel tema);
        void Alterar(TemasViewModel tema);
        List<Temas> ListarTemas();
        List<Temas> TemasAtivos();
    }
}
