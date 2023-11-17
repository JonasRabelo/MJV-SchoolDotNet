using Data.Repository.IRepository;
using Models;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace Data.Repository
{
    public class JogoRepository : IJogoRepository<JogoModel>
    {
        private readonly string cs = "server=localhost\\sqlexpress; database=DB_Loterica; Trusted_Connection = true; Integrated Security=SSPI;TrustServerCertificate=True";

        public bool Create(JogoModel entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Jogos (nomeDoJogo, game, valorDoJogo, usuarioId) VALUES (@nomeDoJogo, @game, @valorDoJogo, @usuarioId)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@nomeDoJogo", entity.NomeDoJogo);
                    cmd.Parameters.AddWithValue("@game", entity.Game);
                    cmd.Parameters.AddWithValue("@valorDoJogo", entity.ValorDoJogo);
                    cmd.Parameters.AddWithValue("@usuarioId", entity.UsuarioId);

                    cmd.Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Create: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Jogos WHERE Id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public List<JogoModel> GetAll(int id)
        {
            List<JogoModel> jogos = new List<JogoModel>();
            string query = "SELECT Id, nomeDoJogo, game, valorDoJogo FROM Jogos WHERE usuarioId = @usuarioId";
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@usuarioId", id);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        JogoModel jogo = new JogoModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomeDoJogo = reader["nomeDoJogo"].ToString()!,
                            Game = reader["game"].ToString()!,
                            ValorDoJogo = Convert.ToDouble(reader["valorDoJogo"]),
                            UsuarioId = id
                        };
                        jogos.Add(jogo);
                    }

                }
                return jogos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
            }
            return jogos;
        }

        public double GetValorDoJogoById(int id)
        {
            JogoModel jogo = new JogoModel();
            string query = "SELECT valorDoJogo FROM Jogos WHERE Id = @id";
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
                        return Convert.ToDouble(reader["valorDoJogo"]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
            }
            return 0.0;
        }

        public void UpdateSaldo(JogoModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
