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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfLiveAnchorTool
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        private BrushConverter _converter = new BrushConverter();
        public Setting()
        {
            InitializeComponent();
            picker1.SelectedColor = (Color)ColorConverter.ConvertFromString(GlobalSetting.BackgroundColor);
            picker2.SelectedColor = (Color)ColorConverter.ConvertFromString(GlobalSetting.TextColor);
            alwaysTop.IsChecked = GlobalSetting.alwaysTop;
        }
        public void Save(object sender, RoutedEventArgs e)
        {
            GlobalSetting.BackgroundColor = picker1.SelectedColor.ToString();
            GlobalSetting.TextColor = picker2.SelectedColor.ToString();
            GlobalSetting.alwaysTop = (bool)alwaysTop.IsChecked;
            GlobalSetting.SaveToLocal();
            DanmakuPage.Instance.ChangeSetting();
            this.Close();
        }
    }
}
