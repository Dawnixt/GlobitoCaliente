using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GlobitoCalienteV2_UI.ViewModel
{
    public class DelegateCommand : ICommand
    {

        private readonly Action _ejecutar;

        private readonly Func<bool> _canExecute;

        //Constructores

        public DelegateCommand(Action ejecutar, Func<bool> canExecute)
        {

            if (ejecutar == null)
            {

                throw new ArgumentNullException("ejecutar");

            }

            this._ejecutar = ejecutar;
            this._canExecute = canExecute;

        }

        /// <summary>
        /// Este constructor inicializa el delegateCommand para que siempre funcione
        /// </summary>
        /// <param name="ejecutar"></param>
        public DelegateCommand(Action ejecutar) : this(ejecutar, null)
        {



        }

        /// <summary>
        /// Ocurre cuando ocurre algun cambio que afecta si el comando debe ejecutarse
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Llama al evento
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Este metodo permite saber si se puede ejecutar el parametro
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Este metodo es llamado cuando el comando es invocado
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {

                _ejecutar();

            }
        }
    }
}
