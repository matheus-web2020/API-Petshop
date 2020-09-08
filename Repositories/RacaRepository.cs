using API_PetShop.Context;
using API_PetShop.Domains;
using API_PetShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class RacaRepository : IRaca
    {
        //Chamar as conexões para código

        PetShopContext conexao = new PetShopContext();

        SqlCommand cmd = new SqlCommand();
        public Raca Alterar(Raca r)
        {
            throw new NotImplementedException();
        }

        public Raca BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Raca Cadastrar(Raca r)
        {
            throw new NotImplementedException();
        }

        public TipoDePet Excluir(TipoDePet t)
        {
            throw new NotImplementedException();
        }

        public List<Raca> LerTudo()
        {
            throw new NotImplementedException();
        }
    }
}
