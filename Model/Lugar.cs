namespace Model {
  /// <summary>
  /// Representa un Lugar.
  /// </summary>
  public class Lugar {
    /// <value>Propiedad nombreLozalidad correspondiente a la localidad del Lugar.</value>
    private string _nombreLocalidad;
    /// <value>Propiedad nombreCiudad correspondiente al nombre de la ciudad.</value>
    private string _nombreCiudad;
    /// <value>Propiedad nombrePais correspondiente al nombre del país.</value>
    private string _nombrePais;

    // <summary>
    /// Obtiene o establece el nombre de la localidad.
    /// </summary>
    /// <returns>Una cadena con el nombre de la localidad.</returns>
    public string NombreLocalidad { get => _nombreLocalidad; set => _nombreLocalidad = value; }
    // <summary>
    /// Obtiene o establece el nombre de la ciudad.
    /// </summary>
    /// <returns>Una cadena con el nombre de la ciudad.</returns>
    public string NombreCiudad { get => _nombreCiudad; set => _nombreCiudad = value; }
    // <summary>
    /// Obtiene o establece el nombre del país.
    /// </summary>
    /// <returns>Una cadena con el nombre del país.</returns>
    public string NombrePais { get => _nombrePais; set => _nombrePais = value; }
  }
}
