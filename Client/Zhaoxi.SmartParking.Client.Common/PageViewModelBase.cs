using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;

namespace Zhaoxi.SmartParking.Client.Common
{
    public class PageViewModelBase : BindableBase, INavigationAware
    {
        public string PageTitle { get; set; } = "标签标题";
        public bool IsCanClose { get; set; } = true;
        public string NavUri { get; set; }

        public bool IsShowRefresh { get; set; } = true;
        public bool IsShowAdd { get; set; } = true;
        public bool IsShowExport { get; set; } = false;

        public DelegateCommand<string> CloseCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand ExportCommand { get; set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set { SetProperty<string>(ref _searchText, value); }
        }

        public Func<bool> CanNavigationTargetFunc { get; set; }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return CanNavigationTargetFunc == null ? true : CanNavigationTargetFunc();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public Action<NavigationContext> NavigatedToAction;
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
            // 传递过来的车道
            NavigatedToAction?.Invoke(navigationContext);
        }




        protected void ShowLoading(string tip = "正在加载....")
        {
            _ea?.GetEvent<LoadingEvent>().Publish(new LoadingPayload { IsShow = true, Message = tip });
        }
        protected void HideLoading()
        {
            _ea?.GetEvent<LoadingEvent>().Publish(new LoadingPayload { IsShow = false });
        }




        IEventAggregator _ea;
        public PageViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _ea = ea;

            CloseCommand = new DelegateCommand<string>((param) =>
            {
                var obj = unityContainer.Registrations.Where(v => v.Name == NavUri).FirstOrDefault();
                string name = obj.MappedToType.Name;
                if (!string.IsNullOrEmpty(name))
                {
                    var region = regionManager.Regions["MainContentRegion"];
                    var view = region.Views.Where(v => v.GetType().Name == name).FirstOrDefault();
                    if (view != null)
                        region.Remove(view);
                }
            });

            RefreshCommand = new DelegateCommand(Refresh);
            AddCommand = new DelegateCommand(AddItem);
            ExportCommand = new DelegateCommand(Export);

            this.Refresh();
        }

        public virtual void Refresh() { }
        public virtual void AddItem() { }
        public virtual void Export() { }
    }
}
