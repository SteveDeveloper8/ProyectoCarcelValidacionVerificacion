using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control;


namespace Visual.Cursos {
  public partial class FrmHome : Form {
    ControlRecluso _controlRecluso = new ControlRecluso();

    private void ConsultarReclusos() {
      List<Object> reclusos = null;
      try {
        reclusos = _controlRecluso.ListarReclusos();
        LlenarTablaReclusos(reclusos);
      } catch (GeneralExcepcion) {
        MessageBox.Show("No hay reclusos registrados en el sistema.");
      }

    }

    private void LlenarTablaReclusos(List<Object> reclusos) {
      LimpiarTabla();
      foreach (var recluso in reclusos) {
        InsertarFila(recluso);
      }
      dgvReclusos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvReclusos.AutoResizeColumns();
    }

    private void InsertarFila(Object recluso) {
      Type tipo = recluso.GetType();
      string codigo = (string)tipo.GetProperty("codigo").GetValue(recluso);
      string nombre = (string)tipo.GetProperty("nombre").GetValue(recluso);
      string apellidos = (string)tipo.GetProperty("apellidos").GetValue(recluso);
      string genero = (string)tipo.GetProperty("genero").GetValue(recluso);
      string fecha = ((DateTime)tipo.GetProperty("fecha").GetValue(recluso)).ToString("dd/MM/yyyy");
      string cedula = (string)tipo.GetProperty("cedula").GetValue(recluso);
      dgvReclusos.Rows.Add(codigo, nombre, apellidos, cedula, genero, fecha);
    }
    private void LimpiarTabla() {
      dgvReclusos.Rows.Clear();
    }
    public FrmHome() {
      InitializeComponent();
      ConsultarReclusos();
    }
  }
}
