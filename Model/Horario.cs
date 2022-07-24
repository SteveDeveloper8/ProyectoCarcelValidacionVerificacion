using System.Collections.Generic;


namespace Model {
  /// <summary>
  /// Representa un Horario.
  /// </summary>
  public class Horario {
    /// <value> Propiedad jornadas de tipo <see cref="Jornada"/> que corresponde a la jornada del horario </value>
    private List<Jornada> _jornadas;

    // <summary>
    /// Obtiene o establece la lista de jornadas del horario.
    /// </summary>
    /// <returns>Una lista con las jornadas del horario.</returns>
    public List<Jornada> Jornadas { get => _jornadas; set => _jornadas = value; }

    /// <summary>
    /// Constructor de la clase <c>Horario</c> que inicializa un nuevo horario a (<paramref name="fechaHechos"/>).
    /// </summary>
    /// <param name="jornadas">Corresponde a las jornadas del horario</param>
    public Horario(List<Jornada> jornadas) {
      this._jornadas = jornadas;
    }
  }
}
