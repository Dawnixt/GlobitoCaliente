using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerGlobitoCaliente
{
    public class GameHub : Hub
    {
        //Esto es solo temporal no se inicializa nada aqui
        //TODO cambiar cuando se asignan las connections
        public void enviarPuntos()
        {
            
            Clients.Client(clsGameInfo.jugador1).broadcastMessage(clsGameInfo.puntuacion1,clsGameInfo.puntuacion2);
            Clients.Client(clsGameInfo.jugador2).broadcastMessage(clsGameInfo.puntuacion2, clsGameInfo.puntuacion1);

        }

        /// <summary>
        /// Nos permite conseguir las pulsaciones de los usuarios
        /// </summary>
        /// <param name="pulsacion">Las veces que ha pulsado el jugador</param>
        public void conseguirPulsaciones(int pulsacion)
        {

            if (clsGameInfo.jugador1 == Context.ConnectionId)
            {
                clsGameInfo.pulsacion1 = pulsacion;
                
            }
            else 
            {
                clsGameInfo.pulsacion2 = pulsacion;
            }

            if (clsGameInfo.pulsacion2 != 0)
            {
                this.SumarPuntos();
            }
            
        }

        /// <summary>
        /// Suma los puntos al usuario
        /// </summary>
        public void SumarPuntos()
        {
            Random globoExplota = new Random();
            int explota = globoExplota.Next(1, 13);
            bool puntuado = false;

            if (clsGameInfo.pulsacion1 > explota && !puntuado)
            {
                clsGameInfo.puntuacion2 += 1;
                puntuado = true;
            }
            else if (clsGameInfo.pulsacion2 > explota && !puntuado)
            {
                clsGameInfo.puntuacion1 += 1;
                puntuado = true;
            }
            else
            {
                if (clsGameInfo.pulsacion1 > clsGameInfo.pulsacion2 && !puntuado)
                {
                    clsGameInfo.puntuacion1 += 1;
                    puntuado = true;
                }
                else if(clsGameInfo.pulsacion2 > clsGameInfo.pulsacion1 && !puntuado)
                {
                    clsGameInfo.puntuacion2 += 1;
                    puntuado = true;
                }
            }

            clsGameInfo.pulsacion1 = 0;
            clsGameInfo.pulsacion2 = 0;

            this.enviarPuntos();

        }

        //Este evento ocurre cuando se inicializa la aplicacion
        public override Task OnConnected()
        {
            if (clsGameInfo.jugador1.Equals(""))
            {
                //clsGameInfo.puntuacion1 = 0;
                //clsGameInfo.puntuacion2 = 0;
                //clsGameInfo.jugador1 = "";
                //clsGameInfo.jugador2 = "";
                clsGameInfo.jugador1 = Context.ConnectionId;
            }
            else
            {
                clsGameInfo.jugador2 = Context.ConnectionId;
            }

            return base.OnConnected();

        }

        //public virtual Task OnDisconnected(bool ex)
        //{

        //    return base.OnDisconnected(ex);
        //}

        ///// <summary>
        ///// Nos permite asignarle un id a los jugadores
        ///// </summary>
        //public void asignarJugador()
        //{
        //    if (clsGameInfo.jugador1.Equals(""))
        //    {
        //        clsGameInfo.jugador1 = Context.ConnectionId;
        //    }
        //    else
        //    {
        //        clsGameInfo.jugador2 = Context.ConnectionId;
        //    }

        //}
    }
}