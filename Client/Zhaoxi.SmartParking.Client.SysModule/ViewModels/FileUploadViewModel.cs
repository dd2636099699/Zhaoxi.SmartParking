using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Unity;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.SysModule.ViewModels
{
    // 现在的前期代码跟课程差别很大，在
    // 用户-角色-菜单 
    // 添加了一个上传文件管理页面
    // 花时间做调整
    public class FileUploadViewModel : PageViewModelBase
    {
        public ObservableCollection<FileInfoModel> Files { get; set; } = new ObservableCollection<FileInfoModel>();


        IUnityContainer _unityContainer;
        IEventAggregator _ea;
        IDialogService _dialogService;
        IUpgradeFileBLL _upgradeFileBLL;
        public FileUploadViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IDialogService dialogService,
            IUpgradeFileBLL upgradeFileBLL)
            : base(regionManager, unityContainer, ea)
        {
            _unityContainer = unityContainer;
            _ea = ea;
            _dialogService = dialogService;
            _upgradeFileBLL = upgradeFileBLL;

            this.PageTitle = "更新文件上传管理";

            InitInfo();
        }

        private void InitInfo()
        {
            _ea.GetEvent<ReLoadEvent>().Subscribe(Refresh);
        }

        public override void Refresh()
        {
            this.ShowLoading();
            Files.Clear();
            Task.Run(new Action(async () =>
            {
                var files = await _upgradeFileBLL.AllFileListAsync();
                _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                {
                    files.ForEach(f => { Files.Add(f); });
                });
                this.HideLoading();
            }));
        }

        public override void AddItem()
        {
            // Prism框架的Dialog对象
            _dialogService.ShowDialog("AddFileDialog");
        }
    }
}
