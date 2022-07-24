using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control;


namespace Visual.Recluso {
  public partial class FrmExpedienteRecluso : Form {
    ControlRecluso _controlRecluso;

    private void BtnCerrarClick(object sender, EventArgs e) {
      this.Close();
    }

    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }
    //Muestra los datos de un expediente peretneciente a un recluso cuyo número de cédula coincida con el argumento.
    private void ConsultarExpediente(string cedula) {
      List<Object> cargos;
      string codigoExpediente = GetCodigoExpediente(_controlRecluso.BuscarExpediente(cedula));
      cargos = _controlRecluso.ListarCargos(codigoExpediente);
      lblCodigo.Text = codigoExpediente;
      LlenarTablaCargos(cargos);
    }
    //Recibe un objeto gnérico y devuelve el valor de la propiedad código de expediente de el mismo.
    private string GetCodigoExpediente(Object expediente) {
      Type tipo = expediente.GetType();
      return (string)tipo.GetProperty("Codigo").GetValue(expediente);
    }
    //Obtiene los datos de un objeto genérico en forma de datos que entienda la tabla y los inserta en la misma en forma de fila.
    private void InsertarFila(Object cargo) {
      Type tipo = cargo.GetType();
      string delito = (string)tipo.GetProperty("delito").GetValue(cargo);
      string descripcion = (string)tipo.GetProperty("descripcion").GetValue(cargo);
      string fecha = ((DateTime)tipo.GetProperty("fecha").GetValue(cargo)).ToString("dd/MM/yyyy");
      string localidad = (string)tipo.GetProperty("localidad").GetValue(cargo);
      string ciudad = (string)tipo.GetProperty("ciudad").GetValue(cargo);
      string pais = (string)tipo.GetProperty("pais").GetValue(cargo);
      dgvCargos.Rows.Add(delito, descripcion, fecha, localidad, ciudad, pais);
    }
    //Muestra  en la tabla una lista de objetos genéricos dada como argumento para ser visualizados.
    private void LlenarTablaCargos(List<Object> cargos) {
      LimpiarTabla();
      foreach (var cargo in cargos) {
        InsertarFila(cargo);
      }
      dgvCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvCargos.AutoResizeColumns();
    }
    //Borra todas las filas de la tabla dejando solo la cabecera.
    private void LimpiarTabla() {
      dgvCargos.Rows.Clear();
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

    private void BtnRegresarClick(object sender, EventArgs e) {
      this.Close();
    }

    //Muestra los detalles de un expedeinte específico al abrir la ventana. 
    public FrmExpedienteRecluso(ControlRecluso controlRecluso, string cedula, string nombreRecluso) {
      InitializeComponent();
      this._controlRecluso = controlRecluso;
      lblNombre.Text = nombreRecluso;
      ConsultarExpediente(cedula);
    }
  }
}
