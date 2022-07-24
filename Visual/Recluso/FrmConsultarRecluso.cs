using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control;


namespace Visual.Recluso {
  public partial class FrmConsultarRecluso : Form {
    ControlRecluso _controlRecluso = new ControlRecluso();

    //Consulta al sistema los datos de los reclusos registrados y los muestra.
    private void ConsultarReclusos() {
      List<Object> reclusos = null;
      try {
        reclusos = _controlRecluso.ListarReclusos();
        LlenarTablaReclusos(reclusos);
      } catch (GeneralExcepcion) {
        MessageBox.Show("No hay reclusos registrados en el sistema.");
      }
    }
    //Borra todas las filas de la tabla dejando solo la cabecera.
    private void LimpiarTabla() {
      dgvReclusos.Rows.Clear();
    }
    //Muestra  en la tabla una lista de objetos genéricos dada como argumento para ser visualizados.
    private void LlenarTablaReclusos(List<Object> reclusos) {
      LimpiarTabla();
      foreach (var recluso in reclusos) {
        InsertarFila(recluso);
      }
      dgvReclusos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvReclusos.AutoResizeColumns();
    }
    //Obtiene los datos de un objeto genérico en forma de datos que entienda la tabla y los inserta en la misma en forma de fila.
    private void InsertarFila(Object recluso) {
      Type tipo = recluso.GetType();
      string codigo = (string)tipo.GetProperty("codigo").GetValue(recluso);
      string nombre = (string)tipo.GetProperty("nombre").GetValue(recluso);
      string apellidos = (string)tipo.GetProperty("apellidos").GetValue(recluso);
      string genero = (string)tipo.GetProperty("genero").GetValue(recluso);
      string fecha = ((DateTime)tipo.GetProperty("fecha").GetValue(recluso)).ToString("dd/MM/yyyy");
      string cedula = (string)tipo.GetProperty("cedula").GetValue(recluso);
      dgvReclusos.Rows.Add(codigo, nombre, apellidos, cedula, genero, fecha, "Ver expediente");
    }
    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }
    private void BtnCerrarClick(object sender, EventArgs e) {
      this.Close();
    }

    int _posY = 0;
    int _posX = 0;
    private void Guna2Panel1MouseMove(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left) {
        _posX = e.X;
        _posY = e.Y;
      } else {
        Left = Left + (e.X - _posX);
        Top = Top + (e.Y - _posY);
      }
    }
    //Muestra el expediente de un recluso en específico en un nuevo formulario emergente.
    private void DgvReclusosCellContentClick(object sender, DataGridViewCellEventArgs e) {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
        string cedula = Convert.ToString(dgvReclusos.Rows[e.RowIndex].Cells[3].Value);
        string nombres = Convert.ToString(dgvReclusos.Rows[e.RowIndex].Cells[1].Value);
        string apellidos = Convert.ToString(dgvReclusos.Rows[e.RowIndex].Cells[2].Value);
        new FrmExpedienteRecluso(_controlRecluso, cedula, nombres + " " + apellidos).ShowDialog();
      }
    }
    //Muestra los datos de un recluso en específico que coincida con un número de cédula ingresado.
    private void BtnBuscarClick(object sender, EventArgs e) {
      LimpiarTabla();
      Object recluso = _controlRecluso.BuscarRecluso(txtCedula.Text);
      InsertarFila(recluso);
    }
    //Muestra los dato d etodos los reclusos registrados en el sistema.
    private void BtnMostrar_Click(object sender, EventArgs e) {
      ConsultarReclusos();
    }

    private void DgvReclusosMouseDoubleClick(object sender, MouseEventArgs e) {
      string cedulaRecluso = dgvReclusos.CurrentRow.Cells[3].Value.ToString();
      // controlUser.BuscarUsuario()
    }

    //Muestra los datos de todos los relusos registrados al abrir el formulario.
    public FrmConsultarRecluso() {
      InitializeComponent();
      ConsultarReclusos();
    }
  }
}
