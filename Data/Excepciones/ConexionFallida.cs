using System;

namespace Data.Excepciones {
  public class ConexionFallida : Exception {
    string _mensaje;
    public string Mensaje { get => _mensaje; set => _mensaje = value; }

    public ConexionFallida() {
      this._mensaje = "No se pudo establecer conexión con la base de datos.";
    }
   
  }
}
