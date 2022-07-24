using System;
using System.Windows.Forms;

using Control;


namespace Visual {
  public partial class FrmLogin : Form {
    ControladorUsuario _controlUser = new ControladorUsuario();

    //Envía las credenciales de acceso al sistema y si con consistenetes permite el acceso.
    private void BtnInicioSesionClick(object sender, EventArgs e) {
      string usuario = txtUsuario.Text.Trim();
      string contrasena = txtContrasena.Text.Trim();

      Login(usuario, contrasena);

    }

    private void Login(string usuario, string contrasena) {
      if (!EsVacio(usuario, contrasena)) {
        try {
          _controlUser.ValidarLogin(usuario, contrasena);
          AbrirMenu(usuario);
        } catch (GeneralExcepcion ex) {
          MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } else {
        MessageBox.Show("Existen campos vacios");
      }
    }

    //Valida que no haya campos del formulario sin llenar.
    private bool EsVacio(String usuario, String contrasena) {
      return String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(contrasena);
    }


    private void AbrirMenu(string usuario) {
      this.Hide();
      if (_controlUser.RetornaRol(usuario).Equals("Administrador")) {
        PrincipalAdministrador principal = new PrincipalAdministrador();
        principal.ShowDialog();
      } else if (_controlUser.RetornaRol(usuario).Equals("Alcaide")) {
        EstudioRegistro alcaide = new EstudioRegistro(usuario);
        alcaide.ShowDialog();
      }

    }

    private void BtnCerrarClick(object sender, EventArgs e) {
      Application.Exit();
    }

    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
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

    public FrmLogin() {
      InitializeComponent();
    }

  }
}
