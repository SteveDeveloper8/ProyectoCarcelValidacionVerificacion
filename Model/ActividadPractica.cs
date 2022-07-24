namespace Model {
  /// <summary>
  /// Representa una actividad practica.
  /// </summary>
  public class ActividadPractica : Actividad {
    /// <value>Propiedad remisionDiaria correspondiente a la fecha de inicio de la actividad practica.</value>
    private int _remisionDiaria;

    /// <summary>
    /// Obtiene o establece la remision diaria en dias de la actividad practica.
    /// </summary>
    /// <returns>Un entero con la remision diaria de la actividad practica.</returns>
    public int RemisionDiaria { get => _remisionDiaria; set => _remisionDiaria = value; }

    /// <summary>
    /// Constructor de la clase <c>ActividadPractica</c> que inicializa una nueva actividad practica a(<paramref name="cupos"/>,<paramref name="descripcion"/>,<paramref name="modalidad"/>,<paramref name="remisionDiaria"/>).
    /// </summary>
    /// <param name="cupos">Corresponde a los cupos de la actividad practica.</param>
    /// <param name="descripcion">Corresponde a la descripcion de la actividad practica.</param>
    /// <param name="modalidad">>Corresponde a la modalidad de la actividad practica.</param>
    /// <param name="remisionDiaria">Corresponde a la remision diaria que tiene una actividad practica.</param>
    public ActividadPractica(int cupos, string descripcion, string modalidad, int remisionDiaria)
                             : base(cupos, descripcion, modalidad) {
      this._remisionDiaria = remisionDiaria;
    }

    /// <summary>
    /// Constructor de la clase <c>ActividadPractica</c> que inicializa una nueva actividad practica a(<paramref name="cupos"/>,<paramref name="descripcion"/>,<paramref name="modalidad"/>,<paramref name="remisionDiaria"/>).
    /// </summary>
    /// <param name="id">Corresponde al id de la actividad practica.</param>
    /// <param name="cupos">Corresponde a los cupos de la actividad practica.</param>
    /// <param name="descripcion">Corresponde a la descripcion de la actividad practica.</param>
    /// <param name="modalidad">>Corresponde a la modalidad de la actividad practica.</param>
    /// <param name="remisionDiaria">Corresponde a la remision diaria que tiene una actividad practica.</param>
    public ActividadPractica(int id, int cupos, string descripcion, string modalidad, int remisionDiaria)
                             : base(id, cupos, descripcion, modalidad) {
      this._remisionDiaria = remisionDiaria;
    }

    /// <summary>
    /// Constructor de la clase <c>ActividadPractica</c> con valores predeterminados."/>).
    /// </summary>
    public ActividadPractica() { }

  }
}
