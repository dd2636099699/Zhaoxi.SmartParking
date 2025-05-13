using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.Controls
{
    public class PaginationModel : BindableBase
    {
        #region 构造函数
        public PaginationModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navCommand">导航到某页，可以知道需要请求哪一个页面的数据</param>
        /// <param name="countChangeCommand">修改每页的显示数量的时候触发请求数据</param>
        public PaginationModel(ICommand navCommand, ICommand countChangeCommand)
        {
            NavCommand = navCommand;
            CountPerPageChangeCommand = countChangeCommand;
        }
        #endregion

        public ICommand NavCommand { get; set; }
        public ICommand CountPerPageChangeCommand { get; set; }





        /// <summary>
        /// 所有的可显示页    240   24  1-24   
        /// </summary>
        public ObservableCollection<PaginationItemModel> Pages { get; set; } = new ObservableCollection<PaginationItemModel>();




        private int _countPerPage = 10;
        /// <summary>
        /// 每页的显示数据条数
        /// </summary>
        public int CountPerPage
        {
            get => _countPerPage;
            set { SetProperty<int>(ref _countPerPage, value); }
        }


        private int _previousIndex;
        /// <summary>
        /// 前一条数据的Index     如果当前Index=2  1   3
        /// </summary>
        public int PreviousIndex
        {
            get => _previousIndex;
            set { SetProperty<int>(ref _previousIndex, value); }
        }

        private int _nextIndex;
        public int NextIndex
        {
            get => _nextIndex;
            set { SetProperty<int>(ref _nextIndex, value); }
        }



        /// <summary>
        /// 也可以通过命令的
        /// </summary>
        private bool _isCanPrevious = true;
        public bool IsCanPrevious
        {
            get => _isCanPrevious;
            set { SetProperty<bool>(ref _isCanPrevious, value); }
        }

        private bool _isCanNext = true;
        public bool IsCanNext
        {
            get => _isCanNext;
            set { SetProperty<bool>(ref _isCanNext, value); }
        }





        /// <summary>
        /// 填充页码
        /// </summary>
        /// <param name="sumCount">总记录数（数据库中的当的所有有效数据的条数）</param>
        /// <param name="pageCode">当前页码</param>
        public void FillPages(int sumCount, int pageCode)
        {
            IsCanPrevious = true;
            IsCanNext = true;
            PreviousIndex = pageCode - 1;
            NextIndex = pageCode + 1;

            // 总页数
            int pageCount = (int)Math.Ceiling(sumCount * 1.0 / CountPerPage);
            if (pageCode > pageCount) pageCode = pageCount;

            // 处理前一页和后一页按钮的可用性
            if (pageCode == 1)
                IsCanPrevious = false;
            if (pageCode == pageCount)
                IsCanNext = false;


            List<object> temp = new List<object>();
            // 1 2 3 4 [5] 6 7 8 9 ... 15
            // 1 ... 3 4 5 [6] 7 8 9... 15
            // 1 ... 7 8 9 [10] 11 12 13 ... 15
            // 1 ... 8 9 10 [11] 12 13 14 15      10条    50条
            // 省略首页和尾页

            int min = pageCode - 4;
            if (min <= 1) min = 1;
            else min = pageCode - 3;

            int max = pageCode + 4;
            if (pageCode <= 5) max = Math.Min(9, pageCount);
            else
            {
                if (max >= pageCount) max = pageCount;
                else max = pageCode + 3;
            }
            if (pageCode >= pageCount - 4)
                min = Math.Max(1, pageCount - 8);


            if (min > 1)
            {
                temp.Add(1);
                temp.Add("...");
            }
            for (int i = min; i <= max; i++)
                temp.Add(i);
            if (max < pageCount)
            {
                temp.Add("...");
                temp.Add(pageCount);
            }

            int index;
            Pages.Clear();
            foreach (var item in temp)
            {
                bool state = int.TryParse(item.ToString(), out index);
                Pages.Add(new PaginationItemModel
                {
                    Index = (state ? index : item),
                    IsCurrent = index == pageCode,
                    IsEnabled = state
                });
            }
        }
    }

    public class PaginationItemModel : BindableBase
    {
        /// <summary>
        /// 页码（都是数字，不一定，需要对不能显示的页码进行隐藏：...  ）  
        /// </summary>
        public object Index { get; set; }
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// 选中状态
        /// </summary>
        private bool _isCurrent;
        public bool IsCurrent
        {
            get => _isCurrent;
            set { SetProperty<bool>(ref _isCurrent, value); }
        }

    }
}
