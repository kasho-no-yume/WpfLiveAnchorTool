using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLiveAnchorTool
{
    class LiveRoomIntro
    {
        public string path;
        public string? title;
        public string? desc;
        public LiveRoomIntro(string path,string? title,string? desc) 
        { 
            this.path = path;
            this.title = title;
            this.desc = desc;
        }
    }
}
