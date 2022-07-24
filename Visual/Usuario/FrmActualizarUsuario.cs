using System;
using System.Windows.Forms;

using Control;


namespace Visual.Usuario {
  public partial class FrmActualizarUsuario : Form {
    private string _username;
    ControladorUsuario _controlUsuario = new ControladorUsuario();
    private void Inicializar() {
      Object usuario = BuscarUsuario();
      Type tipo = usuario.GetType();
      txtNombre.Text = (string)tipo.GetProperty("nombres").GetValue(usuario);
      txtApellido.Text = (string)tipo.GetProperty("apellidos").GetValue(usuario);
      txtUsuario.Text = (string)tipo.GetProperty("usuario").GetValue(usuario);
      txtContrasena.Text = (string)tipo.GetProperty("contrasena").GetValue(usuario);
      cmbRol.Text = (string)tipo.GetProperty("rol").GetValue(usuario);
    }

    private Object BuscarUsuario() {
      Object usuario = _controlUsuario.BuscarUsuario(_username);
      return usuario;
    }

    private void BtnActualizarClick(object sender, EventArgs e) {
      string nombre = txtNombre.Text.Trim();
      string apellido = txtApellido.Text.Trim();
      string usuario = txtUsuario.Text.Trim();
      string contrasena = txtContrasena.Text.Trim();
      string confirmacion = txtConfimacion.Text.Trim();
      string rol = cmbRol.Text.Trim();

      if (!EsVacio(nombre, apellido, usuario, contrasena, confirmacion, rol)) {
        try {
          if (ValidarConfirmacion(contrasena, confirmacion)) {
            _controlUsuario.ActualizarUsuario(nombre, apellido, usuario, contrasena, rol);
            MessageBox.Show("Usuario Actualizado");
          }
        } catch (Exception ex) {
          MessageBox.Show(ex.Message);
        }

      }
    }

    //Valida que todos los campos del formulario esten llenos.
    private bool EsVacio(string nombre, string apellido, string usuario, string contrasena,
                         string confirmacion, string rol) {
      return String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido) || String.IsNullOrEmpty(usuario) ||
             String.IsNullOrEmpty(contrasena) || String.IsNullOrEmpty(confirmacion) || String.IsNullOrEmpty(rol);
    }

    //Valida si el usuario confirmó la contraseña correctamente.
    private bool ValidarConfirmacion(string contrasena, string confirmacion) {
      if (contrasena.Equals(confirmacion)) {
        return true;
      } else {
        return false;
      }
    }

    private void Guna2CirclePictureBox2Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Guna2CirclePictureBox1Click(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    int _posY = 0;
    int _posX = 0;
    private void FrmActualizarUsuarioMouseMove(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left) {
        _posX = e.X;
        _posY = e.Y;
      } else {
        Left = Left + (e.X - _posX);
        Top = Top + (e.Y - _posY);
      }
    }
    public FrmActualizarUsuario(string usuario) {
      InitializeComponent();
      this._username = usuario;
      txtUsuario.Enabled = false;
      Inicializar();
    }
  }
}
