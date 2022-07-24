namespace Model {
  public class Usuario {
    /// <value>Propiedad id correspondiente al id del usuario.</value>
    private int _id;
    /// <value>Propiedad nombres correspondiente a los nombres del usuario.</value>
    private string _nombres;
    /// <value>Propiedad apellidos correspondiente a los apellidos del usuario.</value>
    private string _apellidos;
    /// <value>Propiedad username correspondiente al nombre de usuario del usuario.</value>
    private string _username;
    /// <value>Propiedad contraseña correspondiente a la contraseña del usuario.</value>
    private string _contrasena;
    /// <value> Propiedad Rol de tipo <see cref="Rol"/> que corresponde al rol del usuario. </value>
    private Rol _rol = new Rol();

    // <summary>
    /// Obtiene o establece el id del usuario.
    /// </summary>
    /// <returns>Una entero con el id del usuario.</returns>
    public int Id { get => _id; set => _id = value; }
    /// <summary>
    /// Obtiene o establece los nombres del usuario.
    /// </summary>
    /// <returns>Una cadena con los nombres del usuario.</returns>
    public string Nombres { get => _nombres; set => _nombres = value; }
    /// <summary>
    /// Obtiene o establece los apellidos del usuario.
    /// </summary>
    /// <returns>Una cadena con los apellidos del usuario.</returns>
    public string Apellidos { get => _apellidos; set => _apellidos = value; }
    /// <summary>
    /// Obtiene o establece el nombre de usuario del usuario.
    /// </summary>
    /// <returns>Una cadena con el nombre de usuario del usuario.</returns>
    public string Username { get => _username; set => _username = value; }
    /// <summary>
    /// Obtiene o establece la contraseña del usuario.
    /// </summary>
    /// <returns>Una cadena con la contraseña del usuario.</returns>
    public string Contrasena { get => _contrasena; set => _contrasena = value; }
    /// Obtiene o establece el rol del usuario.
    /// </summary>
    /// <returns>El rol del usuario.</returns>
    public Rol Rol { get => _rol; set => _rol = value; }

    /// <summary>
    /// Constructor de la clase <c>Usuario</c> que inicializa un nuevo usuasrio a (<paramref name="id"/>, <paramref name="nombres"/>, <paramref name="apellidos"/>, <paramref name="username"/>, <paramref name="contrasena", <paramref name="rol"/>).
    /// </summary>
    /// <param name="id">Corresponde al id del usuario.</param>
    /// <param name="nombres">Corresponde a los nombres del usuario.</param>
    /// <param name="apellidos">Corresponde a los apellidos del usuario.</param>
    /// <param name="username">Corresponde al nombre de usuario del usuario.</param>
    /// <param name="contrasena">Corresponde a la contraseña del usuario.</param>
    /// <param name="rol">Corresponde al rol del usuario.</param>
    public Usuario(int id, string nombres, string apellidos, string username,
                   string contrasena, Rol rol) {
      this._id = id;
      this._nombres = nombres;
      this._apellidos = apellidos;
      this._username = username;
      this._contrasena = contrasena;
      this._rol = rol;
    }
    /// <summary>
    /// Constructor de la clase <c>Usuario</c> que inicializa un nuevo usuasrio a (<paramref name="nombres"/>, <paramref name="apellidos"/>, <paramref name="username"/>, <paramref name="contrasena", <paramref name="rol"/>).
    /// </summary>
    /// <param name="nombres">Corresponde a los nombres del usuario.</param>
    /// <param name="apellidos">Corresponde a los apellidos del usuario.</param>
    /// <param name="username">Corresponde al nombre de usuario del usuario.</param>
    /// <param name="contrasena">Corresponde a la contraseña del usuario.</param>
    /// <param name="rol">Corresponde al rol del usuario.</param>
    public Usuario(string nombres, string apellidos, string username,
                   string contrasena, Rol rol) {
      this._nombres = nombres;
      this._apellidos = apellidos;
      this._username = username;
      this._contrasena = contrasena;
      Rol = rol;
    }
    /// <summary>
    /// Constructor de la clase <c>Usuario</c> con valores predeterminados.
    /// </summary>
    public Usuario() {
    }

  }

}
