using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerGlobitoCaliente
{
    public class clsGameInfo
    {
        //Implementar simgleton para iniciar solo una vez o utilizar estaticos dentro
        private int puntuacion1;
        private int puntuacion2;
        private int pulsacion1;
        private int pulsacion2;
        private string jugador1;
        private string jugador2;
        private object ntext;
        private string nm;

        //TODO Esto no va aqui va dentro de la clase GameInfo


        public void enviarPuntos()
        {
            Clients.All.broadcastMessage(puntuacion1, puntuacion2);
        }

        /// <summary>
        /// Nos permite conseguir las pulsaciones de los usuarios
        /// </summary>
        /// <param name="pulsacion">Las veces que ha pulsado el jugador</param>
        public void conseguirPulsaciones(int pulsacion)
        {

            if (Context.ConnectionId == jugador1)
            {
                pulsacion1 = pulsacion;
            }
            else
            {
                pulsacion2 = pulsacion;
            }
            this.SumarPuntos();
        }

        /// <summary>
        /// Suma los puntos al usuario
        /// </summary>
        public void SumarPuntos()
        {
            Random globoExplota = new Random();
            int explota = globoExplota.Next(1, 13);

            if (pulsacion1 > explota)
            {
                puntuacion2 += 1;
            }
            else if (pulsacion2 > explota)
            {
                puntuacion1 += 1;
            }
            else
            {
                if (pulsacion1 > pulsacion2)
                {
                    puntuacion1 += 1;
                }
                else
                {
                    puntuacion2 += 1;
                }
            }

            this.enviarPuntos();

        }

        /// <summary>
        /// Nos permite asignarle un id a los jugadores
        /// </summary>
        public void asignarJugador()
        {
            if (jugador1.Equals(""))
            {
                jugador1 = Context.ConnectionId;
            }
            else
            {
                jugador2 = nm
                 ntext.Conn
                    ectionId;
            }
           
        }
    }
}