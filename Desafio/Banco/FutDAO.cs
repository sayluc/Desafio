using Desafio.Classe;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Banco
{
    public static class FutDAO
    {
        // Método para listar todos os jogadores (SELECT):
        public static DataTable ListarTudo()
        {
            // Tabela do resultado
            DataTable resultado = new DataTable();

            // Comando a ser executado
            string comando = "SELECT * FROM desafio";

            // Instanciar um objeto de conexao
            Conexao conexao = new Conexao();
            MySqlConnection con = conexao.ObterConexao();

            // Transformar o comando em um objeto
            MySqlCommand cmd = new MySqlCommand(comando, con);

            cmd.Prepare();

            resultado.Load(cmd.ExecuteReader());

            // Desconectr do BD
            conexao.Desconectar(con);
            
            // Entregar a tabela
            return resultado;
        }
        
        // Método para apagar os jogadores (DELETE):
        public static bool Apagar(int id)
        {
            string comando = "DELETE FROM desafio WHERE id = @id";
            // Instanciar um objeto de conexão:
            Conexao conexao = new Conexao();
            MySqlConnection con = conexao.ObterConexao();
            // Transformar o comando em um objeto:
            MySqlCommand cmd = new MySqlCommand(comando, con);

            // Substituir os caracteres coringas por valores vindos do
            // programa principal:
            cmd.Parameters.AddWithValue("@id", id);


            cmd.Prepare();
            // Tratamento de erros:
            try
            {
                // Verificar se a inserção ocorreu:
                if (cmd.ExecuteNonQuery() == 0)
                {
                    conexao.Desconectar(con);
                    return false;
                }
                else
                {
                    conexao.Desconectar(con);
                    return true;
                }
            }
            catch
            {
                conexao.Desconectar(con);
                return false;
            }

        }

        // Método para cadastrar os jogadores (INSERT):
        public static bool Cadastrar(Classe.Jogador l)
        {
            string comando = "INSERT INTO desafio (name, email, birth, function, s_number) " + "VALUES (@name, @email, @birth, @function, @s_number)";

            // Instanciar um objeto de conexão:
            Conexao conexao = new Conexao();
            MySqlConnection con = conexao.ObterConexao();
            
            // Transformar o comando em um objeto:
            MySqlCommand cmd = new MySqlCommand(comando, con);

            // Substituir os caracteres coringas por valores vindos do
            // programa principal:
            cmd.Parameters.AddWithValue("@name", l.name);
            cmd.Parameters.AddWithValue("@email", l.email);
            cmd.Parameters.AddWithValue("@birth", l.birth);
            cmd.Parameters.AddWithValue("@function", l.function);
            cmd.Parameters.AddWithValue("@s_number", l.s_number);

            cmd.Prepare();
            // Tratamento de erros:
            try
            {
                // Verificar se a inserção ocorreu:
                if (cmd.ExecuteNonQuery() == 0)
                {
                    conexao.Desconectar(con);
                    return false;
                }
                else
                {
                    conexao.Desconectar(con);
                    return true;
                }
            }
            catch
            {
                conexao.Desconectar(con);
                return false;
            }
        }

        public static DataTable ProcurarPorId(int id)
        {
            DataTable resultado = new DataTable();
            string comando = "SELECT * FROM desafio WHERE id = @id";
            Conexao conexao = new Conexao();
            MySqlConnection con = conexao.ObterConexao();
            MySqlCommand cmd = new MySqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            resultado.Load(cmd.ExecuteReader());
            conexao.Desconectar(con);

            return resultado;
        }
    }
}