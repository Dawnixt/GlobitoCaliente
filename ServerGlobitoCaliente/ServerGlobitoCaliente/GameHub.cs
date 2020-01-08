using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerGlobitoCaliente
{
    public class GameHub : Hub
    {

        private int puntuacion1;
        private int puntuacion2;
        private string jugador1;
        private string jugador2;
        public void EnviarPuntos()
        {
            Clients.All.broadcastMessage(puntuacion1, puntuacion2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="puntuacion"></param>
        public void comprobarGanador(int pulsacion)
        {

            Random globoExplota = new Random();
            int antesExplotar;

            antesExplotar = globoExplota.Next(3,13);

            if(antesExplotar > pulsacion)
            {
                if (Context.ConnectionId == jugador1)
                {
                    puntuacion1 += 1;
                }
                else
                {
                    puntuacion2 += 1;
                }
            }
            EnviarPuntos();
        }

        /// <summary>
        /// 
        /// </summary>
        public void elegirJugador()
        {
            if (jugador1.Equals(""))
            {
                jugador1 = Context.ConnectionId;
            }
            else
            {
                jugador2 = Context.ConnectionId;
            }
        }
    }
}