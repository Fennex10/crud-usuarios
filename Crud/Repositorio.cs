using Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Repositorio
{
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UsuariosDBConnection"].ConnectionString;

    public List<Usuario> GetAll()
    {
        var usuarios = new List<Usuario>();
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT Id, Nombre, Correo, Rol FROM Usuarios", connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Rol = reader["Rol"].ToString()
                    });
                }
            }
        }
        return usuarios;
    }

    public void Add(Usuario usuario)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(
                "INSERT INTO Usuarios (Nombre, Correo, Rol) VALUES (@Nombre, @Correo, @Rol); SELECT SCOPE_IDENTITY();",
                connection);

            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Correo", usuario.Correo);
            command.Parameters.AddWithValue("@Rol", usuario.Rol);

            connection.Open();
            usuario.Id = Convert.ToInt32(command.ExecuteScalar());
        }
    }

    public void Update(Usuario usuario)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(
                "UPDATE Usuarios SET Nombre = @Nombre, Correo = @Correo, Rol = @Rol WHERE Id = @Id",
                connection);

            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Correo", usuario.Correo);
            command.Parameters.AddWithValue("@Rol", usuario.Rol);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("DELETE FROM Usuarios WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}