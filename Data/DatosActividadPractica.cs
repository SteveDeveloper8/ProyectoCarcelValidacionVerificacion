using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Data.Excepciones;

using Model;


namespace Data {
  /// <summary>
  /// Esta clase permite el acceso a los datos de <see cref="ActividadPractica"/> en la base de datos del sistema.
  /// </summary>
  /// <remarks>Esta clase ejecuta procedimientos almacenados en la base de datos.</remarks>
  public class DatosActividadPractica {
    /// <summary>
    /// Es la <see cref="Conexion"/> con la base de datos del sistema.
    /// </summary>
    /// <remarks>Es necesaria para establecer copmunicación entre la aplicación y el servidor de bases de datos.</remarks>
    Conexion _conexion;
    /// <summary>
    /// Inicializa la <see cref="Conexion"/>.
    /// </summary>
    public DatosActividadPractica() {
      _conexion = new Conexion();
    }
    /// <summary>
    /// Inserta una nueva <seealso cref="ActividadPractica"/>(<paramref name="actividad"/>) en la base de datos del sistema.
    /// </summary>
    /// <param name="actividad">Nueva <seealso cref="ActividadPractica"/> a insertar en la base de datos.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void InsertarActividad(ActividadPractica actividad) {
      //Crear comando para procedimeitnos almacenados.
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_ingresar_oficio";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      //Lista de parámetros para el procedimeinto almacenado.
      SqlParameter parametroModalidad = new SqlParameter("@modalidad", System.Data.SqlDbType.VarChar);
      parametroModalidad.Direction = System.Data.ParameterDirection.Input;
      parametroModalidad.Value = actividad.Modalidad;
      comando.Parameters.Add(parametroModalidad);
      SqlParameter parametroDescripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar);
      parametroDescripcion.Direction = System.Data.ParameterDirection.Input;
      parametroDescripcion.Value = actividad.Descripcion;
      comando.Parameters.Add(parametroDescripcion);
      SqlParameter parametroRemision = new SqlParameter("@remisionCondena", System.Data.SqlDbType.Int);
      parametroRemision.Direction = System.Data.ParameterDirection.Input;
      parametroRemision.Value = actividad.RemisionDiaria;
      comando.Parameters.Add(parametroRemision);
      SqlParameter parametroCupos = new SqlParameter("@cuposDisponibles", System.Data.SqlDbType.Int);
      parametroCupos.Direction = System.Data.ParameterDirection.Input;
      parametroCupos.Value = actividad.Cupos;
      comando.Parameters.Add(parametroCupos);

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
    /// Eliina un registro de <seealso cref="ActividadPractica"/> de la base de datos del sistema cuya <paramref name="descripcion"/> y <paramref name="modalidad"/> coincidan.
    /// </summary>
    /// <param name="descripcion">Nombre de la <seealso cref="ActividadPractica"/>.</param>
    /// <param name="modalidad">Modalidad en que se realiza la <seealso cref="ActividadPractica"/>.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void EliminarActividad(string descripcion, string modalidad) {
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_eliminar_oficio";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroDescripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar);
      parametroDescripcion.Direction = System.Data.ParameterDirection.Input;
      parametroDescripcion.Value = descripcion;
      comando.Parameters.Add(parametroDescripcion);
      SqlParameter parametroModalidad = new SqlParameter("@modalidad", System.Data.SqlDbType.VarChar);
      parametroModalidad.Direction = System.Data.ParameterDirection.Input;
      parametroModalidad.Value = modalidad;
      comando.Parameters.Add(parametroModalidad);

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
    /// Consulta todas las actividades prácticas registradas en la base de datos.
    /// </summary>
    /// <returns>Una lista con todas las actividades prácticas registradas en el sistema.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadPractica> ConsultarActvidadPractica() {
      SqlDataReader dr = null;
      List<ActividadPractica> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_oficios";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        actividades = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return actividades;
    }
    /// <summary>
    /// Busca una <seealso cref="ActividadPractica"/> específica en la base de datos.
    /// </summary>
    /// <param name="descripcion">La descripción de la <seealso cref="ActividadPractica"/> buscada.</param>
    /// <returns>Una lista de <seealso cref="ActividadPractica"/> cuya descripción coincida con <paramref name="descripcion"/>, si no se encuentra la actividad práctica devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadPractica> BuscarDescripcionActividad(string descripcion) {
      SqlDataReader dr = null;
      List<ActividadPractica> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_oficio";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroDescripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar);
      parametroDescripcion.Direction = System.Data.ParameterDirection.Input;
      parametroDescripcion.Value = descripcion;
      comando.Parameters.Add(parametroDescripcion);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        actividades = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return actividades;
    }
    /// <summary>
    /// Busca una <seealso cref="ActividadPractica"/> específica en la base de datos.
    /// </summary>
    /// <param name="modalidad">La modalidad de la <seealso cref="ActividadPractica"/> buscada.</param>
    /// <returns>Una lista de <seealso cref="ActividadPractica"/> cuya modalidad coincida con <paramref name="modalidad"/>, si no se encuentra la actividad práctica devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadPractica> BuscarModalidadActividad(string modalidad) {
      SqlDataReader dr = null;
      List<ActividadPractica> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_oficio_modalidad";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroModalidad = new SqlParameter("@modalidad", System.Data.SqlDbType.VarChar);
      parametroModalidad.Direction = System.Data.ParameterDirection.Input;
      parametroModalidad.Value = modalidad;
      comando.Parameters.Add(parametroModalidad);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        actividades = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return actividades;
    }
    /// <summary>
    /// Busca una <seealso cref="ActividadPractica"/> específica en la base de datos.
    /// </summary>
    /// <param name="modalidad">La modalidad de la <seealso cref="ActividadPractica"/> buscada.</param>
    /// <param name="descripcion">La descripcion de la <seealso cref="ActividadPractica"/> buscada.</param>
    /// <returns>Una lista de <seealso cref="ActividadPractica"/> cuya <paramref name="modalidad"/> y <paramref name="descripcion"/> coincidan, si no se encuentra la actividad práctica devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadPractica> BuscarDescripcionModalidadActividad(string descripcion, string modalidad) {
      SqlDataReader dr = null;
      List<ActividadPractica> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_oficio_descripcion_modalidad";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      SqlParameter parametroDescripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar);
      parametroDescripcion.Direction = System.Data.ParameterDirection.Input;
      parametroDescripcion.Value = descripcion;
      comando.Parameters.Add(parametroDescripcion);
      SqlParameter parametroModalidad = new SqlParameter("@modalidad", System.Data.SqlDbType.VarChar);
      parametroModalidad.Direction = System.Data.ParameterDirection.Input;
      parametroModalidad.Value = modalidad;
      comando.Parameters.Add(parametroModalidad);
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        actividades = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return actividades;
    }
    /// <summary>
    /// Lee un <see cref="SqlDataReader"/> lleno con datos y devuelve una lista de actividades prácticas recuperadas de este.
    /// </summary>
    /// <param name="datos">Es un <see cref="SqlDataReader"/> que contiene los resultados de una consulta previa.</param>
    /// <returns>Una lista de <seealso cref="ActividadPractica"/> correspondiente a todos los registros de <paramref name="datos"/>.</returns>
    private List<ActividadPractica> LeerResultados(SqlDataReader datos) {
      ActividadPractica actividad = null;
      List<ActividadPractica> actividades = new List<ActividadPractica>();
      while (datos.Read()) {
        actividad = new ActividadPractica();
        actividad.Id = Convert.ToInt32(datos["Id_Oficio"]);
        actividad.Modalidad = datos["Metodo_Oficio"].ToString();
        actividad.Descripcion = datos["Descripcion"].ToString();
        actividad.RemisionDiaria = Convert.ToInt32(datos["RemisionCondena"]);
        actividad.Cupos = Convert.ToInt32(datos["CuposDisponibles"]);
        actividades.Add(actividad);
      }
      return actividades;
    }
  }
}
