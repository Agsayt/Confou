using ConfouLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Confou.Logic
{
    public static class StaticResources
    {
        public static BitmapImage GetImage(byte[] array)
        {
            ImageBrush ib = new ImageBrush();
            BitmapImage bImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(array);
            bImg.BeginInit();
            bImg.StreamSource = ms;
            bImg.EndInit();
            return bImg;
        }

        public static Basic LogicManager { get; set; }

    }
}
