namespace nalvata.Util
{
    public static class Util
    {

        public static int CapturaEntero(string mensaje, int min, int max)
        {
            int valor = 0;
            bool numCorrecto;

            do
            {
                Console.Write("\n\t{0} [{1}..{2}]: ", mensaje, min, max);
                numCorrecto = Int32.TryParse(Console.ReadLine(), out valor);

                if (!numCorrecto)
                    Console.WriteLine("\n\t** [ERROR] No ha introducido un número entero. **");
                else if (valor < min || valor > max)
                {
                    numCorrecto = false;
                    Console.WriteLine("\n\t** [ERROR] El número introducido es negativo. **", min);
                }


            } while (!numCorrecto);

            return valor;
        }
    }
}
