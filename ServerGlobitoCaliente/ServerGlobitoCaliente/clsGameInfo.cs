using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerGlobitoCaliente
{
    public class clsGameInfo
    {
        //Implementar simgleton para iniciar solo una vez o utilizar estaticos dentro
        public static int puntuacion1 { get; set; }
        public static int puntuacion2 { get; set; }
        public static int pulsacion1 { get; set; }
        public static int pulsacion2 { get; set; }
        public static string jugador1 { get; set; }
        public static string jugador2 { get; set; }
        //TODO Esto no va aqui va dentro de la clase GameInfo
       
    }
}