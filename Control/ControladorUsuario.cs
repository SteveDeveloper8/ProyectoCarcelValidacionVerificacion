using System;
using System.Collections.Generic;

using Data;
using Data.Excepciones;

using Model;

namespace Control {
  /// <summary>
  /// Controlador que gestiona la información de <see cref="Usuario">.
  /// </summary>
  public class ControladorUsuario {
    /// <summary>
    /// Atributo tipo <see cref="DatosLogin"/> que permite el acceso a la capa de Datos.
    /// </summary>
    DatosLogin _datosLogin = new DatosLogin();
    /// <summary>
    /// Instancia de <see cref="Usuario"/> sirve como auxiliar para los métodos de control.
    /// </summary>
    Usuario _user = null;
    /// <summary>
    /// Instancia de <see cref="Rol"/> sirve como auxiliar para los métodos de control.
    /// </summary>
    Rol _role = null;
    /// <summary>
    /// Valida que el nombre de usuario(<paramref name="usuario"/>) y la <paramref name="contrasena"/> coincidan con un <see cref="Usuario"> registrado.
    /// </summary>
    /// <param name="usuario">Nombre de usuario ingresado.</param>
    /// <param name="contrasena">Contraseña ingresada.</param>
    /// <exception cref="GeneralExcepcion">Cuando el <paramref name="usuario"/> y la <paramref name="contrasena"/> son incorrectos, o cuando solo la <paramref name="contrasena"/> lo es.</exception>
    public bool ValidarLogin(string usuario, string contrasena) {

      Usuario user = null;
      user = _datosLogin.ConsultarUsuario(usuario);

      if (user == null) {
        throw new GeneralExcepcion("Usuario y/o contrasena incorrecta");
        return false;
      } else if (user.Contrasena != contrasena) {
        throw new GeneralExcepcion("Contrasena incorrecta");
        return false;
      }
      return true;
    }
    /// <summary>
    /// Lista a todos los datos de usuarios del sistema.
    /// </summary>
    /// <returns>Una lista con la información de cada <see cref="Usuario"/> registrado en el sistema.</returns>
    /// <exception cref="GeneralExcepcion">Cuando no se encontró ningún <see cref="Usuario"/> registrado en el sistema.</exception>
    public List<Object> ListarUsuarios() {
      List<Usuario> usuarios = _datosLogin.Consultar();

      if (usuarios.Count <= 0)
        throw new GeneralExcepcion("No se encontraron usuarios registrados");
      else
        return ObtenerListaDatosUsuarios(usuarios);
    }
    /// <summary>
    /// Convierte una lista de <seealso cref=Usuario"/>s en una lista de objetos anónimos(<seealso cref="Object"/>) que la capa de vista pueda entender.
    /// </summary>
    /// <param name="usuarios">Lista de usuarios a convertir.</param>
    /// <returns>Una lista de objetos anónimos(<seealso cref="Object"/>).</returns>
    private List<Object> ObtenerListaDatosUsuarios(List<Usuario> usuarios) {
      List<Object> cargosDatos = new List<object>();
      foreach (Usuario usuario in usuarios) {
        cargosDatos.Add(ConvertirAnonimo(usuario));
      }
      return cargosDatos;
    }
    /// <summary>
    /// Convierte un objeto <seealso cref="Usuario"/> en un objeto anónimo(<seealso cref="Object"/>) que la capa de Vista puede entender.
    /// </summary>
    /// <param name="usuario">Usuario a convertir.</param>
    /// <returns>Un <seealso cref="Object"/> con los datos del <paramref name="usuario"/>.</returns>
    private Object ConvertirAnonimo(Usuario usuario) {
      return new {
        nombres = usuario.Nombres,
        apellidos = usuario.Apellidos,
        usuario = usuario.Username,
        contrasena = usuario.Contrasena,
        rol = usuario.Rol.Descripcion
      };
    }
    /// <summary>
    /// Busca un <see cref="Recluso"/> cuyo nombre de usuario coincida con <paramref name="user"/>.
    /// </summary>
    /// <param name="user">Nombre de usuario del <see cref="Usuario"/> a buscar.</param>
    /// <returns>Un <see cref="Object"/> con los datos del <see cref="Usuario"/>.</returns>
    public Object BuscarUsuario(string user) {
      return ConvertirAnonimo(_datosLogin.ConsultarUsuario(user));
    }
    /// <summary>
    /// Actualiza los datos de un <see cref="Usuario"/> en específico.
    /// </summary>
    /// <param name="nombre">Nuevo nombre del <see cref="Usuario"/>.</param>
    /// <param name="apellido">Nuevo apellido del <see cref="Usuario"/>.</param>
    /// <param name="usuario">Nombre de usuario para identificar el <see cref="Usuario"/> a actualizar.</param>
    /// <param name="contrasena">Nueva contraseña del <see cref="Usuario"/>.</param>
    /// <param name="rol">Nuevo <see cref="Rol"/> del <see cref="Usuario"/>.</param>
    /// <returns>True si se actualizó correctamente, caso contrario devuelver false.</returns>
    public bool ActualizarUsuario(string nombre, string apellido, string usuario,
                                  string contrasena, string rol) {
      _role = new Rol(rol);
      _user = new Usuario(nombre, apellido, usuario, contrasena, ObtenerRol(rol));
      try {
        _datosLogin.ActualizarUsuario(_user);
        return true;
      } catch (ConsultaFallida) {
        return false;
      }
    }

    /// <summary>
    /// Busca un el rol de un usuario específico que coincida con el <paramref name="usuario"/> ingresado.
    /// </summary>
    /// <param name="usuario">Nombre de usuario del <see cref="Usuario"/> a buscar.</param>
    /// <returns>El <see cref="Rol"/> del <see cref="Usuario"/> específico.</returns>
    public string RetornaRol(string usuario) {
      _user = null;
      _user = _datosLogin.ConsultarUsuario(usuario);

      return _user.Rol.Descripcion;
    }
    /// <summary>
    /// Valida que no exista un usuario con el mismo nombre de usuario(<paramref name="usuario"/>) registrado.
    /// </summary>
    /// <param name="usuario">Nombre de usuario del nuevo <see cref="Usuario"/> a insertar.</param>
    /// <exception cref="Exception">Cuando un <see cref="Usuario"/> con el mismo nombre de usuario ya se encuentra registrado.</exception>
    public void ValidarUsuarioRepetido(string usuario) {
      Usuario user = null;
      user = _datosLogin.ConsultarUsuario(usuario);
      if (user != null) {
        throw new Exception("Usuario ya registrado");
      }
    }
    /// <summary>
    /// Guarda los datos de un nuevo <see cref="Usuario"/>.
    /// </summary>
    /// <param name="nombre">Nombre del nuevo <see cref="Usuario"/>.</param>
    /// <param name="apellido">Apellido del nuevo <see cref="Usuario"/>.</param>
    /// <param name="usuario">Nombre de suario del nuevo <see cref="Usuario"/>.</param>
    /// <param name="contrasena">Contraseña del nuevo <see cref="Usuario"/>.</param>
    /// <param name="rol">Rol del nuevo <see cref="Usuario"/>.</param>
    /// <returns>True si se insertó correctamente, caso contrario devuelver false.</returns>
    public bool GuardarUsuario(string nombre, string apellido, string usuario, string contrasena, string rol) {
      _role = new Rol(rol);
      _user = new Usuario(nombre, apellido, usuario, contrasena, ObtenerRol(rol));
      try {
        _datosLogin.InsertarUsuario(_user);
        return true;
      } catch (ConsultaFallida) {
        return false;
      }
    }
    /// <summary>
    /// Busca un rol cuya descripción coincida con <paramref name="rol"/>.
    /// </summary>
    /// <param name="rol"></param>
    /// <returns>Un <see cref="Rol"/>.</returns>
    public Rol ObtenerRol(string rol) {
      return _datosLogin.ConsultarRol(rol);
    }
  }

}
