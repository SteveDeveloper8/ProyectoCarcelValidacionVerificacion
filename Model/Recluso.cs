using System;


namespace Model {
  /// <summary>
  /// Representa un recluso.
  /// </summary>
  public class Recluso : Persona {
    /// <value>Propiedad codigo correspondiente al codigo del recluso.</value>
    private string _codigo;
    /// <value> Propiedad expediente de tipo <see cref="Expediente"/> que corresponde al expediente del recluso </value>
    private Expediente _expediente;
    // <summary>
    /// Obtiene o establece el expediente de recluso.
    /// </summary>
    /// <returns>El expediente del recluso.</returns>
    public Expediente Expediente { get => _expediente; set => _expediente = value; }
    // <summary>
    /// Obtiene o establece el codigo del recluso.
    /// </summary>
    /// <returns>Una cadena con el codigo del recluso.</returns>
    public string Codigo { get => _codigo; set => _codigo = value; }


    /// <summary>
    /// Constructor de la clase <c>Recluso</c> que inicializa un nuevo recluso a (<paramref name="nombre"/>, <paramref name="apellidos"/>, <paramref name="genero"/>, <paramref name="fecha"/>, <paramref name="cedula", <paramref name="codigo", <paramref name="expediente"/>).
    /// </summary>
    /// <param name="nombre">Corresponde al nombre del recluso.</param>
    /// <param name="apellidos">Corresponde a los apellidos del recluso.</param>
    /// <param name="genero">Corresponde al genero del recluso.</param>
    /// <param name="fecha">Corresponde a la fecha de nacimiento del recluso.</param>
    /// <param name="cedula">Corresponde a la cedula del recluso.</param>
    /// <param name="codigo">Corresponde al codigo del recluso.</param>
    /// <param name="expediente">Corresponde al expediente del recluso.</param>
    public Recluso(string nombre, string apellidos, string genero, DateTime fecha, string cedula,
                   string codigo, Expediente expediente) : base(codigo, nombre, apellidos, genero,
                   fecha, cedula) {
      this._expediente = expediente;
      this._codigo = codigo;
    }
    /// <summary>
    /// Constructor de la clase <c>Recluso</c> que inicializa un nuevo recluso a (<paramref name="id"/>,<paramref name="nombre"/>, <paramref name="apellidos"/>, <paramref name="genero"/>, <paramref name="fecha"/>, <paramref name="cedula", <paramref name="codigo", <paramref name="expediente"/>).
    /// </summary>
    /// <param name="id">Corresponde al id del recluso</param>
    /// <param name="nombre">Corresponde al nombre del recluso.</param>
    /// <param name="apellidos">Corresponde a los apellidos del recluso.</param>
    /// <param name="genero">Corresponde al genero del recluso.</param>
    /// <param name="fecha">Corresponde a la fecha de nacimiento del recluso.</param>
    /// <param name="cedula">Corresponde a la cedula del recluso.</param>
    /// <param name="codigo">Corresponde al codigo del recluso.</param>
    /// <param name="expediente">Corresponde al expediente del recluso.</param>
    public Recluso(int id, string nombre, string apellidos, string genero, DateTime fecha, string cedula,
                   string codigo, Expediente expediente) : base(id, codigo, nombre, apellidos, genero,
                   fecha, cedula) {
      this._expediente = expediente;
      this._codigo = codigo;
    }
    /// <summary>
    /// Constructor de la clase <c>Recluso</c> con valores predeterminados.
    /// </summary>
    public Recluso() { }

  }
}
