using Data.Repository.IRepository;
using Models;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository<UsuarioModel>
    {
        private readonly string cs = "server=localhost\\sqlexpress; database=DB_Loterica; Trusted_Connection = true; Integrated Security=SSPI;TrustServerCertificate=True";
        public UsuarioModel CreateByName(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Usuarios (nome, saldo) VALUES (@nome, @saldo)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@nome", name);
                    cmd.Parameters.AddWithValue("@saldo", 0);

                    cmd.Connection.Open();

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    return Get(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateByName: {ex.Message}");
                return new UsuarioModel();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Get(string name)
        {
            UsuarioModel usuarioEncontrado = new UsuarioModel();
            string query = "SELECT Id, nome, saldo FROM Usuarios WHERE nome = @nome";
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nome", name);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        usuarioEncontrado.Id = Convert.ToInt32(reader["Id"]);
                        usuarioEncontrado.Nome = reader["nome"].ToString()!;
                        usuarioEncontrado.Saldo = Convert.ToDouble(reader["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Get: {ex.Message}");
            }
            return usuarioEncontrado;
        }

        public UsuarioModel GetById(int id)
        {
            UsuarioModel usuarioEncontrado = new UsuarioModel();
            string query = "SELECT Id, nome, saldo FROM Usuarios WHERE Id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        usuarioEncontrado.Id = Convert.ToInt32(reader["Id"]);
                        usuarioEncontrado.Nome = reader["nome"].ToString()!;
                        usuarioEncontrado.Saldo = Convert.ToDouble(reader["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Get: {ex.Message}");
            }
            return usuarioEncontrado;
        }


        public void Update(UsuarioModel entity)
        {
            string query = "UPDATE Usuarios SET saldo = @saldo WHERE Id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@saldo", entity.Saldo);
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    
                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
            }
        }
    }
}
