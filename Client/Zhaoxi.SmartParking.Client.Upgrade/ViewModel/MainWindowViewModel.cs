using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.Upgrade.DAL;
using Zhaoxi.SmartParking.Client.Upgrade.Model;

namespace Zhaoxi.SmartParking.Client.Upgrade.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private LocalDataAccess localDataAccess = new LocalDataAccess();
        private WebDataAccess webDataAccess = new WebDataAccess();

        public Action ConfirmAction;
        public MainWindowViewModel(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                string[] arg = files[i].Split('|');
                FileList.Add(new FileInfoModel
                {
                    Index = (i + 1),
                    FileName = arg[0],
                    FileMd5 = arg[1],
                    State = "待更新",
                    Progress = 0
                });
            }
        }
        private int _progress;

        public int Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        public ObservableCollection<FileInfoModel> FileList { get; set; } = new ObservableCollection<FileInfoModel>();

        private ICommand _startCommand;

        public ICommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                    _startCommand = new DelegateCommand(OnStart).ObservesCanExecute(() => IsCanStart);

                return _startCommand;
            }
        }
        private bool _isCanStart = true;

        public bool IsCanStart
        {
            get { return _isCanStart; }
            set { SetProperty(ref _isCanStart, value); }
        }

        private int completedCount = 0;
        private void OnStart()
        {
            if (FileList.Count > 0)
            {
                IsCanStart = false;

                Task.Run(async () =>
                {
                    int count = await webDataAccess.DownloadAsync(
                          FileList.ToList(),
                          new Action<FileInfoModel>((fi) =>
                          {
                              completedCount++;
                              Progress = (int)(completedCount * 1.0 / FileList.Count * 100);
                          }));

                   
                    if (FileList.Count != count)
                        IsCanStart = true;
                    else
                    {
                        // 打开更新完成确认窗口
                        ConfirmAction?.Invoke();
                    }

                });
            }
        }
    }
}
