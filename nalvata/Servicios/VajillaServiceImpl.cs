using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace nalvata.Servicios
{
    /// <summary>
    /// Clase que implementa los metodos para el CRUD de los elementos de la Vajilla
    /// </summary>
    public class VajillaServiceImpl : IVajillaService
    {

        private readonly ExaDosContext _contexto;

        public VajillaServiceImpl(ExaDosContext contexto)
        {
            _contexto = contexto;
        }


        /// <summary>
        ///  Muestra por consola el stock actual de las vajillas
        /// </summary>
        public void findAll()
        {
            List<Vajilla> vajillas = _contexto.Vajillas.ToList();
            if (vajillas != null)
            {
                foreach (Vajilla vajilla in vajillas)
                {
                    vajilla.MostrarDatos();
                }

            }
        }

        /// <summary>
        ///  Busca la vajila por su codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Vajilla findByCodigo(string codigo)
        {

            Vajilla? vajilla = _contexto.Vajillas.Include(v => v.Codigo == codigo).FirstOrDefault();

            if (vajilla != null)
            {
                return vajilla;

            }
            else
            {
                Console.WriteLine("[Error] Vajilla no encontrada por su codigo");
            }
            return null;
        }

        /// <summary>
        ///  Pide al usuario que introduzca los datos de la vajilla para posteriormente insertarla en la bbdd
        /// </summary>
        public void save()
        {
            try
            {
                Vajilla v = new Vajilla();
                string descripcion;

                Console.Write("\n\tInserte el nombre del elemento vajilla: ");
                string nombreElemento = Console.ReadLine();
                v.Nombre = nombreElemento;

                Console.Write("\n\tInserte la descripción del elemento vajilla: ");
                descripcion = Console.ReadLine();
                v.Descripcion = descripcion;

                v.Cantidad = Util.Util.CapturaEntero("Inserte la cantidad de stock del elemento", 0, 999);

                v.Codigo = "Elem-" + nombreElemento;

                _contexto.Vajillas.Add(v);
                _contexto.SaveChanges();

                Console.WriteLine("\n\t\t[Info] Vajilla insertada correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\t\t[Error] Ocurrió un error no esperado:" + e.Message);
            }
        }


    }
}
