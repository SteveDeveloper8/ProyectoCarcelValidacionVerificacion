using System.Collections.Generic;


namespace Model {
  /// <summary>
  /// Representa un Curso
  /// </summary>  
  public class Curso : GrupoActividad {
    /// <value>Propiedad totalDiasRedencion correspondiente al tiempo de redención asignado al curso.</value>
    private int _totalDiasRedencion;
    /// <value>Propiedad diasDuracion correspondiente al tiempo de duración del curso.</value>
    private int _diasDuracion;

    /// <summary>
    /// Obtiene o establece el total de días de redención
    /// </summary>
    /// <returns>Un entero con los días de redención.</returns>
    public int TotalDiasRedencion { get => _totalDiasRedencion; set => _totalDiasRedencion = value; }
    /// <summary>
    /// Obtiene o establece el total de días de duración
    /// </summary>
    /// <returns>Un entero con los días de duración del curso.</returns>
    public int DiasDuracion { get => _diasDuracion; set => _diasDuracion = value; }

    /// <summary>
    /// Constructor de la clase <c>Curso</c> que inicializa un nuevo curso a (<paramref name="reclusos"/>, <paramref name="horario"/>, <paramref name="actividad"/>, <paramref name="totalDiasRedencion"/>, <paramref name="diasDuracion"/>).
    /// </summary>
    /// <param name="reclusos">Corresponde a los reclusos que pertenecen al curso</param>
    /// <param name="horario">Corresponde al horario del curso</param>
    /// <param name="actividad">Corresponde a la actividad asignada en el curso</param>
    /// <param name="totalDiasRedencion">Corresponde a los días de redención </param>
    /// <param name="diasDuracion">Corresponde a los días de duración</param>
    public Curso(List<Recluso> reclusos, Horario horario, Actividad actividad, int totalDiasRedencion,
                 int diasDuracion) : base(reclusos, horario, actividad) {
      this._totalDiasRedencion = totalDiasRedencion;
      this._diasDuracion = diasDuracion;
    }
  }
}
