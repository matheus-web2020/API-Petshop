using System;
using API_PetShop.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);

        List<Raca> LerTudo();

        Raca BuscarPorId(int id);

        Raca Alterar(Raca r);

        TipoDePet Excluir(TipoDePet t);
    }
}
