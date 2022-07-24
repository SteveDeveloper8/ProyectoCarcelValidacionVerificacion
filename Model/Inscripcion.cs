using System;


namespace Model {
  /// <summary>
  /// Representa una Inscripción.
  /// </summary>
  class Inscripcion {
    /// <value>Propiedad id correspondiente al id del cargo.</value>
    private int _id;
    /// <value> Propiedad recluso de tipo <see cref="Recluso"/> que corresponde al recluso de la inscripción </value>
    private Recluso _recluso;
    /// <value> Propiedad actividad de tipo <see cref="Actividad"/> que corresponde a la actividad de la inscripción </value>
    private Actividad _actividad;
    /// <value>Propiedad fecha correspondiente a la fecha de la Inscripción.</value>
    private DateTime _fecha;
    /// <value>Propiedad codigoInscripcion correspondiente al código de la inscripción.</value>
    private int _codigoInscripcion;

    // <summary>
    /// Obtiene o establece el id de la inscripción.
    /// </summary>
    /// <returns>Un entero con el id de la inscripción.</returns>
    public int Id { get => _id; set => _id = value; }
    // <summary>
    /// Obtiene o establece el recluso de la inscripción.
    /// </summary>
    /// <returns>Un recluso de la inscripción.</returns>
    public Recluso Recluso { get => _recluso; set => _recluso = value; }
    // <summary>
    /// Obtiene o establece la actividad de la inscripción.
    /// </summary>
    /// <returns>Una actividad de la inscripción.</returns>
    public Actividad Actividad { get => _actividad; set => _actividad = value; }
    // <summary>
    /// Obtiene o establece la fecha de la inscripción.
    /// </summary>
    /// <returns>Una fecha de la inscripción.</returns>
    public DateTime Fecha { get => _fecha; set => _fecha = value; }
    // <summary>
    /// Obtiene o establece el código de la inscripción.
    /// </summary>
    /// <returns>Un entero con el código de la inscripción.</returns>
    public int CodigoInscripcion { get => _codigoInscripcion; set => _codigoInscripcion = value; }

    /// <summary>
    /// Constructor de la clase <c>Inscripcion</c> con valores predeterminados."/>).
    /// </summary>
    public Inscripcion() {
    }
    /// <summary>
    /// Constructor de la clase <c>Inscripcion</c> que inicializa una nueva inscripción a (<paramref name="id"/>, <paramref name="recluso"/>, <paramref name="actividad"/>, <paramref name="fecha"/>, <paramref name="codigoInscripcion"/>).
    /// </summary>
    /// <param name="id">Corresponde al identificador de la inscripción</param>
    /// <param name="recluso">Corresponde al recluso de la inscripción</param>
    /// <param name="actividad">Corresponde a la actividad de la inscripción</param>
    /// <param name="fecha">Corresponde a la fecha de la inscripción</param>
    /// <param name="codigoInscripcion">Corresponde al código de la inscripción</param>
    public Inscripcion(int id, Recluso recluso, Actividad actividad,
                   DateTime fecha, int codigoInscripcion) {
      this._id = id;
      this._recluso = recluso;
      this._actividad = actividad;
      this._fecha = fecha;
      this._codigoInscripcion = codigoInscripcion;
    }
  }
}
