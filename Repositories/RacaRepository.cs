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

        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET Descricao= @descricao, IdTipoDePet= @idtipodepet WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoPet = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Raca (Descricao, IdTipoDePet) " +
                "VALUES" + "(@descricao, @idtipodepet)";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE Idraca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTudo()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoPet = Convert.ToInt32(dados.GetValue(2)),
                    }
                  );
            }

            conexao.Desconectar();

            return racas;
        }
    }
}
