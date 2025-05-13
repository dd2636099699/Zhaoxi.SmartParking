using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.MainModule.ViewModels
{
    public class MainHeaderViewModel : BindableBase
    {
        public string CurrentUserName { get; set; }

        public MainHeaderViewModel(IContainerProvider containerProvider)
        {
            if (GlobalEntity.CurrentUserInfo != null)
            {
                CurrentUserName = GlobalEntity.CurrentUserInfo.RealName;
            }
        }
    }
}
