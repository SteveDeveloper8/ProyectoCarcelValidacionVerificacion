using System;


namespace Model {
  /// <summary>
  /// Representa un cargo.
  /// </summary>
  public class Cargo {
    /// <value>Propiedad id correspondiente al id del cargo.</value>
    private int _id;
    /// <value>Propiedad descripcion correspondiente a la descripción del cargo.</value>
    private string _descripcion;
    /// <value>Propiedad delito correspondiente al delito cometido para que tenga un cargo.</value>
    private string _delito;
    /// <value> Propiedad lugarHechos de tipo <see cref="Lugar"/> que corresponde al lugar de los hechos </value>
    private Lugar _lugarHechos;
    /// <value>Propiedad fechaHechos correspondiente a la fecha de los hechos.</value>
    private DateTime _fechaHechos;

    // <summary>
    /// Obtiene o establece la descripcion del cargo.
    /// </summary>
    /// <returns>Una cadena con la descripcion del cargo.</returns>
    public string Descripcion { get => _descripcion; set => _descripcion = value; }
    // <summary>
    /// Obtiene o establece el delito cometido para que tenga el cargo.
    /// </summary>
    /// <returns>Una cadena con el delito cometido.</returns>
    public string Delito { get => _delito; set => _delito = value; }
    // <summary>
    /// Obtiene o establece el id del cargo.
    /// </summary>
    /// <returns>Una entero con el id del cargo.</returns>
    public int Id { get => _id; set => _id = value; }
    // <summary>
    /// Obtiene o establece el lugar de los hechos.
    /// </summary>
    /// <returns>El lugar donde se cometieron los hechos.</returns>
    public Lugar LugarHechos { get => _lugarHechos; set => _lugarHechos = value; }
    // <summary>
    /// Obtiene o establece la fecha correspondiente del cargo.
    /// </summary>
    /// <returns>Una cadena con la descripcion del cargo.</returns>
    public DateTime FechaHechos { get => _fechaHechos; set => _fechaHechos = value; }

    /// <summary>
    /// Constructor de la clase <c>Cargo</c> que inicializa un nuevo cargo a (<paramref name="descripcion"/>, <paramref name="delito"/>, <paramref name="id"/>, <paramref name="lugarHechos"/>, <paramref name="fechaHechos"/>).
    /// </summary>
    /// <param name="descripcion">Corresponde a la descripcion del cargo.</param>
    /// <param name="delito">Corresponde al delito cometido para que tuviera un cargo</param>
    /// <param name="id">Corresponde al identificador del cargo</param>
    /// <param name="lugarHechos">Corresponde al lugar de los hechos</param>
    /// <param name="fechaHechos">Corresponde a la fecha de los hechos</param>
    public Cargo(string descripcion, string delito, int id, Lugar lugarHechos, DateTime fechaHechos) {
      this._descripcion = descripcion;
      this._delito = delito;
      this._id = id;
      this._lugarHechos = lugarHechos;
      this._fechaHechos = fechaHechos;
    }
    /// <summary>
    /// Constructor de la clase <c>Cargo</c> con valores predeterminados."/>).
    /// </summary>
    public Cargo() { }
  }
}
