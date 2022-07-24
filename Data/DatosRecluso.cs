using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Data.Excepciones;

using Model;
namespace Data {
  /// <summary>
  /// Esta clase permite el acceso a los datos de <see cref="Recluso"/> en la base de datos del sistema.
  /// </summary>
  /// <remarks>Esta clase ejecuta procedimientos almacenados en la base de datos.</remarks>
  public class DatosRecluso {
    /// <summary>
    /// Es la <see cref="Conexion"/> con la base de datos del sistema.
    /// </summary>
    /// <remarks>Es necesaria para establecer copmunicación entre la aplicación y el servidor de bases de datos.</remarks>
    Conexion _conexion;
    /// <summary>
    /// Inicializa la <see cref="Conexion"/>.
    /// </summary>
    public DatosRecluso() {
      _conexion = new Conexion();
    }
    /// <summary>
    /// Busca un <seealso cref="Expediente"/> específico en la base de datos.
    /// </summary>
    /// <param name="cedula">Es la cédula de <seealso cref="Recluso"/> cuyo <seealso cref="Expediente"/> se va a consultar.</param>
    /// <returns>Un <seealso cref="Expediente"/> cuya cédula coincida con <paramref name="cedula"/>, si no se encuentra al expediente devuelve null.</returns>
    /// /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public Expediente BuscarExpediente(string cedula) {
      SqlDataReader dr = null;
      SqlCommand comando = new SqlCommand();
      Expediente expediente = null;
      comando.CommandText = "spr_consultar_expediente";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroCedula = new SqlParameter("@cedula_recluso", System.Data.SqlDbType.VarChar);
      parametroCedula.Direction = System.Data.ParameterDirection.Input;
      parametroCedula.Value = cedula;
      comando.Parameters.Add(parametroCedula);
      try {
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        if (dr.Read()) {
          expediente = new Expediente();
          expediente.Id = Convert.ToInt32(dr["Id_Expediente"]);
          expediente.Codigo = (dr["Codigo"]).ToString();
        }
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      _conexion.Cerrar();
      return expediente;
    }
    /// <summary>
    /// Inserta un nuevo <seealso cref="Recluso"/>(<paramref name="recluso"/>) en la base de datos del sistema.
    /// </summary>
    /// <param name="user">Nuevo <seealso cref="Recluso"/> a insertar en la base de datos.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void InsertarRecluso(Recluso recluso) {
      //Crear comando para procedimeitnos almacenados.
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_ingresar_recluso";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Lista de parámetros para el procedimeinto almacenado
      SqlParameter parametroCodigo = new SqlParameter("@codigo", System.Data.SqlDbType.VarChar);
      parametroCodigo.Direction = System.Data.ParameterDirection.Input;
      parametroCodigo.Value = recluso.Codigo;
      comando.Parameters.Add(parametroCodigo);
      SqlParameter parametroCedula = new SqlParameter("@cedula", System.Data.SqlDbType.VarChar);
      parametroCedula.Direction = System.Data.ParameterDirection.Input;
      parametroCedula.Value = recluso.Cedula;
      comando.Parameters.Add(parametroCedula);
      SqlParameter parametroNombre = new SqlParameter("@nombres", System.Data.SqlDbType.VarChar);
      parametroNombre.Direction = System.Data.ParameterDirection.Input;
      parametroNombre.Value = recluso.Nombre;
      comando.Parameters.Add(parametroNombre);
      SqlParameter parametroApellido = new SqlParameter("@apellidos", System.Data.SqlDbType.VarChar);
      parametroApellido.Direction = System.Data.ParameterDirection.Input;
      parametroApellido.Value = recluso.Apellidos;
      comando.Parameters.Add(parametroApellido);
      SqlParameter parametroFecha = new SqlParameter("@fecha_Nac", System.Data.SqlDbType.DateTime);
      parametroFecha.Direction = System.Data.ParameterDirection.Input;
      parametroFecha.Value = recluso.Fecha;
      comando.Parameters.Add(parametroFecha);
      SqlParameter parametroGenero = new SqlParameter("@genero", System.Data.SqlDbType.VarChar);
      parametroGenero.Direction = System.Data.ParameterDirection.Input;
      parametroGenero.Value = recluso.Genero;
      comando.Parameters.Add(parametroGenero);
      SqlParameter parametroExpediente = new SqlParameter("@id_Expediente", System.Data.SqlDbType.Int);
      parametroExpediente.Direction = System.Data.ParameterDirection.Input;
      parametroExpediente.Value = recluso.Expediente.Id;
      comando.Parameters.Add(parametroExpediente);

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
    /// Consulta todos los reclusos del sistema.
    /// </summary>
    /// <returns>Una lista con todos los reclusos registrados en el sistema.</returns>
    public List<Recluso> ConsultarReclusos() {
      List<Recluso> reclusos = ConsultarGeneral();
      return reclusos;
    }
    //Consulta la base de datos y devuelve una lista de cargos que pertenezcan al expediente cuyo código recibe.
    /// <summary>
    /// Consulata todos los <see cref="Cargo"/>s asociados a un <see cref="Expediente"/> cuyo código coincida con <paramref name="codigoExpediente"/> en la base de datos.
    /// </summary>
    /// <param name="codigoExpediente">Es el código del <see cref="Expediente"/> a cuyos cargos queremos consultar.</param>
    /// <returns>Una lista de <see cref="Cargo"/>s correspondientes al expediente.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<Cargo> ConsultarCargos(string codigoExpediente) {
      SqlDataReader dr = null;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_cargos";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroCedula = new SqlParameter("@codigo_expediente", System.Data.SqlDbType.NChar);
      parametroCedula.Direction = System.Data.ParameterDirection.Input;
      parametroCedula.Value = codigoExpediente;
      comando.Parameters.Add(parametroCedula);
      List<Cargo> cargos = new List<Cargo>();
      Cargo cargo = null;
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        while (dr.Read()) {
          cargo = new Cargo();
          cargo.LugarHechos = new Lugar();
          cargo.Delito = dr["Delito"].ToString();
          cargo.Descripcion = dr["Descripcion"].ToString();
          cargo.FechaHechos = Convert.ToDateTime(dr["Fecha"].ToString());
          cargo.LugarHechos.NombreLocalidad = dr["Localidad"].ToString();
          cargo.LugarHechos.NombreCiudad = dr["Ciudad"].ToString();
          cargo.LugarHechos.NombrePais = dr["Pais"].ToString();
          cargos.Add(cargo);
        }
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return cargos;
    }
    /// <summary>
    /// Busca un <seealso cref="Recluso"/> específico en el sistema.
    /// </summary>
    /// <param name="cedula">Es la cédula de <seealso cref="Recluso"/> a buscar.</param>
    /// <returns>Un <seealso cref="Recluso"/> cuya cédula coincida con <paramref name="cedula"/>, si no se encuentra al recluso devuelve null.</returns>
    public Recluso BuscarRecluso(string cedula) {
      List<Recluso> reclusos = ConsultarBusqueda(cedula);
      if (reclusos.Count > 0)
        return reclusos[0];
      else
        return null;
    }
    /// <summary>
    /// Consulta todos los reclusos registrados en la base de datos.
    /// </summary>
    /// <returns>Una lista con todos los reclusos registrados en el sistema.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    private List<Recluso> ConsultarGeneral() {
      SqlDataReader dr = null;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_reclusos";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        return LeerResultados(dr);

      } catch (SqlException) {
        throw new ConsultaFallida();
      }
    }
    /// <summary>
    /// Lee un <see cref="SqlDataReader"/> lleno con datos y devuelve una lista de reclusos recuperados de este.
    /// </summary>
    /// <param name="datos">Es un <see cref="SqlDataReader"/> que contiene los resultados de una consulta previa.</param>
    /// <returns>Una lista de <seealso cref="Recluso"/> correspondiente a todos los registros de <paramref name="datos"/>.</returns>
    private List<Recluso> LeerResultados(SqlDataReader datos) {
      List<Recluso> reclusos = new List<Recluso>();
      while (datos.Read()) {
        Recluso recluso = new Recluso();
        recluso.Expediente = new Expediente();
        recluso.Id = Convert.ToInt32(datos["Id_Recluso"]);
        recluso.Codigo = datos["Codigo"].ToString();
        recluso.Nombre = datos["Nombres"].ToString();
        recluso.Apellidos = datos["Apellidos"].ToString();
        recluso.Cedula = datos["Cedula"].ToString();
        recluso.Fecha = Convert.ToDateTime(datos["Fecha_Nac"].ToString());
        recluso.Genero = datos["Genero"].ToString();
        recluso.Expediente.Id = Convert.ToInt32(datos["Id_Expediente"]);
        reclusos.Add(recluso);
      }
      return reclusos;
    }
    /// <summary>
    /// Busca un <seealso cref="Recluso"/> específico en la base de datos.
    /// </summary>
    /// <param name="cedula">Es la cédula de <seealso cref="Recluso"/> a buscar.</param>
    /// <returns>Un <seealso cref="Recluso"/> cuya cédula coincida con <paramref name="cedula"/>, si no se encuentra al recluso devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    private List<Recluso> ConsultarBusqueda(string cedula) {
      SqlDataReader dr = null;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_recluso";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroCedula = new SqlParameter("@cedula_rec", System.Data.SqlDbType.VarChar);
      parametroCedula.Direction = System.Data.ParameterDirection.Input;
      parametroCedula.Value = cedula;
      comando.Parameters.Add(parametroCedula);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        return LeerResultados(dr);

      } catch (SqlException) {
        throw new ConsultaFallida();
      }
    }
  }
}
