using System;
using System.Windows.Forms;

using Control;


namespace Visual.Usuario {
  public partial class FrmRegistrarUsuario : Form {
    ControladorUsuario _controlUsuario = new ControladorUsuario();

    //Guarda lso datos del nuevo usuario en el sistema.
    private void BtnRegistrarClick(object sender, EventArgs e) {
      string nombre = txtNombre.Text.Trim();
      string apellido = txtApellido.Text.Trim();
      string usuario = txtUsuario.Text.Trim();
      string contrasena = txtContrasena.Text.Trim();
      string confirmacion = txtConfimacion.Text.Trim();
      string rol = cmbRol.Text.Trim();

      if (!EsVacio(nombre, apellido, usuario, contrasena, confirmacion, rol)) {
        try {
          if (ValidarConfirmacion(contrasena, confirmacion)) {
            _controlUsuario.GuardarUsuario(nombre, apellido, usuario, contrasena, rol);
            MessageBox.Show("Usuario Registrado");
          }
        } catch (Exception ex) {
          MessageBox.Show(ex.Message);
        }
      }
    }

    private bool EsVacio(string nombre, string apellido, string usuario, string contrasena,
                         string confirmacion, string rol) {

      return String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido) || String.IsNullOrEmpty(usuario) ||
             String.IsNullOrEmpty(contrasena) || String.IsNullOrEmpty(confirmacion) || String.IsNullOrEmpty(rol);
    }
    //Valida si el usuario confirmó la contraseña correctamente.
    private bool ValidarConfirmacion(string contrasena, string confirmacion) {
      if (contrasena.Equals(confirmacion))
        return true;
      else
        return false;
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

    public FrmRegistrarUsuario() {
      InitializeComponent();

    }
  }
}
