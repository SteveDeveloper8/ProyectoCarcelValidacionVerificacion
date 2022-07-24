using System.Collections.Generic;


namespace Model {
  /// <summary>
  /// Representa un Grupo de Actividad.
  /// </summary>
  public abstract class GrupoActividad {
    /// <value>Propiedad reclusos <see cref="Recluso"/> que corresponde al recluso del grupo de actividad </value>
    private List<Recluso> _reclusos;
    /// <value>Propiedad horario correspondiente al horario del grupo de actividad.</value>
    private Horario _horario;
    /// <value>Propiedad actividad correspondiente a la actividad que se realiza en el grupo.</value>
    private Actividad _actividad;

    // <summary>
    /// Obtiene o establece la lista de reclusos del grupo de actividad.
    /// </summary>
    /// <returns>Una lista con los reclusos del grupo de actividad.</returns>
    public List<Recluso> Reclusos { get => _reclusos; set => _reclusos = value; }
    // <summary>
    /// Obtiene o establece el horario del grupo de actividad.
    /// </summary>
    /// <returns>El horario del grupo de actividad.</returns>
    public Horario Horario { get => _horario; set => _horario = value; }
    // <summary>
    /// Obtiene o establece la actividad del grupo.
    /// </summary>
    /// <returns>Una cadena con la descripcion del cargo.</returns>
    public Actividad Actividad { get => _actividad; set => _actividad = value; }

    /// <summary>
    /// Constructor de la clase <c>GrupoActividad</c> que inicializa un nuevo grupo de actividad a (<paramref name="reclusos"/>, <paramref name="horario"/>, <paramref name="actividad"/>).
    /// </summary>
    /// <param name="reclusos">Corresponde al recluso del grupo de actividad.</param>
    /// <param name="horario">Corresponde al horario del grupo de actividad.</param>
    /// <param name="actividad">Corresponde a la actividad del grupo.</param>

    protected GrupoActividad(List<Recluso> reclusos, Horario horario, Actividad actividad) {
      this._reclusos = reclusos;
      this._horario = horario;
      this._actividad = actividad;
    }
  }
}
