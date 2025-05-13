using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.BaseModule.Views;

namespace Zhaoxi.SmartParking.Client.BaseModule
{
    public class BaseInfoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserManagementView>();
            containerRegistry.RegisterForNavigation<RoleManagementView>();

            containerRegistry.RegisterDialog<AddUserDialog>();
            containerRegistry.RegisterDialog<ModifyRolesDialog>();
            containerRegistry.RegisterDialog<AddRoleDialog>();
            containerRegistry.RegisterDialog<SelectUserDialog>();
        }
    }
}
