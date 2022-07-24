using Data.Excepciones;
using System;
using System.Data.SqlClient;

namespace Data {
  /// <summary>
  /// Es la clase que se encarga de establecer una conexión entre la aplicación y la base de datos.
  /// </summary>
  public class Conexion {
    /// <summary>
    /// Es la cadena de conexión , contiene las credenciales y la dirección del servidor de base de datos.
    /// </summary>
    private static string _cadena = "Data Source=sql8004.site4now.net;Initial Catalog=db_a8a40c_prisionv01;Persist Security Info=True;User ID=db_a8a40c_prisionv01_admin;Password=verificacion2022";
    /// <summary>
    /// Es el atributo d ela librería de MySql que usamos. 
    /// </summary>
    private SqlConnection _cn = null;

    public SqlConnection Cn { get => _cn; set => _cn = value; }

    /// <summary>
    /// Abre la conexión con la base de datos.
    /// </summary>
    public void Conectar() {
      try {
        _cn = new SqlConnection();
        _cn.ConnectionString = _cadena;
        _cn.Open();
      } catch (SqlException) {
        throw new ConexionFallida();
      }
    }
    /// <summary>
    /// Cierra la conexión con la base de datos.
    /// </summary>
    public string Cerrar() {
      string x = "";
      try {
        _cn.Close();
        x = "1";
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
        x = "0" + ex.Message;
      }
      return x;
    }
  }
}
