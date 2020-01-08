using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobitoCalienteV2_UI.ViewModel
{
    public class clsMainPageVM
    {
        //Propiedades privadas
        private int _puntos;
        private bool _partidaAcabada;
        private int _pulsaciones;
        private int _puntosRival;
        private HubConnection _conn;
        private IHubProxy _proxy;

        public clsMainPageVM()
        {
            _conn = new HubConnection("https://serverglobitocaliente.azurewebsites.net");
            _proxy = _conn.CreateHubProxy("GameHub");
            _conn.Start();
        }

        //Propiedades publicas
        public int Puntos
        {
            get
            {
                return _puntos;
            }
            set
            {
                _puntos = value;
            }
        }

        public int Pulsaciones
        {
            get
            {
                return _pulsaciones;
            }
            set
            {
                _pulsaciones = value;
            }
        }

        public int PuntosRival
        {
            get
            {
                return _puntosRival;
            }
            set
            {
                _puntosRival = value;
            }
        }

        public bool PartidaAcabada
        {
            get
            {
                return _partidaAcabada;
            }
            set
            {
                _partidaAcabada = value;
            }
        }

       

    }
}
