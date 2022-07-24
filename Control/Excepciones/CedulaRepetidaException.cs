using System;

namespace Control.Excepciones {
  /// <summary>
  /// Permite gestionar las excepciones con cedula repetida.
  /// </summary>
  public class CedulaRepetidaException : Exception {
    /// <value>Propiedad mensaje correspondiente al mensaje a mostrar cuando ocurra la exepcion.</value>
    private string _mensaje;

    /// <summary>
    /// Constructor de la clase <c>CedulaRepetidaException</c> que inicializa una nueva excepcion.
    /// </summary>
    public CedulaRepetidaException() {
      this._mensaje = "Ya existe un recluso registrado con esa cédula.";
    }

    /// <summary>
    /// Obtiene o establece el mensaje de la excepcion.
    /// </summary>
    /// <return>Una cadena con mensaje de la excepcion.</return>
    public string Mensaje { get => _mensaje; set => _mensaje = value; }
  }
}
