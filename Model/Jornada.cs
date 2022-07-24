using System;


namespace Model {
  /// <summary>
  /// Representa una Jornada.
  /// </summary>
  public class Jornada {
    /// <value>Propiedad dia correspondiente al dia de la jornada.</value>
    private string _dia;
    /// <value>Propiedad horaInicio correspondiente a la hora inicio del dia de la jornada.</value>
    private DateTime _horaInicio;
    /// <value>Propiedad horaFin correspondiente a la hora fin del dia de la jornada.</value>
    private DateTime _horaFin;

    // <summary>
    /// Obtiene o establece el día de la jornada.
    /// </summary>
    /// <returns>Una cadena con el día de la jornada.</returns>
    public string Dia { get => _dia; set => _dia = value; }
    // <summary>
    /// Obtiene o establece la hora inicio de la jornada.
    /// </summary>
    /// <returns>Un DateTime con la hora de inicio de la jornada.</returns>
    public DateTime HoraInicio { get => _horaInicio; set => _horaInicio = value; }
    // <summary>
    /// Obtiene o establece la hora fin de la jornada.
    /// </summary>
    /// <returns>Un DateTime con la hora fin de la jornada.</returns>
    public DateTime HoraFin { get => _horaFin; set => _horaFin = value; }

    /// <summary>
    /// Constructor de la clase <c>Jornada</c> que inicializa una nueva jornada a (<paramref name="dia"/>, <paramref name="horaInicio"/>, <paramref name="horaFin"/>).
    /// </summary>
    /// <param name="dia">Corresponde al día de la jornada.</param>
    /// <param name="horaInicio">Corresponde a la hora de inicio de la jornada.</param>
    /// <param name="horaFin">Corresponde a la hora de fin de la jornada.</param>
    public Jornada(string dia, DateTime horaInicio, DateTime horaFin) {
      this._dia = dia;
      this._horaInicio = horaInicio;
      this._horaFin = horaFin;
    }
  }
}
