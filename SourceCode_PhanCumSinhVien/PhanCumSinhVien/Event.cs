using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCumSinhVien
{

    public delegate void ThucHien_Click(object sender, ThucHien_Clicked e);
    public class ThucHien_Clicked : EventArgs
    {
        public string a { get; set; }
    }

    
}
