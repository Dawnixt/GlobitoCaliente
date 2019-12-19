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

            //Aqui se podria crear instaciar una clase con la info del juego y enviarsela a los jugadores
        }
    }
}
