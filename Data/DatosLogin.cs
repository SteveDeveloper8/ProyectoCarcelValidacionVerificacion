using Data.Excepciones;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data {
  /// <summary>
  /// Esta clase permite el acceso a los datos de <see cref="Usuario"/> en la base de datos del sistema.
  /// </summary>
  /// <remarks>Esta clase ejecuta procedimientos almacenados en la base de datos.</remarks>
  public class DatosLogin {
    /// <summary>
    /// Es la <see cref="Conexion"/> con la base de datos del sistema.
    /// </summary>
    /// <remarks>Es necesaria para establecer copmunicación entre la aplicación y el servidor de bases de datos.</remarks>
    Conexion _conexion = new Conexion();
    /// <summary>
    /// Inicializa la <see cref="Conexion"/>.
    /// </summary>
    public DatosLogin() {
      _conexion = new Conexion();
    }
    /// <summary>
    /// Consulta todos los usuarios del sistema.
    /// </summary>
    /// <returns>Una lista con todos los usuarios registrados en el sistema.</returns>
    public List<Usuario> Consultar() {
      List<Usuario> nomina = ConsultarGeneral();
      return nomina;
    }
    /// <summary>
    /// Busca un <seealso cref="Usuario"/> específico en la base de datos.
    /// </summary>
    /// <param name="username">Es el nombre de usuario del <seealso cref="Usuario"/> a buscar.</param>
    /// <returns>Un <seealso cref="Usuario"/> cuyo nombre de usuario coincida con el <paramref name="username"/>, si no se encuentra al usuario devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public Usuario ConsultarUsuario(String username) {
      SqlDataReader dr = null;
      Usuario user = null;
      List<Usuario> usuarios = new List<Usuario>();
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_usuario";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Parámetro para el procedimeinto almacenado.
      SqlParameter parametroUsuario = new SqlParameter("@nombre_usuario", System.Data.SqlDbType.VarChar);
      parametroUsuario.Direction = System.Data.ParameterDirection.Input;
      parametroUsuario.Value = username;
      comando.Parameters.Add(parametroUsuario);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();
        usuarios = LeerResultados(dr);
        if (usuarios.Count > 0)
          user = usuarios[0];
      } catch (SqlException) {
        throw new ConsultaFallida();
      }


      return user;
    }
    /// <summary>
    /// Actualiza toods los datos de un <seealso cref="Usuario"/> específico, a excepción del nombre de usuario, en la tabla de usuarios en la base de datos.
    /// </summary>
    /// <param name="user">Es un objeto de tipo <seealso cref="Usuario"/> que contiene los nuevos datos a actualizar.</param>
    /// <remarks>Se actualizará unicamente el registro cuyo nombre de usuario coincida con el de <paramref name="user"/>.</remarks>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void ActualizarUsuario(Usuario user)// username va en el where del sp
    {
      //Crear comando para procedimeitnos almacenados.
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_actualizar_usuario";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Lista de parámetros para el procedimeinto almacenado.
      SqlParameter parametroNombre = new SqlParameter("@nombres", System.Data.SqlDbType.VarChar);
      parametroNombre.Direction = System.Data.ParameterDirection.Input;
      parametroNombre.Value = user.Nombres;
      comando.Parameters.Add(parametroNombre);
      SqlParameter parametroApellido = new SqlParameter("@apellido", System.Data.SqlDbType.VarChar);
      parametroApellido.Direction = System.Data.ParameterDirection.Input;
      parametroApellido.Value = user.Apellidos;
      comando.Parameters.Add(parametroApellido);
      SqlParameter parametroUsername = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
      parametroUsername.Direction = System.Data.ParameterDirection.Input;
      parametroUsername.Value = user.Username;
      comando.Parameters.Add(parametroUsername);
      SqlParameter parametroPassword = new SqlParameter("@password", System.Data.SqlDbType.VarChar);
      parametroPassword.Direction = System.Data.ParameterDirection.Input;
      parametroPassword.Value = user.Contrasena;
      comando.Parameters.Add(parametroPassword);
      SqlParameter parametroRol = new SqlParameter("@id_rol", System.Data.SqlDbType.Int);
      parametroRol.Direction = System.Data.ParameterDirection.Input;
      parametroRol.Value = user.Rol.Id;
      comando.Parameters.Add(parametroRol);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        comando.ExecuteNonQuery();
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      _conexion.Cerrar();
    }
    /// <summary>
    /// Lee un <see cref="SqlDataReader"/> lleno con datos y devuelve una lista de usuarios recuperados de este.
    /// </summary>
    /// <param name="datos">Es un <see cref="SqlDataReader"/> que contiene los resultados de una consulta previa.</param>
    /// <returns>Una lista de <seealso cref="Usuario"/> correspondiente a todos los registros de <paramref name="datos"/>.</returns>
    private List<Usuario> LeerResultados(SqlDataReader datos) {
      Usuario user = null;
      List<Usuario> usuarios = new List<Usuario>();
      while (datos.Read()) {

        user = new Usuario();
        user.Id = Convert.ToInt32(datos["Id_Usuario"]);
        user.Nombres = datos["Nombres"].ToString();
        user.Apellidos = datos["Apellidos"].ToString();
        user.Username = datos["UserName"].ToString();
        user.Contrasena = datos["Password"].ToString();
        user.Rol.Descripcion = datos["Descripcion"].ToString();
        usuarios.Add(user);
      }
      return usuarios;
    }
    /// <summary>
    /// Busca un <seealso cref="Rol"/> cuya descripción coincida con <paramref name="rol"/> en la base de datos.
    /// </summary>
    /// <param name="rol">Nombre del <seealso cref="Rol"/> a buscar.</param>
    /// <returns>Un <seealso cref="Rol"/>.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public Rol ConsultarRol(string rol) {
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_rol";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Parámetro para el procedimeinto almacenado.
      SqlParameter parametroRol = new SqlParameter("@nombre_rol", System.Data.SqlDbType.VarChar);
      parametroRol.Direction = System.Data.ParameterDirection.Input;
      parametroRol.Value = rol;
      comando.Parameters.Add(parametroRol);
      SqlDataReader dr = null;
      Rol role = null;
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();
        if (dr.Read()) {

          role = new Rol();
          role.Id = Convert.ToInt32(dr["Id_Rol"]);
          role.Descripcion = dr["Descripcion"].ToString();

        }
      } catch (SqlException) {
        throw new ConsultaFallida();
      }


      return role;
    }
    /// <summary>
    /// Inserta un nuevo <seealso cref="Usuario"/>(<paramref name="user"/>) en la base de datos del sistema.
    /// </summary>
    /// <param name="user">Nuevo <seealso cref="Usuario"/> a insertar en la base de datos.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void InsertarUsuario(Usuario user) {
      //Crear comando para procedimeitnos almacenados.
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_ingresar_usuario";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Lista de parámetros para el procedimeinto almacenado
      SqlParameter parametroNombre = new SqlParameter("@nombres", System.Data.SqlDbType.VarChar);
      parametroNombre.Direction = System.Data.ParameterDirection.Input;
      parametroNombre.Value = user.Nombres;
      comando.Parameters.Add(parametroNombre);
      SqlParameter parametroApellido = new SqlParameter("@apellido", System.Data.SqlDbType.VarChar);
      parametroApellido.Direction = System.Data.ParameterDirection.Input;
      parametroApellido.Value = user.Apellidos;
      comando.Parameters.Add(parametroApellido);
      SqlParameter parametroUsername = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
      parametroUsername.Direction = System.Data.ParameterDirection.Input;
      parametroUsername.Value = user.Username;
      comando.Parameters.Add(parametroUsername);
      SqlParameter parametroPassword = new SqlParameter("@password", System.Data.SqlDbType.VarChar);
      parametroPassword.Direction = System.Data.ParameterDirection.Input;
      parametroPassword.Value = user.Contrasena;
      comando.Parameters.Add(parametroPassword);
      SqlParameter parametroRol = new SqlParameter("@id_rol", System.Data.SqlDbType.Int);
      parametroRol.Direction = System.Data.ParameterDirection.Input;
      parametroRol.Value = user.Rol.Id;
      comando.Parameters.Add(parametroRol);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        comando.ExecuteNonQuery();
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      _conexion.Cerrar();
    }
    /// <summary>
    /// Consulta todos los usuarios registrados en la base de datos.
    /// </summary>
    /// <returns>Una lista con todos los usuarios registrados en el sistema.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    private List<Usuario> ConsultarGeneral() {
      SqlDataReader dr = null;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_usuarios";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      List<Usuario> usuarios = new List<Usuario>();
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        usuarios = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }

      return usuarios;
    }
  }
}
