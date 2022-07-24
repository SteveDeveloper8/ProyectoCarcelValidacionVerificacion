using Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsPrision {
  [TestClass]
  public class ActividadPracticaTest {
    ControlActividadPractica _controlPractica = new ControlActividadPractica();
    /// <summary>
    /// CP-11
    /// </summary>
    [TestMethod]
    public void GuardarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlPractica.GuardarActividadPractica(50, "Romper piedras", 1, "Taller");
      Assert.IsNotNull(resultadoObtenido);
    }
    /// <summary>
    /// CP-12
    /// </summary>
    [TestMethod]
    public void ConsultarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlPractica.FiltrarDescripcionModalidad("Romper piedras", "Taller");
      Assert.IsNotNull(resultadoObtenido);
    }
    /// <summary>
    /// CP-13
    /// </summary>
    [TestMethod]
    public void EliminarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlPractica.EliminarActividadPractica("Romper piedras", "Taller");
      var resultadoEsperado = true;
      Assert.AreEqual(resultadoEsperado, resultadoObtenido);
    }
  }
}
