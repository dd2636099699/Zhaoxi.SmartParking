using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.SmartParking.Client.MainModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }
        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public List<MenuItemModel> Children { get; set; }

        private ICommand _openViewCommand;

        public ICommand OpenViewCommand
        {
            get
            {
                if (_openViewCommand == null)
                    _openViewCommand = new DelegateCommand<MenuItemModel>((model) =>
                    {
                        if ((model.Children == null || model.Children.Count == 0) &&
                        !string.IsNullOrEmpty(model.TargetView))
                            _regionManager.RequestNavigate("MainContentRegion", model.TargetView);
                        else
                            IsExpanded = !IsExpanded;
                    });
                return _openViewCommand;
            }
        }

        IRegionManager _regionManager = null;
        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
