namespace PhanCumSinhVien
{
    partial class frm_PhanCumChiTiet
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhanCumChiTiet));
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Time = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lst_Subject = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txt_SoCum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.txt_SoLanLap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dgv_KetQua = new DevExpress.XtraGrid.GridControl();
            this.KetQua = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt_ChoVao1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ChoVao = new DevExpress.XtraEditors.LabelControl();
            this.txt_Cum = new DevExpress.XtraEditors.LabelControl();
            this.txt_KhoangCach = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DangXet = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Time.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_Subject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoCum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_SoLanLap);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.dgv_KetQua);
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_ChoVao1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_ChoVao);
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_Cum);
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_KhoangCach);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.txt_DangXet);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1260, 525);
            this.splitContainerControl1.SplitterPosition = 253;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.txt_Time);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lst_Subject);
            this.groupControl1.Controls.Add(this.txt_SoCum);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btn_ThucHien);
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(246, 626);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Phân tích cụm";
            // 
            // txt_Time
            // 
            this.txt_Time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_Time.EditValue = "1000";
            this.txt_Time.Location = new System.Drawing.Point(76, 391);
            this.txt_Time.Name = "txt_Time";
            this.txt_Time.Size = new System.Drawing.Size(96, 20);
            toolTipItem5.Text = "Nhập vào số cụm cần phân tích";
            superToolTip5.Items.Add(toolTipItem5);
            this.txt_Time.SuperTip = superToolTip5;
            this.txt_Time.TabIndex = 15;
            this.txt_Time.EditValueChanged += new System.EventHandler(this.txt_Time_EditValueChanged);
            this.txt_Time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Time_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl2.Location = new System.Drawing.Point(23, 394);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Thời gian:";
            // 
            // lst_Subject
            // 
            this.lst_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_Subject.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.lst_Subject.Appearance.Options.UseBackColor = true;
            this.lst_Subject.Location = new System.Drawing.Point(0, 38);
            this.lst_Subject.Name = "lst_Subject";
            this.lst_Subject.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_Subject.Size = new System.Drawing.Size(246, 309);
            this.lst_Subject.TabIndex = 13;
            this.lst_Subject.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lst_Subject_ItemCheck);
            // 
            // txt_SoCum
            // 
            this.txt_SoCum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_SoCum.Location = new System.Drawing.Point(76, 364);
            this.txt_SoCum.Name = "txt_SoCum";
            this.txt_SoCum.Size = new System.Drawing.Size(96, 20);
            toolTipItem4.Text = "Nhập vào số cụm cần phân tích";
            superToolTip4.Items.Add(toolTipItem4);
            this.txt_SoCum.SuperTip = superToolTip4;
            this.txt_SoCum.TabIndex = 2;
            this.txt_SoCum.EditValueChanged += new System.EventHandler(this.txt_SoCum_EditValueChanged);
            this.txt_SoCum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SoCum_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl1.Location = new System.Drawing.Point(33, 366);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Số cụm:";
            // 
            // btn_ThucHien
            // 
            this.btn_ThucHien.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ThucHien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThucHien.ImageOptions.Image")));
            this.btn_ThucHien.Location = new System.Drawing.Point(76, 454);
            this.btn_ThucHien.Name = "btn_ThucHien";
            this.btn_ThucHien.Size = new System.Drawing.Size(96, 33);
            toolTipItem1.Text = "Thực hiện thao tác phân tích dữ liệu với số cụm và tên các môn học được nhập từ p" +
    "hía trên.";
            superToolTip1.Items.Add(toolTipItem1);
            this.btn_ThucHien.SuperTip = superToolTip1;
            this.btn_ThucHien.TabIndex = 0;
            this.btn_ThucHien.Text = "Thực hiện";
            this.btn_ThucHien.Click += new System.EventHandler(this.btn_ThucHien_Click);
            // 
            // txt_SoLanLap
            // 
            this.txt_SoLanLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SoLanLap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLanLap.Appearance.Options.UseFont = true;
            this.txt_SoLanLap.Location = new System.Drawing.Point(913, 110);
            this.txt_SoLanLap.Name = "txt_SoLanLap";
            this.txt_SoLanLap.Size = new System.Drawing.Size(8, 16);
            this.txt_SoLanLap.TabIndex = 16;
            this.txt_SoLanLap.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(840, 110);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 16);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Số lần lặp:";
            // 
            // dgv_KetQua
            // 
            this.dgv_KetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_KetQua.Location = new System.Drawing.Point(19, 132);
            this.dgv_KetQua.MainView = this.KetQua;
            this.dgv_KetQua.Name = "dgv_KetQua";
            this.dgv_KetQua.Size = new System.Drawing.Size(980, 362);
            this.dgv_KetQua.TabIndex = 14;
            this.dgv_KetQua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.KetQua});
            // 
            // KetQua
            // 
            this.KetQua.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.KetQua.GridControl = this.dgv_KetQua;
            this.KetQua.Name = "KetQua";
            this.KetQua.OptionsBehavior.Editable = false;
            this.KetQua.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.KetQua.OptionsView.ShowGroupPanel = false;
            this.KetQua.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.KetQua_RowStyle);
            // 
            // txt_ChoVao1
            // 
            this.txt_ChoVao1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ChoVao1.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ChoVao1.Appearance.Options.UseFont = true;
            this.txt_ChoVao1.Location = new System.Drawing.Point(693, 55);
            this.txt_ChoVao1.Name = "txt_ChoVao1";
            this.txt_ChoVao1.Size = new System.Drawing.Size(68, 39);
            this.txt_ChoVao1.TabIndex = 13;
            this.txt_ChoVao1.Text = "--->";
            // 
            // txt_ChoVao
            // 
            this.txt_ChoVao.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ChoVao.Appearance.Options.UseFont = true;
            this.txt_ChoVao.Location = new System.Drawing.Point(174, 55);
            this.txt_ChoVao.Name = "txt_ChoVao";
            this.txt_ChoVao.Size = new System.Drawing.Size(68, 39);
            this.txt_ChoVao.TabIndex = 12;
            this.txt_ChoVao.Text = "--->";
            // 
            // txt_Cum
            // 
            this.txt_Cum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Cum.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cum.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_Cum.Appearance.Options.UseFont = true;
            this.txt_Cum.Appearance.Options.UseForeColor = true;
            this.txt_Cum.Location = new System.Drawing.Point(814, 50);
            this.txt_Cum.Name = "txt_Cum";
            this.txt_Cum.Size = new System.Drawing.Size(101, 39);
            this.txt_Cum.TabIndex = 9;
            this.txt_Cum.Text = "Cụm 1";
            // 
            // txt_KhoangCach
            // 
            this.txt_KhoangCach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_KhoangCach.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KhoangCach.Appearance.Options.UseFont = true;
            this.txt_KhoangCach.Location = new System.Drawing.Point(376, 33);
            this.txt_KhoangCach.Name = "txt_KhoangCach";
            this.txt_KhoangCach.Size = new System.Drawing.Size(4, 16);
            this.txt_KhoangCach.TabIndex = 5;
            this.txt_KhoangCach.Text = ".";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(419, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Khoảng cách";
            // 
            // txt_DangXet
            // 
            this.txt_DangXet.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DangXet.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_DangXet.Appearance.Options.UseFont = true;
            this.txt_DangXet.Appearance.Options.UseForeColor = true;
            this.txt_DangXet.Location = new System.Drawing.Point(63, 45);
            this.txt_DangXet.Name = "txt_DangXet";
            this.txt_DangXet.Size = new System.Drawing.Size(48, 45);
            this.txt_DangXet.TabIndex = 3;
            this.txt_DangXet.Text = "10";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_PhanCumChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frm_PhanCumChiTiet";
            this.Size = new System.Drawing.Size(1260, 525);
            this.Load += new System.EventHandler(this.frm_PhanCumChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Time.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_Subject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoCum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl lst_Subject;
        private DevExpress.XtraEditors.TextEdit txt_SoCum;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_ThucHien;
        private DevExpress.XtraEditors.LabelControl txt_DangXet;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl txt_KhoangCach;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl txt_Cum;
        private DevExpress.XtraEditors.LabelControl txt_ChoVao1;
        private DevExpress.XtraEditors.LabelControl txt_ChoVao;
        private DevExpress.XtraEditors.TextEdit txt_Time;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl dgv_KetQua;
        private DevExpress.XtraGrid.Views.Grid.GridView KetQua;
        private DevExpress.XtraEditors.LabelControl txt_SoLanLap;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
