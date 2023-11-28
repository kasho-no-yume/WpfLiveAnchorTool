using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WpfLiveAnchorTool.EventBus;

namespace WpfLiveAnchorTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DanmakuPage : Window
    {
        public static DanmakuPage Instance { get; private set; }
        private bool alwaysTop;
        public DanmakuPage(string path)
        {
            InitializeComponent();
            alwaysTop = GlobalSetting.alwaysTop;
            inout.Foreground = GlobalSetting.Text;
            watching.Foreground = GlobalSetting.Text;
            mainWindow.Topmost = alwaysTop;
            EventBus.updateComments += UpdateComments;
            EventBus.quitRoom += SomebodyQuit;
            EventBus.enterRoom += SomebodyEnter;
            EventBus.updateNums += UpdateNums;
            MsgSender.SendEnter(path);
            Instance = this;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var border = (Border)this.GetTemplateChild("border");
            if(border != null)
            {
                border.Background = GlobalSetting.Background;
            }
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            if(alwaysTop)
            {
                Window window = (Window)sender;
                window.Topmost = true;
            }                    
        }
        private void Exit(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            EventBus.updateComments -= UpdateComments;
            EventBus.quitRoom -= SomebodyQuit;
            EventBus.enterRoom -= SomebodyEnter;
            EventBus.updateNums -= UpdateNums;
        }
        private void UpdateNums(int nums)
        {
            watching.Text = "当前观看人数：" + nums;
        }
        private void SomebodyEnter(string user)
        {
            inout.Text = user + "进入了直播间";
        }
        private void SomebodyQuit(string user)
        {
            inout.Text = user + "退出了直播间";
        }
        private async void UpdateComments(List<string> comments)
        {
            commentList.Children.Clear();
            foreach (string comment in comments)
            {
                TextBlock commentBlock = new TextBlock();
                commentBlock.Text = comment;
                commentBlock.Foreground = GlobalSetting.Text;
                commentBlock.FontSize = 18;
                commentBlock.Padding = new Thickness(2);
                commentList.Children.Add(commentBlock);
            }
            scroller.ScrollToEnd(); 
        }
        public void ChangeSetting()
        {
            var border = (Border)this.GetTemplateChild("border");
            if (border != null)
            {
                border.Background = GlobalSetting.Background;
            }
            foreach(var i in commentList.Children)
            {
                (i as TextBlock).Foreground = GlobalSetting.Text;
            }
            inout.Foreground = GlobalSetting.Text;
            watching.Foreground = GlobalSetting.Text;
            mainWindow.Topmost = GlobalSetting.alwaysTop;
        }
        private void Setting(object sender, RoutedEventArgs e)
        {
            var setting = new Setting();
            setting.ShowDialog();
        }
    }
}
