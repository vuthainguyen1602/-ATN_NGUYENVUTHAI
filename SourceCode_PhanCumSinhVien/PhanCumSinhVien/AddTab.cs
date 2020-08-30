using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanCumSinhVien
{
    class AddTab
    {
        public void AddTabControl(XtraTabControl xtraTabParent, string xtraItemName, string icon, UserControl userControl)
        {
            XtraTabPage xtraTabPage = new XtraTabPage();
            xtraTabPage.Name = "Test";
            xtraTabPage.Dock = DockStyle.Fill;
            xtraTabPage.Text = xtraItemName;
            xtraTabPage.Image = Bitmap.FromFile(@"Resource\" + icon);
            xtraTabPage.Controls.Add(userControl);
            xtraTabParent.TabPages.Add(xtraTabPage);
        }
    }
}
