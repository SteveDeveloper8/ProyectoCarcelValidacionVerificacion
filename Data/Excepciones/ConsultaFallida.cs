using System;

namespace Data.Excepciones {
  public class ConsultaFallida : Exception {
    string _mensaje;
    public string Mensaje { get => _mensaje; set => _mensaje = value; }
    public ConsultaFallida() {
      this._mensaje = "La consulta a la base de datos falló y por ende no devolvió los resultados esperados.";
    }
  }
}
