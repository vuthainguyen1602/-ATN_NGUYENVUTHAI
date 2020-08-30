using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace PhanCumSinhVien
{
    public partial class frm_KhoiDong : SplashScreen
    {
        public frm_KhoiDong()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void marqueeProgressBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}