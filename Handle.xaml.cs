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
    /// Handle.xaml 的交互逻辑
    /// </summary>
    public partial class Handle : Window
    {
        public Handle()
        {
            InitializeComponent();
            
        }
        public void click_sure(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            var ins = DanmakuPage.Instance;
            if(ins != null )
            {
                ins.MakeWindowTransparent(false);
            }
        }
    }
}
