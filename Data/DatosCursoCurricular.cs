using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Data.Excepciones;

using Model;

namespace Data {
  /// <summary>
  /// Esta clase permite el acceso a los datos de <see cref="ActividadCurricular"/> en la base de datos del sistema.
  /// </summary>
  /// <remarks>Esta clase ejecuta procedimientos almacenados en la base de datos.</remarks>
  public class DatosCursoCurricular {
    /// <summary>
    /// Es la <see cref="Conexion"/> con la base de datos del sistema.
    /// </summary>
    /// <remarks>Es necesaria para establecer copmunicación entre la aplicación y el servidor de bases de datos.</remarks>
    Conexion _conexion;
    /// <summary>
    /// Inicializa la <see cref="Conexion"/>.
    /// </summary>
    public DatosCursoCurricular() {
      _conexion = new Conexion();
    }
    /// <summary>
    /// Inserta una nueva <seealso cref="ActividadCurricular"/>(<paramref name="actividad"/>) en la base de datos del sistema.
    /// </summary>
    /// <param name="actividad">Nueva <seealso cref="ActividadCurricular"/> a insertar en la base de datos.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void InsertarEstudio(ActividadCurricular actividad) {
      //Crear comando para procedimeitnos almacenados.
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_ingresar_estudio";
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
      parametroRemision.Value = actividad.RemisionTotal;
      comando.Parameters.Add(parametroRemision);
      SqlParameter parametroCupos = new SqlParameter("@cuposDisponibles", System.Data.SqlDbType.Int);
      parametroCupos.Direction = System.Data.ParameterDirection.Input;
      parametroCupos.Value = actividad.Cupos;
      comando.Parameters.Add(parametroCupos);
      SqlParameter parametroFechaInicio = new SqlParameter("@fechaInicio", System.Data.SqlDbType.DateTime);
      parametroFechaInicio.Direction = System.Data.ParameterDirection.Input;
      parametroFechaInicio.Value = actividad.FechaInicio;
      comando.Parameters.Add(parametroFechaInicio);
      SqlParameter parametroFechaFin = new SqlParameter("@fechaFin", System.Data.SqlDbType.DateTime);
      parametroFechaFin.Direction = System.Data.ParameterDirection.Input;
      parametroFechaFin.Value = actividad.FechaFin;
      comando.Parameters.Add(parametroFechaFin);

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
    /// Eliina un registro de <seealso cref="ActividadCurricular"/> de la base de datos del sistema cuya <paramref name="descripcion"/> y <paramref name="modalidad"/> coincidan.
    /// </summary>
    /// <param name="descripcion">Nombre de la <seealso cref="ActividadCurricular"/>.</param>
    /// <param name="modalidad">Modalidad en que se realiza la <seealso cref="ActividadCurricular"/>.</param>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public void EliminarEstudio(string descripcion, string modalidad) {
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_eliminar_estudios";
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
    /// Consulta la base de datos y trae las actividades que coincidan con la <paramref name="descripcion"/>.
    /// </summary>
    /// <param name="descripcion">Es el nombre de la actividad curricular.</param>
    /// <returns>Una lista de obejetos con los datos de cada <seealso cref="ActividadCurricular"/>.</returns>
    public List<ActividadCurricular> BuscarDescripcionEstudio(string descripcion) {
      SqlDataReader dr = null;
      List<ActividadCurricular> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_buscar_estudio";
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
    /// Lee un <see cref="SqlDataReader"/> lleno con datos y devuelve una lista de actividades curriculares recuperadas de este.
    /// </summary>
    /// <param name="datos">Es un <see cref="SqlDataReader"/> que contiene los resultados de una consulta previa.</param>
    /// <returns>Una lista de <seealso cref="ActividadCurricular"/> correspondiente a todos los registros de <paramref name="datos"/>.</returns>
    private List<ActividadCurricular> LeerResultados(SqlDataReader datos) {
      ActividadCurricular actividad = null;
      List<ActividadCurricular> actividades = new List<ActividadCurricular>();
      while (datos.Read()) {
        actividad = new ActividadCurricular();
        actividad.Id = Convert.ToInt32(datos["Id_Estudios"]);
        actividad.Modalidad = datos["MetodoEstudio"].ToString();
        actividad.Descripcion = datos["Descripcion"].ToString();
        actividad.RemisionTotal = Convert.ToInt32(datos["RemisionCondena"]);
        actividad.Cupos = Convert.ToInt32(datos["CuposDisponibles"]);
        actividad.FechaInicio = Convert.ToDateTime(datos["FechaInicio"]);
        actividad.FechaFin = Convert.ToDateTime(datos["FechaFin"]);
        actividades.Add(actividad);
      }
      return actividades;
    }
    /// <summary>
    /// Consulta todas las actividades curriculares registradas en la base de datos.
    /// </summary>
    /// <returns>Una lista con todas las actividades curriculares registradas en el sistema.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadCurricular> ConsultarCursosDistancia() {
      SqlDataReader dr = null;
      List<ActividadCurricular> cursos;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_estudios_distancia";
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      try {
        _conexion.Conectar();
        comando.Connection = _conexion.Cn;
        dr = comando.ExecuteReader();

        cursos = LeerResultados(dr);
      } catch (SqlException) {
        throw new ConsultaFallida();
      }
      return cursos;
    }
    /// <summary>
    /// Busca una <seealso cref="ActividadCurricular"/> específica en la base de datos.
    /// </summary>
    /// <param name="modalidad">La modalidad de la <seealso cref="ActividadCurricular"/> buscada.</param>
    /// <returns>Una lista de <seealso cref="ActividadCurricular"/> cuya modalidad coincida con <paramref name="modalidad"/>, si no se encuentra la actividad curricular devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadCurricular> BuscarModalidadEstudio(string modalidad) {
      SqlDataReader dr = null;
      List<ActividadCurricular> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_estudios_modalidad";
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
    /// Busca una <seealso cref="ActividadCurricular"/> específica en la base de datos.
    /// </summary>
    /// <param name="modalidad">La modalidad de la <seealso cref="ActividadCurricular"/> buscada.</param>
    /// <param name="descripcion">La descripcion de la <seealso cref="ActividadCurricular"/> buscada.</param>
    /// <returns>Una lista de <seealso cref="ActividadCurricular"/> cuya <paramref name="modalidad"/> y <paramref name="descripcion"/> coincidan, si no se encuentra la actividad curricular devuelve null.</returns>
    /// <exception cref="ConsultaFallida">Cuando se da un error al consultar la base de datos.</exception>
    public List<ActividadCurricular> BuscarDescripcionModalidadEstudio(string descripcion, string modalidad) {
      SqlDataReader dr = null;
      List<ActividadCurricular> actividades;
      SqlCommand comando = new SqlCommand();
      comando.CommandText = "spr_consultar_estudios_descripcion_modalidad";
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
      } catch (SqlException ex) {
        Console.WriteLine(ex.Message);
        throw new ConsultaFallida();
      }
      return actividades;
    }
  }
}
