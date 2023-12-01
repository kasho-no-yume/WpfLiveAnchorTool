using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLiveAnchorTool
{
    internal static class CustomInput
    {
        public static List<string> paths = new List<string>();
        public static List<string> titles = new List<string>();
        public static List<string> descs = new List<string>();
        static CustomInput()
        {
            var customPaths = DataSaver.ReadTextFile("paths.txt");
            var customTitles = DataSaver.ReadTextFile("titles.txt");
            var customDescs = DataSaver.ReadTextFile("descs.txt");
            paths = customPaths.Split("%%%%%%").ToList();
            titles = customTitles.Split("%%%%%%").ToList();
            descs = customDescs.Split("%%%%%%").ToList();
        }
        private static void SaveListTo(string file,List<string> list)
        {
            if(list.Count == 0) return;
            if(list.Count > 10)
            {
                list = list.GetRange(0, 10);
            }
            string content = list[0];
            for(var i = 1;i<list.Count;i++)
            {
                content += "%%%%%%" + list[i];
            }
            DataSaver.WriteTextFile(file,content);
        }
        public static void SavePath(string path)
        {
            if(string.IsNullOrEmpty(path)) return;
            paths.Remove(path);
            paths.Insert(0, path);
            SaveListTo("paths.txt", paths);
        }
        public static void SaveTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return;
            titles.Remove(title);
            titles.Insert(0, title);
            SaveListTo("titles.txt", titles);
        }
        public static void SaveDesc(string desc)
        {
            if (string.IsNullOrEmpty(desc)) return;
            descs.Remove(desc);
            descs.Insert(0, desc);
            SaveListTo("descs.txt", descs);
        }
    }
}
