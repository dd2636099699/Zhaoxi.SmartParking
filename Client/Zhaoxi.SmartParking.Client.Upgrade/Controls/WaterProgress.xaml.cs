using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zhaoxi.SmartParking.Client.Upgrade.Controls
{
    /// <summary>
    /// WaterProgress.xaml 的交互逻辑
    /// </summary>
    public partial class WaterProgress : UserControl
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(double),
                typeof(WaterProgress),
                new PropertyMetadata(
                    default(double),
                    new PropertyChangedCallback(OnValueChanged)
                    )
                );

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // <DoubleAnimation Duration="0:0:30" From="160" To="0" Storyboard.TargetName="ttg" Storyboard.TargetProperty="Y" RepeatBehavior = "Forever" />
            double newValue = (double)e.NewValue;

            DoubleAnimation da = new DoubleAnimation(160 - newValue * 1.6, TimeSpan.FromMilliseconds(500));
            (d as WaterProgress).ttg.BeginAnimation(TranslateTransform.YProperty, da);
        }

        public WaterProgress()
        {
            InitializeComponent();
        }
    }
}
