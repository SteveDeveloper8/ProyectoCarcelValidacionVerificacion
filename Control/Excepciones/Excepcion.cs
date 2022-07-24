using System;

namespace Control {

  public class GeneralExcepcion : Exception {
    private string _message;
    public GeneralExcepcion(String message) : base(message) {
      this._message = message;
    }
  }

}
