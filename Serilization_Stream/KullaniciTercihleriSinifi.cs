using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serilization_Stream
{
    [Serializable]
    public class KullaniciTercihleriSinifi
    {
        public int windowWidth;
        public int windowHeight;
        public int windowTop;
        public int windowLeft;
        public KullaniciTercihleriSinifi(int _windowWidth, int _windowHeight, int _windowTop, int _windowLeft)
        {
            windowWidth = _windowWidth;
            windowHeight = _windowHeight;
            windowTop = _windowTop;
            windowLeft = _windowLeft;
        }

        
    }
}
