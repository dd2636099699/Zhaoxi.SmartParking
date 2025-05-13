using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Unity;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.ReportModule.ViewModels
{
    // 问题：ViewModel无法自动注入
    // 问题原因：程序集路径太长
    // 解决方案：将整个项目Copy到一个短路径目录下，然后一切按照原有方法处理（添加程序集、添加View与ViewModel、注册View、注册Module）后，正常显示

    public class ReportViewModel : PageViewModelBase
    {
        public ObservableCollection<ReportModel> DataList { get; set; } = new ObservableCollection<ReportModel>();

        IReportBLL _reportBLL;
        Dispatcher dispatcher;

        public ReportViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IReportBLL reportBLL
            ) : base(regionManager, unityContainer, ea)
        {
            this.PageTitle = "车辆出入记录统计";

            this.IsShowAdd = false;
            this.IsShowExport = true;

            _reportBLL = reportBLL;
            dispatcher = unityContainer.Resolve<Dispatcher>();
        }

        // 
        public override void Refresh()
        {
            this.ShowLoading();

            // 清空当前数据列表
            DataList.Clear();
            Task.Run(async () =>
            {
                var result = await _reportBLL.GetRecord();

                result.ForEach(r =>
                {
                    // 改变DataList-》界面中出现对象的增加-》UI层面的变化-》Dispatcher.Invoke
                    dispatcher.Invoke(() =>
                    {
                        DataList.Add(new ReportModel
                        {
                            AutoLicense = r.AutoLicense,
                            EnterTime = r.EnterTime,
                            LeaveTime = r.LeaveTime,
                            Cost = r.Cost
                        });
                    });
                });

                this.HideLoading();
            });
        }

        public override void Export()
        {
            // 提示选择保存路径 

            // NPOI   第三方库
            // 创建一个导出对象-》利用导出对象进行数据的填写-》保存到本地文件
            // NPOI ：自己写一个模板（Excel）-》创建对象需要加载这个Excel-》数据填写-》保存到本文件

            // 1、根据模板创建导出对象
            string tempPath = "temp.xlsx";
            IWorkbook workbook = null;
            using (var fs = new FileStream(tempPath, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);// 这个对象针对xlsx   2007版本Office以上
                //workbook = new HSSFWorkbook(fs);// 这个对象针对xls   2007版本Office以下版本
            }

            // 2、填充数据
            var sheet = workbook.GetSheet("Sheet1");
            for (int i = 0; i < DataList.Count; i++)
            {
                if (sheet.GetRow(i + 1) == null) sheet.CreateRow(i + 1);
                sheet.GetRow(i + 1).GetCell(0).SetCellValue(DataList[i].AutoLicense);

                sheet.GetRow(i + 1).GetCell(1).SetCellValue(DataList[i].EnterTime);
                sheet.GetRow(i + 1).GetCell(2).SetCellValue(DataList[i].LeaveTime);
                sheet.GetRow(i + 1).GetCell(3).SetCellValue(DataList[i].Cost);


                // 反射+特性
                //DataList[i].GetType().GetProperties()

                // 指定一个单元格添加链接
                // 设置单元格字体、格式、边框样式
                // 设置列宽、行高
                // 合并单元格
            }

            // 3、保存到本地文件
            string savePath = @"D:\output\test_20210320_export.xlsx";
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}
