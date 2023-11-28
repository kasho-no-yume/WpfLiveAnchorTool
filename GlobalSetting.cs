using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfLiveAnchorTool
{
    public static class GlobalSetting
    {
        private static BrushConverter _converter = new BrushConverter();
        public static string BackgroundColor;
        public static string TextColor;
        public static bool alwaysTop;
        public static Brush Background
        {
            get { return _converter.ConvertFromString(BackgroundColor) as Brush; }
            set { BackgroundColor = _converter.ConvertToString(Background); }
        }
        public static Brush Text
        {
            get { return _converter.ConvertFromString(TextColor) as Brush; }
            set { TextColor = _converter.ConvertToString(Text); }
        }
        static GlobalSetting()
        {
            var property = DataSaver.ReadTextFile("custom.txt");
            if(property.Length == 0)
            {
                BackgroundColor = "#10FFFFFF";
                TextColor = "#000000";
                alwaysTop = true;               
                SaveToLocal();
                return;
            }
            else
            {
                string[] res = property.Split("\n");
                BackgroundColor = res[0];
                TextColor = res[1];
                alwaysTop = res[2] == "True";
            }
            
        }
        public static void SaveToLocal()
        {
            DataSaver.WriteTextFile("custom.txt", BackgroundColor + "\n" + TextColor + "\n" + alwaysTop);
        }

    }
}
