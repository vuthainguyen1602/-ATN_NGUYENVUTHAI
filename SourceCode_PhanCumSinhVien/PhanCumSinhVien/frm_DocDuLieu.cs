using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanCumSinhVien
{
    public partial class frm_DocDuLieu : UserControl
    {
        public frm_DocDuLieu()
        {
            InitializeComponent();
        }

        private void dgv_DuLieu_Load(object sender, EventArgs e)
        {
            dgv_DuLieu.DataSource = frm_Main.path_src.dt;
            lab_DuongDan.Text = frm_Main.path_src.path;
        }
    }
}
