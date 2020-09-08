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
    public class TipoDePetRepository : ITipoDePet
    {
        //Chamar as conexões para código

        PetShopContext conexao = new PetShopContext();

        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(int id, TipoDePet t)
        {
            cmd.Connection = conexao.Conectar();

           cmd.CommandText = "UPDATE TipoDePet SET Descricao= @descricao WHERE IdTipoDePet = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", t.Descricao);



            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return t;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet t = new TipoDePet();

            while (dados.Read())
            {
                t.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                t.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return t;


        }

        public TipoDePet Cadastrar(TipoDePet t)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" + "(@descricao)";

            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return t;

        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoDePet> LerTudo()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDePet> tipos = new List<TipoDePet>();

            while (dados.Read())
            {
                tipos.Add(
                    new TipoDePet()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                  );
            }

            conexao.Desconectar();

            return tipos;


        }

    }
}
