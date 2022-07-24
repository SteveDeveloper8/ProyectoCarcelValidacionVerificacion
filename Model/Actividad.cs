namespace Model {
  /// <summary>
  /// Representa una actividad.
  /// </summary>
  public abstract class Actividad {
    /// <value>Propiedad id correspondiente al id de la actividad.</value>
    private int _id;
    /// <value>Propiedad cupos correspondiente a los cupos de la actividad.</value>
    private int _cupos;
    /// <value>Propiedad descripcion correspondiente a la descripcion de la actividad.</value>
    private string _descripcion;
    /// <value>Propiedad modalidad correspondiente a la modalidad de la actividad.</value>
    private string _modalidad;


    /// <summary>
    /// Obtiene o establece el id de la actividad.
    /// </summary>
    /// <returns>Un entero con el id de la actividad.</returns>
    public int Id { get => _id; set => _id = value; }

    /// <summary>
    /// Obtiene o establece los cupos de la actividad.
    /// </summary>
    /// <returns>Un entero con los cupos de la actividad.</returns>
    public int Cupos { get => _cupos; set => _cupos = value; }

    /// <summary>
    /// Obtiene o establece la descripcion de la actividad.
    /// </summary>
    /// <return>Una cadena con la descripción de la actividad.</return>
    public string Descripcion { get => _descripcion; set => _descripcion = value; }

    /// <summary>
    /// Obtiene o establece la modalidad de la actividad.
    /// </summary>
    /// <returns>Una cadena con la modalidad de la actividad. </returns>
    public string Modalidad { get => _modalidad; set => _modalidad = value; }


    /// <summary>
    /// Constructor de la clase <c>Actividad</c> que inicializa una nueva actividad a (<paramref name="cupos"/>, <paramref name="descripcion"/>, <paramref name="modalidad"/>).
    /// </summary>
    /// <param name="cupos">Corresponde a los cupos de la actividad.</param>
    /// <param name="descripcion">Corresponde a la descipcion de la actividad.</param>
    /// <param name="modalidad">Corresponde a la modalidad de la actividad.</param>
    public Actividad(int cupos, string descripcion, string modalidad) {
      this._cupos = cupos;
      this._descripcion = descripcion;
      this._modalidad = modalidad;
    }

    /// <summary>
    /// Constructor de la clase <c>Actividad</c> que inicializa una nueva actividad a (<paramref name="cupos"/>, <paramref name="descripcion"/>, <paramref name="modalidad"/>).
    /// </summary>
    /// <param name="id">Corresponde a el id  de la actividad.</param>
    /// <param name="cupos">Corresponde a los cupos de la actividad.</param>
    /// <param name="descripcion">Corresponde a la descripcion de la actividad.</param>
    /// <param name="modalidad">Corresponde a la modalidad de la actividad.</param>
    public Actividad(int id, int cupos, string descripcion, string modalidad) {
      this._cupos = cupos;
      this._descripcion = descripcion;
      this._modalidad = modalidad;

    }

    /// <summary>
    /// Constructor de la clase <c>Actividad</c> con valores predeterminados.
    /// </summary>
    public Actividad() { }



  }
}
