using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ServerGlobitoCaliente.Startup))]

namespace ServerGlobitoCaliente
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            clsGameInfo.pulsacion1 = 0;
            clsGameInfo.pulsacion2 = 0;
            clsGameInfo.puntuacion1 = 0;
            clsGameInfo.puntuacion2 = 0;
            clsGameInfo.jugador1 = "";
            clsGameInfo.jugador2 = "";
            //Aqui se podria crear instaciar una clase con la info del juego y enviarsela a los jugadores
            //Aqui inicializo las cosas
        }
    }
}
