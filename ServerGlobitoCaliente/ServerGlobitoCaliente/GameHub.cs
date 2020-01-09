using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerGlobitoCaliente
{
    public class GameHub : Hub
    {
        //Esto es solo temporal no se inicializa nada aqui
        //TODO enviar cadena de conexion para saber quien es quien
        public void enviarPuntos()
        {
            Clients.All.broadcastMessage(clsGameInfo.puntuacion1, clsGameInfo.puntuacion2);
        }

        /// <summary>
        /// Nos permite conseguir las pulsaciones de los usuarios
        /// </summary>
        /// <param name="pulsacion">Las veces que ha pulsado el jugador</param>
        public void conseguirPulsaciones(int pulsacion)
        {

            if (clsGameInfo.jugador1.Equals(""))
            {
                clsGameInfo.pulsacion1 = pulsacion;
                clsGameInfo.jugador1 = Context.ConnectionId;
            }
            else
            {
                clsGameInfo.pulsacion2 = pulsacion;
                clsGameInfo.jugador2 = Context.ConnectionId;
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

            if (clsGameInfo.pulsacion1 > explota)
            {
                clsGameInfo.puntuacion2 += 1;
            }
            else if (clsGameInfo.pulsacion2 > explota)
            {
                clsGameInfo.puntuacion1 += 1;
            }
            else
            {
                if (clsGameInfo.pulsacion1 > clsGameInfo.pulsacion2)
                {
                    clsGameInfo.puntuacion1 += 1;
                }
                else
                {
                    clsGameInfo.puntuacion2 += 1;
                }
            }

            this.enviarPuntos();

        }

        /// <summary>
        /// Nos permite asignarle un id a los jugadores
        /// </summary>
        public void asignarJugador()
        {
            if (clsGameInfo.jugador1.Equals(""))
            {
                clsGameInfo.jugador1 = Context.ConnectionId;
            }
            else
            {
                clsGameInfo.jugador2 = Context.ConnectionId;
            }

        }
    }
}