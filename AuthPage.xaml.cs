using Microsoft.Win32;
using Newtonsoft.Json;
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
using System.Diagnostics;

namespace WpfLiveAnchorTool
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class AuthPage : Window
    {
        public AuthPage()
        {
            InitializeComponent();
            EventBus.succAuthAnchor += succAuthAnchor;
            txtPath.ItemsSource = CustomInput.paths;
            txtIntroduction.ItemsSource = CustomInput.descs;
            txtTitle.ItemsSource = CustomInput.titles;
        }
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                // 获取选择的文件路径
                string imagePath = openFileDialog.FileName;
                // 处理上传图片的逻辑
            }
        }

        private void succAuthAnchor()
        {
            EventBus.succAuthAnchor -= succAuthAnchor;
            var win = new DanmakuPage(txtPath.Text);
            win.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string path = txtPath.Text;
            string title = txtTitle.Text;
            string introduction = txtIntroduction.Text;
            CustomInput.SaveDesc(introduction);
            CustomInput.SaveTitle(title);
            CustomInput.SavePath(path);
            if(path == null)
            {
                new Alert("错误！", "路径不能为空！").ShowDialog();
                return;
            }
            if(path.Length == 0 || path.Trim().Length == 0)
            {
                new Alert("错误！", "路径不能为空！").ShowDialog();
                return;
            }
            MsgSender.SendAuthAnchor(new LiveRoomIntro(path, title, introduction));          
        }
    }
}
