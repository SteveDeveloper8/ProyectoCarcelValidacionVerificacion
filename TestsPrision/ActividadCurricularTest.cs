using Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsPrision {
  [TestClass]
  public class ActividadCurricularTest {
    ControlCursosCurricular _controlCurso = new ControlCursosCurricular();
    /// <summary>
    /// CP-08
    /// </summary>
    [TestMethod]
    public void GuardarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlCurso.GuardarEstudio(20, "Curso de Fránces", 100, Convert.ToDateTime("02/09/2021"), Convert.ToDateTime("02/03/2022"), "Distancia");
      Assert.IsNotNull(resultadoObtenido);
    }
    /// <summary>
    /// CP-09
    /// </summary>
    [TestMethod]
    public void ConsultarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlCurso.FiltrarDescripcionModalidad("Curso de Fránces", "Distancia");
      Assert.IsNotNull(resultadoObtenido);
    }
    /// <summary>
    /// CP-10
    /// </summary>
    [TestMethod]
    public void EliminarActividadCurricular_Exitoso() {
      var resultadoObtenido = _controlCurso.EliminarEstudio("Curso de Fránces", "Distancia");
      var resultadoEsperado = true;
      Assert.AreEqual(resultadoEsperado, resultadoObtenido);
    }
  }
}
