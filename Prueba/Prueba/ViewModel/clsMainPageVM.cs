using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace GlobitoCalienteV2_UI.ViewModel
{
    public class clsMainPageVM : INotifyPropertyChanged
    {
        //Propiedades privadas
        private int _puntos;
        private int _pulsaciones;
        private int _puntosRival;
        private DelegateCommand _pulsador;
        private DelegateCommand _enviarDatos;
        private HubConnection _conn;
        private IHubProxy _proxy;

        //Constructor
        public clsMainPageVM()
        {
            _pulsaciones = 0;
            _puntos = 0;
            _puntosRival = 0;
            _conn = new HubConnection("https://serverglobitocaliente.azurewebsites.net");
            //_conn = new HubConnection("http://localhost:51898/signalr");
            //_conn = new HubConnection("http://localhost:51898/");
            _proxy = _conn.CreateHubProxy("GameHub");
            _conn.Start();
            _proxy.On<int,int>("broadcastMessage", enviarPuntos);

            _enviarDatos = new DelegateCommand(EnviarDatos_Executed, EnviarDatos_CanExecute);
            _pulsador = new DelegateCommand(Pulsador_Executed);
        }

        //Cosas extra

        /// <summary>
        /// Este evento se ejecuta cuando el servidor llama a enviarPuntos
        /// </summary>
        /// <param name="puntosJugador">Los puntos del jugador</param>
        /// <param name="puntosRival">Los puntos del rival</param>
        private async void enviarPuntos(int puntosJugador,int puntosRival)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {

                Puntos = puntosJugador;
                PuntosRival = puntosRival;
                NotifyPropertyChanged("Puntos");
                NotifyPropertyChanged("PuntosRival");

            });
                
        }

        //Notify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Funciones extra

        /// <summary>
        /// Este evento se activa  al pulsar el pulsador y le suma uno a las pulsaciones
        /// </summary>
        private void Pulsador_Executed()
        {
            Pulsaciones += 1;
            NotifyPropertyChanged("Pulsaciones");
            NotifyPropertyChanged("EnviarDatos");
            _enviarDatos.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Este evento se activa  al pulsar el boton de acabar y envia los datos al servidor
        /// </summary>
        private void EnviarDatos_Executed()
        {
            _proxy.Invoke("conseguirPulsaciones", Pulsaciones);
            Pulsaciones = 0;
            NotifyPropertyChanged("Pulsaciones");
            _enviarDatos.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Esta funcion nos permite saber si se puede ejecutar el boton de acabar
        /// </summary>
        /// <returns>Un bool que nos indica si se puede ejecutar el boton de acabar</returns>
        private bool EnviarDatos_CanExecute()
        {
            bool res = false;
            if (_pulsaciones >= 1)
            {
                res = true;
            }
            return res;
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

        public IHubProxy Proxy
        {
            get
            {
                return _proxy;
            }
            set
            {
                _proxy = value;
            }
        }

        public HubConnection Conn
        {
            get
            {
                return _conn;
            }
        }

        public DelegateCommand Pulsador
        {
            get
            {
                return _pulsador;
            }
        }

        public DelegateCommand EnviarDatos
        {
            get
            {
                return _enviarDatos;
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
                NotifyPropertyChanged("EnviarDatos");
                _enviarDatos.RaiseCanExecuteChanged();
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
       
    }
}
