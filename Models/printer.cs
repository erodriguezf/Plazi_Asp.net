    namespace HolamundoMVC.Models;
    public static class printer
    {
        public static void DibujarLinea(int tam=10){
            var linea = "".PadLeft(tam,'=');
            Console.WriteLine(linea);
        }

        public static void PresioneEnter(){
            Console.WriteLine("Presino enter para continuar ");
        }

        public static void DibuTitulo(string title){
           DibujarLinea(title.Length+4);
           Console.WriteLine($"| {title} |");
           DibujarLinea(title.Length+4);
        }

         public static void Alarma(int hz, int time){
           System.Console.Beep(hz, time);
        }
    }