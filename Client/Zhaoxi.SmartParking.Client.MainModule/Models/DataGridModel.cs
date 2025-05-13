using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.SmartParking.Client.MainModule.Models
{
    public class DataGridModel
    {
        public Action action;

        public ICommand MenuItemCommand { get; set; } = new DelegateCommand(() => { });

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}
