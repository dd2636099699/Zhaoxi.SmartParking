using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Unity;
using Zhaoxi.Controls;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.AutoModule.ViewModels
{
    public class AutoRegisterViewModel : PageViewModelBase
    {
        public PaginationModel PaginationModel { get; set; } = new PaginationModel();
        public ObservableCollection<AutoInfoModel> AutoList { get; set; } = new ObservableCollection<AutoInfoModel>();

        Dispatcher _dispatcher;
        IAutoRegisterBLL _autoRegisterBLL;
        public AutoRegisterViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IAutoRegisterBLL autoRegisterBLL
            )
            : base(regionManager, unityContainer, ea)
        {
            this.PageTitle = "车辆登记管理";
            _dispatcher = unityContainer.Resolve<Dispatcher>();
            _autoRegisterBLL = autoRegisterBLL;

            // 中间的页码点击
            // 向前向后 也会触发
            PaginationModel.NavCommand = new DelegateCommand<object>(obj =>
            {
                Index = int.Parse(obj.ToString());
                this.Refresh();
            });
            // 改变每页条目数
            PaginationModel.CountPerPageChangeCommand = new DelegateCommand(() =>
            {
                this.Refresh();
            });
        }

        private int Index = 1;
        public override void Refresh()
        {
            this.ShowLoading();
            AutoList.Clear();

            ///回调  Thread   C#  
            Task.Run(async () =>
            {
                var result =await _autoRegisterBLL.GetAll(Index, PaginationModel.CountPerPage);
                if (result.State == 1)
                {
                    var datas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AutoRegisterEntity>>(result.Data);
                    _dispatcher.Invoke(() =>
                    {
                        // 填充车辆信息
                        for (int i = 0; i < datas.Count; i++)
                        {
                            AutoList.Add(new AutoInfoModel
                            {
                                Num = (Index - 1) * PaginationModel.CountPerPage + i + 1,
                                AutoLicense = datas[i].AutoLicense,
                                LColorId = datas[i].LColorId,
                                LColorName = datas[i].LColorName,
                                AColorId = datas[i].AColorId,
                                AColorName = datas[i].AColorName,
                                FeeModelId = datas[i].FeeModelId,
                                FeeModelName = datas[i].FeeModelName,
                                Description = datas[i].Description
                            });
                        }

                        // 填充页码
                        PaginationModel.FillPages(result.PageInfo.RecordCount, result.PageInfo.PageIndex);
                    });
                }

                this.HideLoading();
            });
        }
        public override void AddItem()
        {
            base.AddItem();
        }
    }
}
