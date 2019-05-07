using Senai.Desenvolvimento.Roman.Domains;
using Senai.Desenvolvimento.Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Desenvolvimento.Roman.Repositories
{
    public class TemaRepository : ITemaRepository
    {
    private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=ROMAN;User ID = sa; Password = 132;";

        public void Alterar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Temas tema)
        {
            throw new NotImplementedException();
        }

        public List<Temas> listarTemas()
        {
            throw new NotImplementedException();
        }
    }
}
