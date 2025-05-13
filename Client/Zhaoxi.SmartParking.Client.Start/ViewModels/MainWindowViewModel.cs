using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;

namespace Zhaoxi.SmartParking.Client.Start.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _loadingMessage;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetProperty(ref _loadingMessage, value); }
        }
        public DelegateCommand CancelLoadingCommand { get => new DelegateCommand(() => IsLoading = false); }

        public MainWindowViewModel(IEventAggregator ea)
        {
            //this.IsLoading = true;
            //this.LoadingMessage = "正在加载";

            ea.GetEvent<LoadingEvent>().Subscribe(OnShowLoading, ThreadOption.UIThread);
        }

        private void OnShowLoading(LoadingPayload msg)
        {
            this.IsLoading = msg.IsShow;
            this.LoadingMessage = msg.Message;
        }
    }
}
