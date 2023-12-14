
using nalvata.Servicios;

namespace nalvata
{
    /// <summary>
    ///  Clase que implementa la interfaz MenuService y define los metodos allí declarados
    /// </summary>
    public class MenuServiceImpl : IMenuService
    {
        public int CargarMenu()
        {
            int opcion = 0;
            try
            {
                Console.WriteLine("\n\t--- Menu ---");
                Console.WriteLine("\t1. Registrar nueva vajilla");
                Console.WriteLine("\t2. Mostrar Stock");
                Console.WriteLine("\t3. Realizar reserva");
                Console.WriteLine("\t0. Salir");

                opcion = Util.Util.CapturaEntero("Introduce una opcion: ", 0, 3);
            }
            catch (FormatException e)
            {
                Console.WriteLine("\t[Error] No ha introducido un valor numerico" + e.Message);
            }

            return opcion;
        }

    }
}
