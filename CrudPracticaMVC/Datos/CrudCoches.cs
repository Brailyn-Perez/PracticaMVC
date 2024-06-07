using System.Data.SqlClient;

namespace CrudPracticaMVC.Datos
{
    public class CrudCoches
    {

        ConexionDB conexion = new ConexionDB();
        //obtenemos los datos
        public List<Models.CochesModel> getcoches() 
        {
            string query = "Select * from Automoviles";
            var oLista = new List<Models.CochesModel>();
            using (var connection =  new SqlConnection(conexion.getcadenaSQL()))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                // leemos los datos optenidos
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    oLista.Add(new Models.CochesModel()
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        marca = reader.GetString(2),
                        color = reader.GetString(3),
                        placa = reader.GetString(4),
                        precio = reader.GetString(5)
                    }) ;
                }
                reader.Close();
                connection.Close();
            }

            return oLista;
        }

        // Eliminamos datos
        public void Delete(int id)
        {
            string query = "DELETE FROM Automoviles where idAutomovil = @id";
            using (var connection = new SqlConnection(conexion.getcadenaSQL()))
            {
                connection.Open();

                var command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@id", id); 
                command.ExecuteNonQuery();


                connection.Close();
            }
        }

        //Editamos datos 
        public void Edit(Models.CochesModel coches)
        {
            string query = "UPDATE  Automoviles  SET nombre=@nombre,marca=@marca,color =@color,placa =@placa,precio = @precio where idAutomovil= @id";
            using (var connection = new SqlConnection(conexion.getcadenaSQL()))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", coches.id);
                    command.Parameters.AddWithValue("@nombre",coches.nombre);
                    command.Parameters.AddWithValue("@marca", coches.marca);
                    command.Parameters.AddWithValue("@color", coches.color);
                    command.Parameters.AddWithValue("@placa", coches.placa);
                    command.Parameters.AddWithValue("@precio", coches.precio);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public void Insert(Models.CochesModel coches)
        {
            string query = "INSERT INTO Automoviles VALUES(@nombre,@marca,@color,@placa,@precio)";

            using (var connection = new SqlConnection(conexion.getcadenaSQL()))
            {
                connection.Open();
                using (var command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@nombre", coches.nombre);
                    command.Parameters.AddWithValue("@marca", coches.marca);
                    command.Parameters.AddWithValue("@color", coches.color);
                    command.Parameters.AddWithValue("@placa", coches.placa);
                    command.Parameters.AddWithValue("@precio", coches.precio);
                    command.ExecuteNonQuery();
                }
                connection.Close();

            }
        }


    }

}
