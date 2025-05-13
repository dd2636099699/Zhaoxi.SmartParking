using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.SmartParking.Client.Upgrade.ViewModel
{
    public class FinishViewModel : BindableBase
    {
        public Action<bool> ConfirmAction;

        private bool _isRunning = true;

        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetProperty(ref _isRunning, value); }
        }

        private ICommand _confirmCommand;

        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                    _confirmCommand = new DelegateCommand(() =>
                    {
                        ConfirmAction?.Invoke(IsRunning);
                    });
                return _confirmCommand;
            }
        }

    }
}
