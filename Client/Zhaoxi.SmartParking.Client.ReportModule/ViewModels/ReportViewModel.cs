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
    // ���⣺ViewModel�޷��Զ�ע��
    // ����ԭ�򣺳���·��̫��
    // �����������������ĿCopy��һ����·��Ŀ¼�£�Ȼ��һ�а���ԭ�з���������ӳ��򼯡����View��ViewModel��ע��View��ע��Module����������ʾ

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
            this.PageTitle = "���������¼ͳ��";

            this.IsShowAdd = false;
            this.IsShowExport = true;

            _reportBLL = reportBLL;
            dispatcher = unityContainer.Resolve<Dispatcher>();
        }

        // 
        public override void Refresh()
        {
            this.ShowLoading();

            // ��յ�ǰ�����б�
            DataList.Clear();
            Task.Run(async () =>
            {
                var result = await _reportBLL.GetRecord();

                result.ForEach(r =>
                {
                    // �ı�DataList-�������г��ֶ��������-��UI����ı仯-��Dispatcher.Invoke
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
            // ��ʾѡ�񱣴�·�� 

            // NPOI   ��������
            // ����һ����������-�����õ�������������ݵ���д-�����浽�����ļ�
            // NPOI ���Լ�дһ��ģ�壨Excel��-������������Ҫ�������Excel-��������д-�����浽���ļ�

            // 1������ģ�崴����������
            string tempPath = "temp.xlsx";
            IWorkbook workbook = null;
            using (var fs = new FileStream(tempPath, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);// ����������xlsx   2007�汾Office����
                //workbook = new HSSFWorkbook(fs);// ����������xls   2007�汾Office���°汾
            }

            // 2���������
            var sheet = workbook.GetSheet("Sheet1");
            for (int i = 0; i < DataList.Count; i++)
            {
                if (sheet.GetRow(i + 1) == null) sheet.CreateRow(i + 1);
                sheet.GetRow(i + 1).GetCell(0).SetCellValue(DataList[i].AutoLicense);

                sheet.GetRow(i + 1).GetCell(1).SetCellValue(DataList[i].EnterTime);
                sheet.GetRow(i + 1).GetCell(2).SetCellValue(DataList[i].LeaveTime);
                sheet.GetRow(i + 1).GetCell(3).SetCellValue(DataList[i].Cost);


                // ����+����
                //DataList[i].GetType().GetProperties()

                // ָ��һ����Ԫ���������
                // ���õ�Ԫ�����塢��ʽ���߿���ʽ
                // �����п��и�
                // �ϲ���Ԫ��
            }

            // 3�����浽�����ļ�
            string savePath = @"D:\output\test_20210320_export.xlsx";
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}
