using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WpfLiveAnchorTool
{
    
    internal static class DataSaver
    {
        static string mainDir = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
        public static string ReadTextFile(string filePath)
        {
            try
            {
                if (!File.Exists(mainDir + "/" + filePath))
                {
                    var fs = File.Create(mainDir + "/" + filePath);
                    Debug.WriteLine(mainDir + "/" + filePath);
                    fs.Close();
                }
                var file = mainDir + "\\" + filePath;
                var s = File.ReadAllText(file);
                return s;
            }
            catch (Exception ex)
            {
                EventBus.codeError(ex);
                return "";
            }
        }
        public static void WriteTextFile(string file,string content)
        {
            try
            {
                File.WriteAllText(mainDir + "\\" + file, content);
            }
            catch (Exception ex)
            {
                EventBus.codeError(ex);
            }
        }
    }
}
