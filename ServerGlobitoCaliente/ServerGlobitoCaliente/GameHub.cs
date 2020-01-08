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
        private int pulsacion1;
        private int pulsacion2;
        private int explota;
        private string jugador1;
        private string jugador2;
        public void enviarPuntos()
        {
            Clients.All.broadcastMessage(puntuacion1, puntuacion2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="puntuacion"></param>
        public void comprobarGanadorValido(int pulsacion)
        {

            Random globoExplota = new Random();
            explota = globoExplota.Next(3,13);

            if(explota > pulsacion)
            {
                if (Context.ConnectionId == jugador1)
                {
                    pulsacion1 = pulsacion;
                }
                else
                {
                    pulsacion2 = pulsacion;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SumarPuntos()
        {
            if (pulsacion1 == 0)
            {
                puntuacion2 += 1;
            }
            else if(pulsacion2 == 0)
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
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void asignarJugador()
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