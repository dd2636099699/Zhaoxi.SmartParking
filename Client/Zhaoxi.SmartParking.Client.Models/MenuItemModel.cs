using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.SmartParking.Client.Models
{
    public class MenuItemModel : BindableBase
    {
        public int MenuId { get; set; }
        public int Index { get; set; }
        private int _parentId;
        public int ParentId
        {
            get => _parentId;
            set { SetProperty<int>(ref _parentId, value); }
        }

        private int _menuType;
        public int MenuType
        {
            get => _menuType;
            set { SetProperty<int>(ref _menuType, value); }
        }


        private string _menuIcon;
        public string MenuIcon
        {
            get { return _menuIcon; }
            set { SetProperty(ref _menuIcon, value); }
        }

        private string _menuHeader;
        public string MenuHeader
        {
            get { return _menuHeader; }
            set { SetProperty(ref _menuHeader, value); }
        }

        private string _targetView;
        public string TargetView
        {
            get => _targetView;
            set { SetProperty<string>(ref _targetView, value); }
        }

        public MenuItemModel Parent { get; set; }
        private ObservableCollection<MenuItemModel> _children = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MenuItemModel> Children
        {
            get => _children;
            set { SetProperty<ObservableCollection<MenuItemModel>>(ref _children, value); }
        }

        private bool _hasChild;
        public bool HasChild
        {
            get => _hasChild;
            set { SetProperty<bool>(ref _hasChild, value); }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set { SetProperty<bool>(ref _isExpanded, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                SetProperty<bool>(ref _isSelected, value, () =>
                {
                    if (!value && Children != null)
                        Children.ToList().ForEach(m => m.IsSelected = false);
                    if (value && Parent != null && Parent.MenuId > 0)
                        Parent.IsSelected = true;
                });
            }
        }

        private bool _isCurrent;
        public bool IsCurrent
        {
            get => _isCurrent;
            set { SetProperty<bool>(ref _isCurrent, value); }
        }



        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
