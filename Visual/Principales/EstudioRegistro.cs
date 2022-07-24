using System;
using System.Linq;
using System.Windows.Forms;

using Visual.Cursos;


namespace Visual {
  public partial class EstudioRegistro : Form {
    private void AbrirFormulario<miForm>() where miForm : Form, new() {
      Form formulario;
      formulario = panelPrincipal.Controls.OfType<miForm>().FirstOrDefault();

      if (formulario == null) {
        formulario = new miForm();
        formulario.TopLevel = false;
        formulario.FormBorderStyle = FormBorderStyle.None;
        formulario.Dock = DockStyle.Fill;
        panelPrincipal.Controls.Add(formulario);
        panelPrincipal.Tag = formulario;
        formulario.Show();
        formulario.BringToFront();
      } else {
        formulario.BringToFront();
      }
    }

    private void Guna2Button3Click(object sender, EventArgs e) {
      AbrirFormulario<FrmTalleres>();
    }

    private void Guna2Button1Click(object sender, EventArgs e) {
      AbrirFormulario<FrmDistancia>();
    }

    private void BtnHomeClick(object sender, EventArgs e) {
      AbrirFormulario<FrmHome>();
    }

    public EstudioRegistro(string usuario) {
      InitializeComponent();
      AbrirFormulario<FrmHome>();
      lblBienvenida.Text = usuario;
    }
  }
}
