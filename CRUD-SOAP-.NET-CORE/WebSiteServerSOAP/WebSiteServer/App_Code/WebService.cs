using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

using System;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    // Constructor
    public WebService()
    {
        // Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        // InitializeComponent(); 
    }


    // Método para agregar un nuevo paciente
    [WebMethod]
    public string AgregarPaciente(string name, int age)
    {
        try
        {
            using (var connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=PacientesDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO Pacientes (Name, Age) VALUES (@Name, @Age)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.ExecuteNonQuery();
                }
            }
            return "Paciente agregado correctamente";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


    // Método para obtener todos los pacientes
    [WebMethod]
    public List<Paciente> ObtenerPacientes()
    {
        List<Paciente> pacientes = new List<Paciente>();
        try
        {
            using (var connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=PacientesDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "SELECT * FROM Pacientes";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Paciente paciente = new Paciente
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2)
                        };
                        pacientes.Add(paciente);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
        return pacientes;
    }


    // Método para actualizar un paciente
    [WebMethod]
    public string ActualizarPaciente(int id, string name, int age)
    {
        try
        {
            using (var connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=PacientesDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "UPDATE Pacientes SET Name = @Name, Age = @Age WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.ExecuteNonQuery();
                }
            }
            return "Paciente actualizado correctamente";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // Método para eliminar un paciente
    [WebMethod]
    public string EliminarPaciente(int id)
    {
        try
        {
            using (var connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=PacientesDB;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "DELETE FROM Pacientes WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            return "Paciente eliminado correctamente";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
