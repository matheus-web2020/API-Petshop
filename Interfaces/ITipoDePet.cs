using System;
using API_PetShop.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet t);

        List<TipoDePet> LerTudo();

        TipoDePet BuscarPorId(int id);

        TipoDePet Alterar(int id, TipoDePet t);

        void Excluir(int id);
    }
}
