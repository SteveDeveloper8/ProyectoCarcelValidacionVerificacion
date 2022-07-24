using System.Collections.Generic;

namespace Model {
  /// <summary>
  /// Representa un Equipo de Trabajo
  /// </summary>
  public class EquipoTrabajo : GrupoActividad {
    /// <value>Propiedad razon diaria redención correspondiente al a la razón diaria de redención del equipo de trabajo.</value>
    private float _razonDiariaRedencion;

    // <summary>
    /// Obtiene o establece la razón diaria de redención.
    /// </summary>
    /// <returns>Un float con la razón diaria de redención.</returns>
    public float RazonDiariaRedencion { get => _razonDiariaRedencion; set => _razonDiariaRedencion = value; }

    /// <summary>
    /// Constructor de la clase <c>EquipoTrabajo</c> que inicializa un nuevo equipo de trabajo a (<paramref name="reclusos"/>, <paramref name="horario"/>, <paramref name="actividad"/>, <paramref name="razonDiariaRedencion"/>).
    /// </summary>
    /// <param name="reclusos">Corresponde a los reclusos que pertenecen al grupo de trabajo</param>
    /// <param name="horario">Corresponde al horario del euipo de trabajo</param>
    /// <param name="actividad">Corresponde a la actividad del equipo de trabajo </param>
    /// <param name="razonDiariaRedencion">Corresponde a la razon diaria de redención del equipo de trabajo</param>
    public EquipoTrabajo(List<Recluso> reclusos, Horario horario, Actividad actividad,
                         float razonDiariaRedencion) : base(reclusos, horario, actividad) {
      this.RazonDiariaRedencion = razonDiariaRedencion;
    }
  }
}
