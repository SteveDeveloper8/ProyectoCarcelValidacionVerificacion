namespace Model {
  /// <summary>
  /// Representa el rol de un usuario.
  /// </summary>
  public class Rol {
    /// <value>Propiedad id correspondiente al id del rol.</value>
    private int _id;
    /// <value>Propiedad descripcion correspondiente a la descripción del rol.</value>
    private string _descripcion;

    // <summary>
    /// Obtiene o establece el id del rol.
    /// </summary>
    /// <returns>Una entero con el id del rol.</returns>
    public int Id { get => _id; set => _id = value; }
    // <summary>
    /// Obtiene o establece la descripcion del rol.
    /// </summary>
    /// <returns>Una cadena con la descripcion del rol.</returns>
    public string Descripcion { get => _descripcion; set => _descripcion = value; }

    /// <summary>
    /// Constructor de la clase <c>Rol</c> que inicializa un nuevo rol a (<paramref name="id"/>, <paramref name="descripcion"/>).
    /// </summary>
    /// <param name="id">Corresponde al id del rol.</param>
    /// <param name="descripcion">Corresponde a la descripcion del rol.</param>
    public Rol(int id, string descripcion) {
      this._id = id;
      this._descripcion = descripcion;
    }
    /// <summary>
    /// Constructor de la clase <c>Rol</c> con valores predeterminados.".
    /// </summary>
    public Rol() {
    }


    /// <summary>
    /// Constructor de la clase <c>Rol</c> que inicializa un nuevo rol a (<paramref name="descripcion"/>).
    /// </summary>
    /// <param name="descripcion">Corresponde a la descripcion del rol.</param>
    public Rol(string descripcion) {
      this._descripcion = descripcion;
    }
  }
}
