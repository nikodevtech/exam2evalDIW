namespace nalvata.Servicios
{
    /// <summary>
    /// Interface que declara los metodos para el menu
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// Muestra el menu y captura la opcion
        /// </summary>
        /// <returns>Un entero con la opción seleccionada</returns>
        public int CargarMenu();
    }
}
