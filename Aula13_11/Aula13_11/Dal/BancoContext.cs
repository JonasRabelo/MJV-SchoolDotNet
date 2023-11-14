using Aula13_11.Enums;
using Aula13_11.Models;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Aula13_11.Dal
{
    public class BancoContext
    {
        public string strConnection = "server=localhost\\sqlexpress; database=DB_Usuarios; Trusted_Connection = true; Integrated Security=SSPI;TrustServerCertificate=True";
        public List<UsuarioModel> ListarUsuarios()
        {
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            string query = "select * from Usuarios";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    UsuarioModel usuario;
                    while (reader.Read())
                    {
                        usuario = new UsuarioModel();

                        usuario.Id = Convert.ToInt32(reader["Id"]);
                        if (!reader.IsDBNull(1)) usuario.Nome = reader.GetString(1);
                        if (!reader.IsDBNull(2)) usuario.CPF = reader.GetString(2);
                        if (!reader.IsDBNull(3)) usuario.genero = reader.GetString(3) == "Masculino"? Genero.Masculino : Genero.Feminino;
                        if (!reader.IsDBNull(4)) usuario.Email = reader.GetString(4);
                        if (!reader.IsDBNull(5)) usuario.Telefone = reader.GetString(5);
                        listaUsuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error in ListarUsuarios: {ex.Message}");
            }
            return listaUsuarios;
        }

        public bool InserirUsuario(UsuarioModel usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into Usuarios (nome, cpf, genero, email, telefone) values (@nome, @cpf, @genero, @email, @telefone)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@cpf", usuario.CPF);
                    cmd.Parameters.AddWithValue("@genero", usuario.genero);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);

                    cmd.Connection.Open();

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    return linhasAfetadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InserirUsuario: {ex.Message}");
                return false;
            }
        }

        public UsuarioModel BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuarioEncontrado = new UsuarioModel();
            string query = "SELECT Id, nome, cpf, genero, email, telefone FROM Usuarios Where Id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        usuarioEncontrado.Id = Convert.ToInt32(reader["Id"]);
                        if (!reader.IsDBNull(1)) usuarioEncontrado.Nome = reader.GetString(1);
                        if (!reader.IsDBNull(2)) usuarioEncontrado.CPF = reader.GetString(2);
                        if (!reader.IsDBNull(3)) usuarioEncontrado.genero = reader.GetString(3) == "Masculino" ? Genero.Masculino : Genero.Feminino;
                        if (!reader.IsDBNull(4)) usuarioEncontrado.Email = reader.GetString(4);
                        if (!reader.IsDBNull(5)) usuarioEncontrado.Telefone = reader.GetString(5);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BuscarUsuarioPorId: {ex.Message}");
            }
            return usuarioEncontrado;
        }

        public bool EditarUsuario(UsuarioModel usuario)
        {
            string query = "UPDATE Usuarios SET nome = @Nome, cpf = @CPF, genero = @Genero, email = @Email, telefone = @Telefone WHERE Id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
                    cmd.Parameters.AddWithValue("@Genero", usuario.genero);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@id", usuario.Id);

                    connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EditarUsuario: {ex.Message}");
                return false;
            }
        }

        public bool ApagarUsuario(int id)
        {
            string query = "DELETE FROM Usuarios WHERE Id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Error in ApagarUsuario: {ex.Message}");
                return false;
            }
        }


        
    }
}
