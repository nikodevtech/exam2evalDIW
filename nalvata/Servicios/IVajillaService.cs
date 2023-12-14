using DAL.Entities;

namespace nalvata.Servicios
{

    /// <summary>
    /// Interface que declara los metodos para el CRUD de los elementos de Vajilla
    /// </summary>
    public interface IVajillaService
    {


        /// <summary>
        ///   Guarda un elemento de Vajilla en la base de datos
        /// </summary>
        /// <param name="vajilla">Objeto vajilla para ser guardada</param>
        public void save();


        /// <summary>
        ///  Busca todos los elementos de Vajilla
        /// </summary>
        public void findAll();

        /// <summary>
        /// Busca un elemento de Vajilla por su codigo
        /// </summary>
        /// <param name="codigo">campo codigo de la vajilla a buscar</param>
        /// <returns>Vajilla encontrada por su codigo</returns>
        public Vajilla findByCodigo(String codigo);
    }
}
