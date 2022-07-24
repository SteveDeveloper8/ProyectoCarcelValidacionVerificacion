using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control;


namespace Visual {
  public partial class FrmDistancia : Form {

    ControlCursosCurricular _controlCursos = new ControlCursosCurricular();

    ///<summary>
    ///Metodo que se encarga de consultar cursos.
    ///</summary>
    private void ConsultarCursos() {
      List<Object> reclusos = null;
      try {
        reclusos = _controlCursos.ListarCursosDistancia();
        LlenarTablaCursosDistancia(reclusos);
      } catch (GeneralExcepcion) {
        MessageBox.Show("No hay reclusos registrados en el sistema.");
      }
    }

    ///<summary>
    ///Metodo que se encarga de recorrer la lista de cursos
    ///</summary>
    private void LlenarTablaCursosDistancia(List<object> cursoDistancia) {
      LimpiarTabla();
      foreach (var curso in cursoDistancia) {
        InsertarFila(curso);
      }
      dgvDistancia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvDistancia.AutoResizeColumns();
    }

    ///<summary>
    ///Metodo que se encarga limpiar el datagriview.
    ///</summary>
    private void LimpiarTabla() {
      dgvDistancia.Rows.Clear();
    }

    ///<summary>
    ///Metodo que se encarga de vaidar si un campo esta vacio.
    ///</summary>
    ///<param name= "cupos"> Numero de cupos </param>
    ///<param name= "descripcion"> descripcion del curso </param>
    ///<param name= "remision"> Numero de dias de remision de condena </param>
    ///<param name= "fechaInicio"> Fecha de inicio del curso </param>
    ///<param name= "fechaFin"> Fecha de fin del curso</param>
    ///<param name= "modalidad"> Modalidad del curso</param>
    ///<return>Retorna verdadero si existe algun campo vacio, caso contrario retorna falso</return>
    private bool EsVacio(int cupos, string descripcion, int remision, DateTime fechaInicio,
                         DateTime fechaFin, string modalidad) {
      return String.IsNullOrEmpty(cupos + "") || String.IsNullOrEmpty(descripcion) ||
             String.IsNullOrEmpty(remision + "") || fechaInicio == null || fechaFin == null ||
             String.IsNullOrEmpty(modalidad);
    }


    ///<summary>
    ///Metodo que se encarga de eliminar curso de base y del datagriedview
    ///</summary>
    private void BtnEliminarClick(object sender, EventArgs e) {
      int pos = 0;
      if (dgvDistancia.Rows.Count > 0) {
        pos = dgvDistancia.CurrentRow.Index;
        string estudioDelete = dgvDistancia.CurrentRow.Cells[0].Value.ToString();
        string modalidad = dgvDistancia.CurrentRow.Cells[1].Value.ToString();
        _controlCursos.EliminarEstudio(estudioDelete, modalidad);
        dgvDistancia.Rows.RemoveAt(pos);
        MessageBox.Show("Curso Eliminado con Exito");
      } else {
        MessageBox.Show("No existen registros para eliminar");
      }
    }

    ///<summary>
    ///Metodo que se encarga de filtrar cursos, en base a los campos ingresados para la busqueda.
    ///</summary>
    private void BtnBuscarClick(object sender, EventArgs e) {
      string descripcion = txtBuscarDescripcion.Text.Trim();
      string modalidad = cmbFiltrar.Text.Trim();

      if (EsVacioBusqueda(descripcion, modalidad)) {
        MessageBox.Show("No existen datos a buscar");
      } else if (modalidad.CompareTo("Filtrar...") == 0) {
        FiltrarDescripcion(descripcion);
      } else if (descripcion.CompareTo("") == 0) {
        FiltrarModalidad(modalidad);
      } else if (!(descripcion.CompareTo("") == 0) && !(modalidad.CompareTo("") == 0)) {
        FiltrarDescripcionModalidad(descripcion, modalidad);
      }
    }


    ///<summary>
    ///Metodo que se encarga de filtrar y llenar datagridwiew en base a su descripcion.
    ///</summary>
    ///<param name= "descripcion"> descripcion del curso </param>
    private void FiltrarDescripcion(string descripcion) {
      List<Object> cursos = null;
      try {
        cursos = _controlCursos.FiltrarDescripcion(descripcion);
        LlenarTablaCursos(cursos);
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    ///<summary>
    ///Metodo que se encarga de filtrar y llenar datagridwiew en base a su modalidad.
    ///</summary>
    ///<param name= "modalidad"> Modalidad del curso </param>
    private void FiltrarModalidad(string modalidad) {
      List<Object> cursos = null;
      try {
        cursos = _controlCursos.FiltrarModalidad(modalidad);
        LlenarTablaCursos(cursos);
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    ///<summary>
    ///Metodo que se encarga de filtrar y llenar datagridwiew en base a su descripcion y su modalidad.
    ///</summary>
    ///<param name= "descripcion"> descripcion del curso </param>
    ///<param name= "modalidad"> modalidad del curso </param>
    private void FiltrarDescripcionModalidad(string descripcion, string modalidad) {
      List<Object> cursos = null;
      try {
        cursos = _controlCursos.FiltrarDescripcionModalidad(descripcion, modalidad);
        LlenarTablaCursos(cursos);
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    ///<summary>
    ///Metodo que se encarga de llenar los datagriedviews con los cursos de la lista.
    ///</summary>
    ///<param name= "cursos"> Lista de cursos</param>
    private void LlenarTablaCursos(List<Object> cursos) {
      LimpiarTabla();
      foreach (var curso in cursos) {
        InsertarFila(curso);
      }
      dgvDistancia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvDistancia.AutoResizeColumns();
    }


    ///<summary>
    ///Metodo que se encarga de insertar datos al datagridview
    ///</summary>
    ///<param name= "curso">Curso que se insertará</param>
    private void InsertarFila(Object curso) {
      Type tipo = curso.GetType();
      int cupos = (int)tipo.GetProperty("cupos").GetValue(curso);
      string descripcion = (string)tipo.GetProperty("descripcion").GetValue(curso);
      string modalidad = (string)tipo.GetProperty("modalidad").GetValue(curso);
      int remisionTotal = (int)tipo.GetProperty("remisionTotal").GetValue(curso);
      string fechaInicio = ((DateTime)(tipo.GetProperty("fechaInicio").GetValue(curso))).ToString("dd/MM/yyyy");
      string fechaFin = ((DateTime)(tipo.GetProperty("fechaFin").GetValue(curso))).ToString("dd/MM/yyyy");

      dgvDistancia.Rows.Add(descripcion, modalidad, fechaInicio, fechaFin, cupos, remisionTotal);
    }


    ///<summary>
    ///Metodo que se encarga de vaidar si un campo esta vacio.
    ///</summary>
    ///<param name= "descripcion"> descripcion del curso </param>
    ///<param name= "modalidad"> Modalidad del curso</param>
    ///<return>Retorna verdadero si existe algun campo vacio, caso contrario retorna falso</return>
    private bool EsVacioBusqueda(string descripcion, string modalidad) {
      return String.IsNullOrEmpty(descripcion) && String.IsNullOrEmpty(modalidad);
    }

    ///<summary>
    ///Metodo que se encarga de gestionar el guardado de los cursos.
    ///</summary>
    private void BtnGuardarClick1(object sender, EventArgs e) {
      int cupos = Convert.ToInt32(txtCupos.Text.Trim());
      string descripcion = txtDescripcion.Text.Trim();
      int remision = Convert.ToInt32(txtRemision.Text.Trim());
      DateTime fechaInicio = dtpFechaInicio.Value.Date;
      DateTime fechaFin = dtpFechaFin.Value.Date;
      string modalidad = cmbModalidad.Text.Trim();

      if (!EsVacio(cupos, descripcion, remision, fechaInicio, fechaFin, modalidad)) {
        try {
          Object curso = _controlCursos.GuardarEstudio(cupos, descripcion, remision, fechaInicio,
                                                      fechaFin, modalidad);
          MessageBox.Show("Curso Guardado con Exito");
          InsertarFila(curso);

        } catch (Exception ex) {
          MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      } else {
        MessageBox.Show("Existe un campo vacio, o algún dato erróneo");
      }

    }
    ///<summary>
    ///Metodo que se encarga de limpiar campos.
    ///</summary>
    private void BtnLimpiarClick(object sender, EventArgs e) {
      txtBuscarDescripcion.Clear();
      cmbFiltrar.SelectedIndex = cmbFiltrar.FindStringExact("Filtrar...");
      ConsultarCursos();
    }

    public FrmDistancia() {
      InitializeComponent();
      ConsultarCursos();
      cmbFiltrar.SelectedIndex = cmbFiltrar.FindStringExact("Filtrar...");
    }
  }
}
