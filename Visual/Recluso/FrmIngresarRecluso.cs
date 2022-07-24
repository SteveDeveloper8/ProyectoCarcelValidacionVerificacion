using System;
using System.Windows.Forms;

using Control;


namespace Visual.Recluso {
  public partial class FrmIngresarRecluso : Form {
    ControlRecluso _controlRecluso = new ControlRecluso();

    //INICIO- Validaciones de formulario.
    private void TxtNombreKeyPress(object sender, KeyPressEventArgs e) {
      if (!char.IsLetter(e.KeyChar) && (e.KeyChar != Convert.ToChar(Keys.Back)) &&
         (e.KeyChar != Convert.ToChar(Keys.Space))) {
        e.Handled = true;
        return;
      }
    }

    private void TxtApellidoKeyPress(object sender, KeyPressEventArgs e) {
      if (!char.IsLetter(e.KeyChar) && (e.KeyChar != Convert.ToChar(Keys.Back)) &&
         (e.KeyChar != Convert.ToChar(Keys.Space))) {
        e.Handled = true;
        return;
      }
    }

    private void TxtExpendienteKeyPress(object sender, KeyPressEventArgs e) {
      if (!char.IsNumber(e.KeyChar) && (e.KeyChar != Convert.ToChar(Keys.Back))) {
        e.Handled = true;
        return;
      }
    }
    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    private void BtnCerrarClick(object sender, EventArgs e) {
      this.Close();
    }
    //Fin- Validaciones de formulario.

    //Guarda un los datos del nuevo recluso en el sistema.
    private void BtnGuardarClick(object sender, EventArgs e) {
      string codigo = txtCodigo.Text.Trim();
      string cedula = txtCedula.Text.Trim();
      string nombre = txtNombre.Text.Trim();
      string apellido = txtApellido.Text.Trim();
      string genero = cmbGenero.Text.Trim();
      DateTime fecha = dtpFecha.Value.Date;

      if (!EsVacio(codigo, nombre, apellido, genero, fecha, cedula)) {
        if (!_controlRecluso.ExisteCodigo(codigo)) {
          try {
            int idExpediente = GetIdExpediente(_controlRecluso.BuscarExpediente(cedula));
            _controlRecluso.GuardarRecluso(codigo, nombre, apellido, genero, fecha, idExpediente, cedula);
            MessageBox.Show("Recluso Guardado con Exito");
          } catch (Exception ex) {
            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      } else {
        MessageBox.Show("Existe un campo vacio, o algún dato erróneo");
      }
    }
    //Valida que ningun campo del fromulario esté vacío.
    private bool EsVacio(string codigo, string nombre, string apellido, string genero,
                         DateTime fecha, string cedula) {
      return String.IsNullOrEmpty(codigo) || String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido) || String.IsNullOrEmpty(genero) || fecha == null || String.IsNullOrEmpty(cedula);
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
    //Recibe un objeto gnérico y devuelve el valor de la propiedad Id de expediente de el mismo.
    private int GetIdExpediente(Object expediente) {
      Type tipo = expediente.GetType();
      return (int)tipo.GetProperty("Id").GetValue(expediente);
    }
    //Muestra en una ventana emergente el expediente de el preso a registrar.
    private void BtnDetallesExpedienteClick(object sender, EventArgs e) {
      string cedula = txtCedula.Text.Trim();

      if (!String.IsNullOrEmpty(cedula)) {
        try {
          string nombres = txtNombre.Text;
          string apellidos = txtApellido.Text;
          new FrmExpedienteRecluso(_controlRecluso, cedula, nombres + " " + apellidos).ShowDialog();
        } catch (Exception ex) {
          MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } else {
        MessageBox.Show("Campo cedula vacio");
      }
    }

    public FrmIngresarRecluso() {
      InitializeComponent();
    }
  }
}
