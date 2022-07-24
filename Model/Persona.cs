using System;


namespace Model {
  /// <summary>
  /// Representa una Persona.
  /// </summary>
  public abstract class Persona {
    /// <value>Propiedad id correspondiente al id de la persona.</value>
    private int _id;
    /// <value>Propiedad nombre correspondiente al nombre de la persona.</value>
    private string _nombre;
    /// <value>Propiedad apellidos correspondiente a los apellidos de la persona.</value>
    private string _apellidos;
    /// <value>Propiedad genero correspondiente al genero de la persona.</value>
    private string _genero;
    /// <value>Propiedad fecha correspondiente a la fecha de nacimiento de la persona.</value>
    private DateTime _fecha;
    /// <value>Propiedad cedula correspondiente a la cédula de la persona.</value>
    private string _cedula;


    /// // <summary>
    /// Obtiene o establece el nombre de la persona.
    /// </summary>
    /// <returns>Una cadena con el nombre de la persona.</returns>
    public string Nombre { get => _nombre; set => _nombre = value; }
    // <summary>
    /// Obtiene o establece los apellidos de la persona.
    /// </summary>
    /// <returns>Una cadena con los apellidos de la persona.</returns>
    public string Apellidos { get => _apellidos; set => _apellidos = value; }
    // <summary>
    /// Obtiene o establece el genero de la persona.
    /// </summary>
    /// <returns>Una cadena con el genero de la persona.</returns>
    public string Genero { get => _genero; set => _genero = value; }
    // <summary>
    /// Obtiene o establece la fecha de nacimiento de la persona.
    /// </summary>
    /// <returns>Un DateTime con la fecha de nacimiento de la persona.</returns>
    public DateTime Fecha { get => _fecha; set => _fecha = value; }
    // <summary>
    /// Obtiene o establece el id de la persona.
    /// </summary>
    /// <returns>Un entero con el id de la persona.</returns>
    public int Id { get => _id; set => _id = value; }
    // <summary>
    /// Obtiene o establece la cédula de la persona.
    /// </summary>
    /// <returns>Una cadena con la la cédula de la persona.</returns>
    public string Cedula { get => _cedula; set => _cedula = value; }

    /// <summary>
    /// Constructor de la clase <c>Persona</c> que inicializa un nuevo cargo a (<paramref name="codigo"/>, <paramref name="nombre"/>, <paramref name="apellidos"/>, <paramref name="genero"/>, <paramref name="fecha"/>, <paramref name="cedula"/>).
    /// </summary>
    /// <param name="codigo">Corresponde al código de la persona.</param>
    /// <param name="nombre">Corresponde a nombre de la persona.</param>
    /// <param name="apellidos">Corresponde a los apellidos de la persona.</param>
    /// <param name="genero">Corresponde al genero de la persona.</param>
    /// <param name="fecha">Corresponde a la fecha de nacimiento de la persona.</param>
    /// <param name="cedula">Corresponde a la cédula de la persona.</param>
    public Persona(string codigo, string nombre, string apellidos, string genero,
               DateTime fecha, string cedula) {
      this._nombre = nombre;
      this._apellidos = apellidos;
      this._genero = genero;
      this._fecha = fecha;
      this._cedula = cedula;
    }
    /// <summary>
    /// Constructor de la clase <c>Persona</c> que inicializa un nuevo cargo a (<paramref name="id"/>, <paramref name="codigo"/>, <paramref name="nombre"/>, <paramref name="apellidos"/>, <paramref name="genero"/>, <paramref name="fecha"/>, <paramref name="cedula"/>).
    /// </summary>
    /// <param name="id">Corresponde al id de la persona.</param>
    /// <param name="codigo">Corresponde al código de la persona.</param>
    /// <param name="nombre">Corresponde a nombre de la persona.</param>
    /// <param name="apellidos">Corresponde a los apellidos de la persona.</param>
    /// <param name="genero">Corresponde al genero de la persona.</param>
    /// <param name="fecha">Corresponde a la fecha de nacimiento de la persona.</param>
    /// <param name="cedula">Corresponde a la cédula de la persona.</param>


    public Persona(int id, string codigo, string nombre, string apellidos, string genero,
               DateTime fecha, string cedula) {
      this._nombre = nombre;
      this._apellidos = apellidos;
      this._genero = genero;
      this._fecha = fecha;
      this._cedula = cedula;
    }
    /// <summary>
    /// Constructor de la clase <c>Persona</c> con valores predeterminados."/>).
    /// </summary>
    public Persona() { }
  }
}
