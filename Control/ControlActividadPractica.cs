using System;
using System.Collections.Generic;

using Data;
using Data.Excepciones;

using Model;


namespace Control {
  /// <summary>
  /// Controlador que gestiona la información de <seealso cref="ActividadPractica"/>.
  /// </summary>
  public class ControlActividadPractica {
    /// <summary>
    /// Atributo tipo <see cref="DatosActividadPractica"/> que permite el acceso a la capa de Datos.
    /// </summary>
    DatosActividadPractica _datosActividad = new DatosActividadPractica();
    /// <summary>
    /// Instancia de <see cref="ActividadPractica"/> sirve como auxiliar para los métodos de control.
    /// </summary>
    ActividadPractica _actividad = null;

    ///<summary>
    ///Metodo que se encarga de consultar actividades existentes.
    ///</summary>
    ///<return>Retorna una lista de actividades</return>
    public List<Object> ListarActividadesPracticas() {
      List<ActividadPractica> actividades = _datosActividad.ConsultarActvidadPractica();
      if (actividades.Count <= 0) {
        throw new GeneralExcepcion("No se encontraron actividades registrados");
      } else {
        return ObtenerListaDatosActividades(actividades);
      }
    }
    ///<summary>
    ///Metodo que se encarga de guardar la actividad.
    ///</summary>
    ///<param name= "cupos"> Numero de cupos </param>
    ///<param name= "descripcion"> descripcion del curso </param>
    ///<param name= "remision"> Numero de dias de remision de condena </param>
    ///<param name= "fechaInicio"> Fecha de inicio del curso </param>
    ///<param name= "fechaFin"> Fecha de fin del curso</param>
    public Object GuardarActividadPractica(int cupos, string descripcion, int remision,
                                           string modalidad) {
      _actividad = new ActividadPractica(cupos, descripcion, modalidad, remision);
      _datosActividad.InsertarActividad(_actividad);
      return ConvertirAnonimo(_actividad);
    }
    ///<summary>
    ///Metodo que se encarga de eliminar una actividad especifico
    ///</summary>
    ///<param name= "estudioDelete"> Nombre de la actividad </param>
    public bool EliminarActividadPractica(string actividadDelete, string modalidad) {
      try {
        _datosActividad.EliminarActividad(actividadDelete, modalidad);
        return true;
      } catch (ConsultaFallida) {
        return false;
      }
    }
    ///<summary>
    ///Metodo que se encarga de buscar actividades a partir de una descripcion.
    ///</summary>
    ///<param name= "descripcion"> Descripcion de la actividad </param>
    //////<return>Retorna una lista de actividades </return>
    public List<Object> FiltrarDescripcion(string descripcion) {
      List<ActividadPractica> actividad = _datosActividad.BuscarDescripcionActividad(descripcion);
      if (actividad == null) {
        throw new GeneralExcepcion("Actividad no existe con esa descripcion");
      }
      return ObtenerListaDatosActividades(actividad);
    }
    ///<summary>
    ///Metodo que se encarga de buscar actividades a partir de su modalidad.
    ///</summary>
    ///<param name= "modalidad"> Modalidad de la actividad </param>
    ///<return>Retorna una lista de actividades </return>
    public List<Object> FiltrarModalidad(string modalidad) {
      List<ActividadPractica> actividad = _datosActividad.BuscarModalidadActividad(modalidad);
      if (actividad == null) {
        throw new GeneralExcepcion("No existen actividades con dicha modalidad");
      }
      return ObtenerListaDatosActividades(actividad);
    }
    ///<summary>
    ///Metodo que se encarga de buscar actividades a partir de su descripcion y modalidad.
    ///</summary>
    ///<param name= "descripcion"> Descripcion de la actividad </param>
    ///<param name= "modalidad"> Modalidad de la actividad </param>
    ///<return>Retorna una lista de actividades </return>
    public List<Object> FiltrarDescripcionModalidad(string descripcion, string modalidad) {
      List<ActividadPractica> actividad = _datosActividad.BuscarDescripcionModalidadActividad(descripcion,
                                                                                             modalidad);
      if (actividad == null) {
        throw new GeneralExcepcion("Actividad no existe");
      }
      return ObtenerListaDatosActividades(actividad);
    }
    /// <summary>
    /// Convierte una lista de objetos <seealso cref="ActividadPractica"/> en una lista de objetos anónimos(<seealso cref="Object"/>) que la capa de vista pueda entender.
    /// </summary>
    /// <param name="actividades">Lista de actividades a convertir.</param>
    /// <returns>Una lista de objetos anónimos(<seealso cref="Object"/>).</returns>
    private List<Object> ObtenerListaDatosActividades(List<ActividadPractica> actividades) {
      List<Object> cargosDatos = new List<object>();
      foreach (ActividadPractica actividad in actividades) {
        cargosDatos.Add(ConvertirAnonimo(actividad));
      }
      return cargosDatos;
    }
    /// <summary>
    /// Convierte un objeto <seealso cref="ActividadPractica"/> en un objeto anónimo(<seealso cref="Object"/>) que la capa de Vista puede entender.
    /// </summary>
    /// <param name="actividad">Actividad a convertir.</param>
    /// <returns>Un <seealso cref="Object"/> con los datos de la <paramref name="actividad"/>.</returns>
    private Object ConvertirAnonimo(ActividadPractica actividad) {
      return new {
        cupos = actividad.Cupos,
        descripcion = actividad.Descripcion,
        modalidad = actividad.Modalidad,
        remisionDiaria = actividad.RemisionDiaria
      };
    }
  }
}
