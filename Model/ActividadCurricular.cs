using System;


namespace Model {
  /// <summary>
  /// Representa una actividad curricular.
  /// </summary>
  public class ActividadCurricular : Actividad {
    /// <value>Propiedad fechaInicio correspondiente a la fecha de inicio de la actividad curricular.</value>
    private DateTime _fechaInicio;
    /// <value>Propiedad fechaFin correspondiente a la fecha de finalizacion de la actividad curricular.</value>
    private DateTime _fechaFin;
    /// <value>Propiedad remisionTotal correspondiente a la remision total en dias que tiene una actividad curricular.</value>
    private int _remisionTotal;

    /// <summary>
    /// Obtiene o establece la fecha de inicio de la actividad curricular.
    /// </summary>
    /// <returns>Una fecha con el inicio de la actividad curricular.</returns>
    public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }

    /// <summary>
    /// Obtiene o establece la fecha de finalizacion de la actividad curricular.
    /// </summary>
    /// <returns>Una fecha con la finalizacion de la actividad curricular.</returns>
    public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }

    /// <summary>
    /// Obtiene o establece la remision total en dias de la actividad curricular.
    /// </summary>
    /// <returns>Un entero con la remision total en dias de la actividad curricular.</returns>
    public int RemisionTotal { get => _remisionTotal; set => _remisionTotal = value; }

    /// <summary>
    /// Constructor de la clase <c>ActividadCurricular</c> con valores predeterminados."/>).
    /// </summary>
    public ActividadCurricular() { }

    /// <summary>
    /// Constructor de la clase <c>ActividadCurricular</c> que inicializa una nueva actividad curricular a(<paramref name="cupos"/>,<paramref name="descripcion"/>,<paramref name="modalidad"/>,<paramref name="remisionTotal"/>,<paramref name="fechaInicio"/>,<paramref name="fechaFin"/>).
    /// </summary>
    /// <param name="cupos">Corresponde a los cupos de la actividad curricular.</param>
    /// <param name="descripcion">Corresponde a la descripcion de la actividad curricular.</param>
    /// <param name="modalidad">>Corresponde a la modalidad de la actividad curricular.</param>
    /// <param name="remisionTotal">Corresponde a la remision total en dias que tiene una actividad curricular.</param>
    /// <param name="fechaInicio">Corresponde a la fecha de inicio de la actividad curricular.</param>
    /// <param name="fechaFin">Corresponde a la fecha de finalizacion de la actividad curricular.</param>
    public ActividadCurricular(int cupos, string descripcion, string modalidad, int remisionTotal,
                               DateTime fechaInicio, DateTime fechaFin) : base(cupos, descripcion, modalidad) {
      this._fechaInicio = fechaInicio;
      this._fechaFin = fechaFin;
      this._remisionTotal = remisionTotal;
    }

    /// <summary>
    /// Constructor de la clase <c>ActividadCurricular</c> que inicializa una nueva actividad a(<paramref name="cupos"/>,<paramref name="descripcion"/>,<paramref name="modalidad"/>,<paramref name="remisionTotal"/>,<paramref name="fechaInicio"/>,<paramref name="fechaFin"/>).
    /// </summary>
    /// <param name="id">Corresponde al id de la actividad Curricular.</param>
    /// <param name="cupos">Corresponde a los cupos de la actividad.</param>
    /// <param name="descripcion">Corresponde a la descripcion de la actividad.</param>
    /// <param name="modalidad">>Corresponde a la modalidad de la actividad.</param>
    /// <param name="remisionTotal">Corresponde a la remision total en dias que tiene una actividad.</param>
    /// <param name="fechaInicio">Corresponde a la fecha de inicio de la actividad.</param>
    /// <param name="fechaFin">Corresponde a la fecha de finalizacion de la actividad.</param>
    public ActividadCurricular(int id, int cupos, string descripcion, string modalidad, int remisionTotal,
                               DateTime fechaInicio, DateTime fechaFin) : base(cupos, descripcion, modalidad) {
      this._fechaInicio = fechaInicio;
      this._fechaFin = fechaFin;
      this._remisionTotal = remisionTotal;
    }
  }
}
