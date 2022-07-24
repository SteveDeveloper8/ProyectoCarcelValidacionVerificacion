using System.Collections.Generic;


namespace Model {
  /// <summary>
  /// Representa un Expediente
  /// </summary>
  public class Expediente {
    /// <value>Propiedad id correspondiente al id del expediente.</value>
    private int _id;
    /// <value>Propiedad codigo correspondiente al codigo del expediente.</value>
    private string _codigo;
    /// <value>Propiedad cargos <see cref="Cargo"/> que corresponde al cargo del expediente </value>
    private List<Cargo> _cargos;
    /// <value>Propiedad condenaTotalDias correspondiente a los días de condena del expediente.</value>
    private int _condenaTotalDias;

    /// <summary>
    /// Obtiene o establece la descripcion del expediente.
    /// </summary>
    /// <returns>Una cadena con la descripcion del expediente.</returns>
    public string Codigo { get => _codigo; set => _codigo = value; }
    /// <summary>
    /// Obtiene o establece el cargo del expediente.
    /// </summary>
    /// <returns>Una lista con con los cargos del expediente.</returns>
    public List<Cargo> Cargos { get => _cargos; set => _cargos = value; }
    /// <summary>
    /// Obtiene o establece la condena total en días del expediente.
    /// </summary>
    /// <returns>Una entero con los días totales de la condena del expediente.</returns>
    public int CondenaTotalDias { get => _condenaTotalDias; set => _condenaTotalDias = value; }
    /// <summary>
    /// Obtiene o establece el id del expediente.
    /// </summary>
    /// <returns>Una entero con el id del expediente.</returns>
    public int Id { get => _id; set => _id = value; }

    /// <summary>
    /// Constructor de la clase <c>Expediente</c> que inicializa un nuevo expediente a (<paramref name="id"/>, <paramref name="codigo"/>, <paramref name="cargos"/>, <paramref name="condenaTotalDias"/>).
    /// </summary>
    /// <param name="id">Corresponde al identificador del expediente.</param>
    /// <param name="codigo">Corresponde al código del expediente.</param>
    /// <param name="cargos">Corresponde al cargo del expediente.</param>
    /// <param name="condenaTotalDias">Corresponde a la condena total en días del expediente.</param>
    public Expediente(int id, string codigo, List<Cargo> cargos, int condenaTotalDias) {
      this._id = id;
      this._codigo = codigo;
      this._cargos = cargos;
      this._condenaTotalDias = condenaTotalDias;
    }
    /// <summary>
    /// Constructor de la clase <c>Expediente</c> que inicializa un nuevo expediente a (<paramref name="id"/>, <paramref name="codigo"/>).
    /// </summary>
    /// <param name="id">Corresponde al identificador del expediente.</param>
    /// <param name="codigo">Corresponde al código del expediente.</param>
    public Expediente(int id, string codigo) {
      this._id = id;
      this._codigo = codigo;
    }
    /// <summary>
    /// Constructor de la clase <c>Expediente</c> con valores predeterminados."/>).
    /// </summary>
    public Expediente() {

    }
  }
}
