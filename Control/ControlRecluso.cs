using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Control.Excepciones;

using Data;

using Model;

namespace Control {
  /// <summary>
  /// Controlador que gestiona la información de <seealso cref="Recluso"/>.
  /// </summary>
  public class ControlRecluso {
    /// <summary>
    /// Atributo tipo <see cref="DatosRecluso"/> que permite el acceso a la capa de Datos.
    /// </summary>
    DatosRecluso _datosRecluso = new DatosRecluso();
    /// <summary>
    /// Instancia de <see cref="Recluso"/> sirve como auxiliar para los métodos de control.
    /// </summary>
    Recluso _recluso = null;
    /// <summary>
    /// Valida que la longitud del <paramref name="codigo"/> sea igual a 10.
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns>Si la lóngitud es igual a 10 devuelve <see cref="true"/>,si no, devlueve <see cref="false"/>.</returns>
    internal bool ValidarCedulaRecluso(string cedula) {
      bool x = true;
      if (cedula.Length != 10) {
        x = false;
      }
      return x;
    }
    /// <summary>
    /// Valida que no exista un <see cref="Recluso"> con el mismo <paramref name="codigo"/> registrado.
    /// </summary>
    /// <param name="codigo">Código del nuevo <see cref="Recluso"/> a insertar.</param>
    /// <returns>Si el <paramref name="codigo"/> ya está registrado devuelve <see cref="true"/>,si no, devlueve <see cref="false"/>.</returns>
    public bool ExisteCodigo(string codigo) {
      List<Recluso> reclusos = _datosRecluso.ConsultarReclusos();
      foreach (Recluso recluso in reclusos) {
        if (recluso.Codigo.Equals(codigo)) {
          MessageBox.Show("Código ya registrado");
          return true;
        }
      }
      return false;
    }
    /// <summary>
    /// Busca busca el expediente del recluso cuya cpedula coincida con <paramref name="cedula"/>.
    /// </summary>
    /// <param name="cedula">Cédula del <see cref="Recluso"/> cuyo <see cref="Expediente"/> se busca.</param>
    /// <returns>Un <see cref="Expediente"/>.</returns>
    public Object BuscarExpediente(string cedula) {
      Expediente expediente = null;
      expediente = _datosRecluso.BuscarExpediente(cedula);

      if (expediente == null) {
        MessageBox.Show("no hay expedientes");
        throw new GeneralExcepcion("Expediente de recluso no existente");
      } else {
        return expediente;
      }
    }
    /// <summary>
    /// Guarda los datos de un nuevo <see cref="Recluso"/>.
    /// </summary>
    /// <param name="codigo">Código del nuevo <see cref="Recluso"/>.</param>
    /// <param name="nombre">Nombres del nuevo <see cref="Recluso"/>.</param>
    /// <param name="apellido">Apelidos del nuevo <see cref="Recluso"/>.</param>
    /// <param name="genero">Género del nuevo <see cref="Recluso"/>.</param>
    /// <param name="fecha">Fecha de nacimiento del nuevo <see cref="Recluso"/>.</param>
    /// <param name="idExpediente">ID del <see cref="Expediente"/> del nuevo <see cref="Recluso"/>.</param>
    /// <param name="cedula">Cédula del nuevo <see cref="Recluso"/>.</param>
    /// <returns>Si el <see cref="Recluso"/> se registró correctamente devuelve <see cref="true"/>,si no, devlueve <see cref="false"/>.</returns>
    /// <exception cref="CedulaRepetidaException">Cuando ya existe un <see cref="Recluso"/> registrado con esa <paramref name="cedula"/></exception>
    public bool GuardarRecluso(string codigo, string nombre, string apellido, string genero,
                               DateTime fecha, int idExpediente, string cedula) {
      if (BuscarRecluso(cedula) == null) {
        Expediente expediente = _datosRecluso.BuscarExpediente(cedula);
        _recluso = new Recluso(nombre, apellido, genero, fecha, cedula, codigo, expediente);
        _datosRecluso.InsertarRecluso(_recluso);
        return true;
      } else {
        return false;
        throw new CedulaRepetidaException();
      }
    }
    /// <summary>
    /// Lista a todos los datos de reclusos del sistema.
    /// </summary>
    /// <returns>Una lista con la información de cada <see cref="Recluso"/> registrado en el sistema.</returns>
    /// <exception cref="GeneralExcepcion">Cuando no se encontró ningún <see cref="Recluso"/> registrado en el sistema.</exception>
    public List<Object> ListarReclusos() {
      List<Recluso> reclusos = _datosRecluso.ConsultarReclusos();

      if (reclusos.Count <= 0) {
        throw new GeneralExcepcion("No se encontraron reclusos registrados");
      } else {
        return ObtenerListaDatosReclusos(reclusos);
      }
    }
    /// <summary>
    /// Busca un <see cref="Recluso"/> cuya cédula coincida con <paramref name="cedula"/>.
    /// </summary>
    /// <param name="cedula">Cédula del <see cref="Recluso"/> a buscar.</param>
    /// <returns>Un <see cref="Object"/> con los datos del <see cref="Recluso"/>.</returns>
    public Object BuscarRecluso(string cedula) {
      return _datosRecluso.BuscarRecluso(cedula);
    }
    /// <summary>
    /// Valida que no exista un <see cref="Recluso"/> con la misma <paramref name="cedula"/>.
    /// </summary>
    /// <param name="cedula">Cédula a validar.</param>
    /// <exception cref="Exception">Cuando ya existe un <see cref="Recluso"/> registrado con esa <paramref name="cedula"/>.</exception>
    public void ValidarRecluso(string cedula) {
      if (BuscarRecluso(cedula) != null) {
        throw new Exception("Cedula Repetida");
      }
    }
    /// <summary>
    /// Lista los <see cref="Cargo"/>s de un <see cref="Expediente"/> cuyo código coincida con <paramref name="codigoExpediente"/>.
    /// </summary>
    /// <param name="codigoExpediente">Código del <see cref="Expediente"/> cuyos <see cref="Cargo"/>s se van a listar.</param>
    /// <returns>Una lista con la información de cada <see cref="Cargo"/> del <see cref="Expediente"/>.</returns>
    /// <exception cref="GeneralExcepcion">Cuando no se encontró ningún <see cref="Cargo"/> registrado en ese <see cref="Expediente"/>.</exception>
    public List<Object> ListarCargos(string codigoExpediente) {
      List<Cargo> cargos = _datosRecluso.ConsultarCargos(codigoExpediente);

      if (cargos.Count <= 0) {
        throw new GeneralExcepcion("No se encontraron cargos registrados");
      } else {
        return ObtenerListaDatosCargos(cargos);
      }
    }
    /// <summary>
    /// Convierte una lista de <seealso cref="Cargo"/>s en una lista de objetos anónimos(<seealso cref="Object"/>) que la capa de vista pueda entender.
    /// </summary>
    /// <param name="cargos">Lista de cargos a convertir.</param>
    /// <returns>Una lista de objetos anónimos(<seealso cref="Object"/>).</returns>
    private List<Object> ObtenerListaDatosCargos(List<Cargo> cargos) {
      List<Object> cargosDatos = new List<object>();
      foreach (Cargo cargo in cargos) {
        cargosDatos.Add(ConvertirAnonimo(cargo));
      }
      return cargosDatos;
    }
    /// <summary>
    /// Convierte una lista de <seealso cref="Recluso"/>s en una lista de objetos anónimos(<seealso cref="Object"/>) que la capa de vista pueda entender.
    /// </summary>
    /// <param name="reclusos">Lista de reclusos a convertir.</param>
    /// <returns>Una lista de objetos anónimos(<seealso cref="Object"/>).</returns>
    private List<Object> ObtenerListaDatosReclusos(List<Recluso> reclusos) {
      List<Object> cargosDatos = new List<object>();
      foreach (Recluso recluso in reclusos) {
        cargosDatos.Add(ConvertirAnonimo(recluso));
      }
      return cargosDatos;
    }
    /// <summary>
    /// Convierte un objeto <seealso cref="Cargo"/> en un objeto anónimo(<seealso cref="Object"/>) que la capa de Vista puede entender.
    /// </summary>
    /// <param name="cargo">Cargo a convertir.</param>
    /// <returns>Un <seealso cref="Object"/> con los datos del <paramref name="cargo"/>.</returns>
    private Object ConvertirAnonimo(Cargo cargo) {
      return new {
        delito = cargo.Delito,
        descripcion = cargo.Descripcion,
        fecha = cargo.FechaHechos,
        localidad = cargo.LugarHechos.NombreLocalidad,
        ciudad = cargo.LugarHechos.NombreCiudad,
        pais = cargo.LugarHechos.NombrePais
      };
    }
    /// <summary>
    /// Convierte un objeto <seealso cref="Recluso"/> en un objeto anónimo(<seealso cref="Object"/>) que la capa de Vista puede entender.
    /// </summary>
    /// <param name="recluso">Cargo a convertir.</param>
    /// <returns>Un <seealso cref="Object"/> con los datos del <paramref name="recluso"/>.</returns>
    private Object ConvertirAnonimo(Recluso recluso) {
      return new {
        nombre = recluso.Nombre,
        apellidos = recluso.Apellidos,
        genero = recluso.Genero,
        fecha = recluso.Fecha,
        cedula = recluso.Cedula,
        codigo = recluso.Codigo,
        expediente = recluso.Expediente
      };
    }


  }
}
