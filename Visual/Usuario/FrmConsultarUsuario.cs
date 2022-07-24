using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control;


namespace Visual.Usuario {
  public partial class FrmConsultarUsuario : Form {
    ControladorUsuario _controlUsuario = new ControladorUsuario();

    private void ConsultarUsuarios() {
      List<Object> usuarios = null;
      try {
        usuarios = _controlUsuario.ListarUsuarios();
        LlenarTablaUsuarios(usuarios);
      } catch (GeneralExcepcion) {
        MessageBox.Show("No hay usuarios registrados en el sistema.");
      }
    }

    private void LlenarTablaUsuarios(List<object> usuarios) {
      LimpiarTabla();
      foreach (var usuario in usuarios) {
        InsertarFila(usuario);
      }
      dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvUsuarios.AutoResizeColumns();
    }

    private void BtnBuscarClick(object sender, EventArgs e) {
      string user = txtUsuario.Text.Trim();

      if (!EsVacio(user)) {
        BuscarUsuario(user);
      } else {
        MessageBox.Show("Favor ingrese un apellido");
      }
    }

    private void BuscarUsuario(string user) {
      LimpiarTabla();
      try {
        Object usuario = _controlUsuario.BuscarUsuario(user);
        InsertarFila(usuario);
      } catch (Exception) {
        MessageBox.Show("Usuario no encontrado");
      }
    }

    private void InsertarFila(Object usuario) {
      Type tipo = usuario.GetType();
      string nombres = (string)tipo.GetProperty("nombres").GetValue(usuario);
      string apellidos = (string)tipo.GetProperty("apellidos").GetValue(usuario);
      string user = (string)tipo.GetProperty("usuario").GetValue(usuario);
      string contrasena = (string)tipo.GetProperty("contrasena").GetValue(usuario);
      string rol = (string)tipo.GetProperty("rol").GetValue(usuario);

      dgvUsuarios.Rows.Add(nombres, apellidos, user, contrasena, rol);
    }

    private void LimpiarTabla() {
      dgvUsuarios.Rows.Clear();
    }

    private bool EsVacio(string apellidos) {
      return String.IsNullOrEmpty(apellidos);
    }

    private void BtnMostrarTodosClick(object sender, EventArgs e) {
      ConsultarUsuarios();
    }

    private void BtnCerrarClick(object sender, EventArgs e) {
      this.Close();
    }

    private void BtnMinimizarClick(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    int _posY = 0;
    int _posX = 0;
    private void FrmConsultarUsuarioMouseMove(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left) {
        _posX = e.X;
        _posY = e.Y;
      } else {
        Left = Left + (e.X - _posX);
        Top = Top + (e.Y - _posY);
      }
    }

    public FrmConsultarUsuario() {
      InitializeComponent();
      ConsultarUsuarios();
    }
  }
}
