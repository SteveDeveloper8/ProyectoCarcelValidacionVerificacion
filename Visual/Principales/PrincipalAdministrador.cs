using System;
using System.Windows.Forms;

using Visual.Recluso;
using Visual.Usuario;


namespace Visual {
  public partial class PrincipalAdministrador : Form {
    private void ConsultarToolStripMenuItemClick(object sender, EventArgs e) {
      FrmConsultarRecluso consultar = new FrmConsultarRecluso();
      consultar.ShowDialog();
    }

    private void RegistrarToolStripMenuItemClick(object sender, EventArgs e) {
      FrmIngresarRecluso ingresar = new FrmIngresarRecluso();
      ingresar.ShowDialog();
    }

    private void PrincipalAdministradorLoad(object sender, EventArgs e) {

    }

    private void Guna2PictureBox1MouseHover(object sender, EventArgs e) {
      CerrarSesion.Visible = true;
    }

    private void Guna2PictureBox1MouseLeave(object sender, EventArgs e) {
      CerrarSesion.Visible = false;
    }

    private void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

    }

    int posY = 0;
    int posX = 0;
    private void Guna2Panel1MouseMove(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left) {
        posX = e.X;
        posY = e.Y;
      } else {
        Left = Left + (e.X - posX);
        Top = Top + (e.Y - posY);
      }
    }

    private void BtnCerrarClick(object sender, EventArgs e) {
      Application.Exit();
    }

    private void MenuRegistrarClick(object sender, EventArgs e) {
      FrmIngresarRecluso ingresar = new FrmIngresarRecluso();
      ingresar.ShowDialog();
    }

    private void MenuRegistrarUsuarioClick(object sender, EventArgs e) {
      FrmRegistrarUsuario registrar = new FrmRegistrarUsuario();
      registrar.ShowDialog();
    }

    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    private void ToolStripMenuItem8Click(object sender, EventArgs e) {
      FrmConsultarUsuario usuarios = new FrmConsultarUsuario();
      usuarios.ShowDialog();
    }

    private void ToolStripMenuItem7Click(object sender, EventArgs e) {
      FrmConsultaToActualizar actualiza = new FrmConsultaToActualizar();
      actualiza.ShowDialog();
    }

    public PrincipalAdministrador() {
      InitializeComponent();
      CerrarSesion.Visible = false;
    }
  }
}
