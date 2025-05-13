using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.SysModule.Views;

namespace Zhaoxi.SmartParking.Client.SysModule
{
    public class SystemModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FileUploadView>();
            containerRegistry.RegisterForNavigation<MenuManagementView>();

            containerRegistry.RegisterDialog<AddFileDialog>();
            containerRegistry.RegisterDialog<AddMenuDialog>();
        }
    }
}
