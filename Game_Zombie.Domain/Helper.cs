﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game_Zombie.Domain
{
   internal static class Helper
    {
        public static ImageBrush ObterImagem(byte[] bytes)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = new MemoryStream(bytes);
            img.EndInit();
            return new ImageBrush(img);
        }
    }
}
