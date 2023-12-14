using DAL.Entities;

namespace nalvata.Servicios
{
    /// <summary>
    /// Clase que implementa y detalla los metodos para el prestamo
    /// </summary>
    public class PrestamoServiceImpl : IPrestamoService
    {

        private readonly ExaDosContext _contexto;

        public void RealizarPrestamo()
        {
            try
            {
                Console.WriteLine("Introduce la fecha del prestamos");
                DateOnly fechaPrestamo = DateOnly.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el elemento a prestar");
                string elemento = Console.ReadLine();


                _contexto.SaveChanges();
                Console.WriteLine("Reserva realizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar la reserva: "+ex.Message);
            }
        }
    }
}
