using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.SysModule.ViewModels
{
    public class AddFileDialogViewModel : IDialogAware
    {
        public string Title => "系统更新文件上传";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 接收传递的参数

        }




        public ObservableCollection<FileInfoModel> FileList { get; set; } = new ObservableCollection<FileInfoModel>();
        public ICommand SelectFileCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public AddFileDialogViewModel(IUpgradeFileBLL upgradeFileBLL, IEventAggregator ea)
        {
            SelectFileCommand = new DelegateCommand(new Action(() =>
            {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == true)
                {
                    FileList.Clear();
                    if (dialog.FileNames != null && dialog.FileNames.Length > 0)
                    {
                        for (int i = 0; i < dialog.FileNames.Length; i++)
                        {
                            FileList.Add(new FileInfoModel
                            {
                                Index = (i + 1).ToString("00"),
                                FullPath = dialog.FileNames[i],
                                FileName = new FileInfo(dialog.FileNames[i]).Name,
                                State = "待上传"
                            });
                        }
                    }
                }
            }));

            UploadCommand = new DelegateCommand(new Action(async () =>
            {
                if (this.FileList.Count > 0)
                {
                    foreach (var item in this.FileList)
                    {
                        if (item.State != "完成")
                        {
                            var state = await upgradeFileBLL.UploadFile(item.FileName, item.FullPath);
                            if (state)
                                item.State = "完成";
                        }
                    };
                    // 通知主窗口刷新
                    ea.GetEvent<ReLoadEvent>().Publish();
                }
            }));
        }
    }
}
