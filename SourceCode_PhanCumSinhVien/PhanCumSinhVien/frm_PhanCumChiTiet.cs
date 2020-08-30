using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;

namespace PhanCumSinhVien
{
    public partial class frm_PhanCumChiTiet : UserControl
    {
        public frm_PhanCumChiTiet()
        {
            InitializeComponent();
        }


        public class Students
        {
            public static String[,] EXCEL;        // Mảng chứa danh sách sinh viên (thông tin cơ bản, điểm trung bình các môn được chọn của sinh viên đó, điểm các môn được chọn)
            public static Double[] Students_Group;// Mảng chứa các điểm trung bình khác nhau của sinh viên (độ đa dạng của điểm trung bình)
            public static int COU_Students_Group; // Đếm số lượng phần tử của mảng Students_Group 
            public static double max_mark;
            public static double min_mark;
        }

        public class Subjects
        {
            public static String[] SUBJECT;
            public static int COU_SUBJECT;
            public static String[] ARR_Subjects; // Mảng chứa các môn học đã chọn
            public static int COU_Subjects;      // Đếm số lượng phần tử của mảng chứa các môn học đã chọn
        }

        public class KMEDOIDS_Cluster
        {
            public static int NUM_Cluster;        // Số cụm người dùng nhập vào
        }

        public class KMEDOIDS_Center
        {
            public static Double[] CENTER;      // Mảng chứa các tâm cụm đại diện của từng cụm
            public static Double[] COU_Vector;  // Mảng chứa số phần tử của các cụm
        }

        public class KMEDOIDS_Result
        {
            public static DataTable dt_Export_Excel;   // DataTable dùng để chứa dữ liệu phân cụm xuất ra file excel
            public static DataRow dr_Export_Excel;

            public static DataTable dt_View_Clustering;// DataTable dùng để chứa dữ liệu phân cụm xuất ra màn hình hiển thị
            public static DataRow dr_View_Clustering;

            public static DataTable dt_View_Clustering_Detail; // DataTable dùng để chứa dữ liệu chi tiết của từng cụm xuất ra màn hình hiển thị
            public static DataRow dr_View_Clustering_Detail;
        }

        public class KMEDOIDS_Test
        {
            public static Int32[] location;
            public static int COU_location;
        }

        private void frm_PhanCumChiTiet_Load(object sender, EventArgs e)
        {
            txt_SoLanLap.Text = "0";
            txt_KhoangCach.Visible = txt_Cum.Visible = txt_ChoVao.Visible = txt_ChoVao1.Visible = txt_DangXet.Visible= false;
            Subjects.SUBJECT = new String[frm_Main.path_src.dt.Columns.Count];
            Subjects.COU_SUBJECT = 0;
            foreach (DataColumn Col in frm_Main.path_src.dt.Columns)
            {
                Subjects.SUBJECT[Subjects.COU_SUBJECT] = Col.ColumnName;
                Subjects.COU_SUBJECT++;
            }

            for (int i = 0; i < Subjects.COU_SUBJECT; i++)
            {
                for (int j = 0; j < frm_Main.path_src.dt_subject.Rows.Count; j++)
                {
                    DataRow dr_subject = frm_Main.path_src.dt_subject.Rows[j];
                    if (Subjects.SUBJECT[i] == dr_subject[1].ToString())
                    {
                        CheckedListBoxItem item = new CheckedListBoxItem();

                        item.Description = dr_subject[0].ToString();
                        item.Value = dr_subject[1].ToString();

                        lst_Subject.Items.Add(item);
                    }
                }
            }
        }

        public static Double[] Select_Center(int K)
        {
            int COU_Students_Group_Temp = 0;
            Double[] Cluster_Begin = new Double[KMEDOIDS_Cluster.NUM_Cluster];
            Double[] Students_Group_Temp = new Double[Students.COU_Students_Group];

            if (K == 1)
            {
                Cluster_Begin[0] = Students.min_mark;
                return Cluster_Begin;
            }
            else
            {
                Cluster_Begin[0] = Students.min_mark;
                Cluster_Begin[1] = Students.max_mark;
            }

            if (K != 2)
            {
                for (int i = 0; i < Students.COU_Students_Group; i++)
                {
                    if ((Students.Students_Group[i] != Students.max_mark) && (Students.Students_Group[i] != Students.min_mark))
                    {
                        Students_Group_Temp[COU_Students_Group_Temp] = Students.Students_Group[i];
                        COU_Students_Group_Temp++;
                    }
                }

                double division = Students.max_mark / (KMEDOIDS_Cluster.NUM_Cluster - 1);
                double min_distance;
                int location_min_distance;

                for (int i = KMEDOIDS_Cluster.NUM_Cluster - 1; i >= 2; i--)
                {
                    min_distance = 10.0;
                    location_min_distance = 0;

                    for (int j = 0; j < COU_Students_Group_Temp; j++)
                    {
                        if (Math.Sqrt(Math.Pow((Students_Group_Temp[j] - ((i - 1) * division)), 2)) < min_distance)
                        {
                            min_distance = Math.Sqrt(Math.Pow((Students_Group_Temp[j] - ((i - 1) * division)), 2));
                            location_min_distance = j;
                        }
                    }

                    Cluster_Begin[i] = Students_Group_Temp[location_min_distance];

                    for (int k = location_min_distance; k < COU_Students_Group_Temp - 1; k++)
                    {
                        Students_Group_Temp[k] = Students_Group_Temp[k + 1];
                    }

                    COU_Students_Group_Temp--;

                    //MessageBox.Show(" Cluster["+ i +"]: " + Cluster_Begin[i].ToString());
                }
            }
            return Cluster_Begin;
        }


        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();

        }

        int k = 0;
        private void btn_ThucHien_Click(object sender, EventArgs e)
        {
            
            if (XtraMessageBox.Show("Vì thời gian thực thi khá lâu, bạn nên chọn tập tin Excel ít dữ liệu để tiết kiệm thời gian.\nBạn có muốn tiếp tục ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            btn_ThucHien.Enabled = false;
            txt_ChoVao.Visible = false;
            txt_Cum.Visible = false;
            dgv_KetQua.DataSource = null;
            int time = Convert.ToInt32(txt_Time.Text);
            if (k != 0)
            {
                for (int i = KMEDOIDS_Cluster.NUM_Cluster - 1; i >= 0; i--)// Remove từng cột để xóa các cột chứa điểm của từng môn
                    KetQua.Columns.RemoveAt(i);
            }
           


            if (txt_SoCum.Text != "")
            {
                if (Convert.ToInt32(txt_SoCum.Text) <= 0)
                {
                    XtraMessageBox.Show("Bạn vui lòng nhập vào số tâm cụm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    k = 0;
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn vui lòng nhập vào số tâm cụm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                k = 0;
                return;
            }

            if (frm_Main.path_src.path == "")
            {
                XtraMessageBox.Show("Bạn vui lòng chọn đường dẫn tập tin Excel cần phân tích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                k = 0;
            }

            else
            {
                KMEDOIDS_Cluster.NUM_Cluster = Convert.ToInt32(txt_SoCum.Text); // Gán NUM_Cluster = số cụm người dùng nhập vào

                Subjects.ARR_Subjects = new String[Subjects.SUBJECT.Length]; // Tạo mảng chứa các môn học người dùng chọn. Hiện tại danh sách môn học có 9 môn 
                Subjects.COU_Subjects = 0;             // Đếm số môn học người dùng chọn


                DevExpress.XtraGrid.Columns.GridColumn[] Grid_Name = new DevExpress.XtraGrid.Columns.GridColumn[Subjects.SUBJECT.Length];

                for (int i = 0; i < lst_Subject.Items.Count; i++)
                {
                    if (lst_Subject.Items[i].CheckState == CheckState.Checked)
                    {
                        Subjects.ARR_Subjects[Subjects.COU_Subjects] = lst_Subject.Items[i].Value.ToString();
                        Subjects.COU_Subjects++;
                    }
                }

                if (Subjects.COU_Subjects == 0)
                {
                    XtraMessageBox.Show("Cần chọn ít nhất 1 môn học để phân cụm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    k = 0;
                    return;
                }
                // Tạo mảng EXCEL chứa thông tin cơ bản củasinh viên( 4 cột), Điểm trung bình của các môn đã chọn( 1 cột), Tâm cụm tương ứng( 1 cột), Điểm của các môn đã chọn( tùy vào số môn người dùng chọn)
                Students.EXCEL = new String[frm_Main.path_src.dt.Rows.Count, 6 + Subjects.COU_Subjects];

                Students.Students_Group = new Double[frm_Main.path_src.dt.Rows.Count];
                Students.COU_Students_Group = 0;

                double sum_mark = 0;// Tổng điểm của các môn mà người dùng đã chọn của sinh viên đó 

                DataRow dr0 = frm_Main.path_src.dt.Rows[0];

                try
                {
                    // Tạo ra điểm trung bình đầu tiên để ddauw vào mảng Students_Group
                    for (int j = 0; j < Subjects.COU_Subjects; j++)
                    {
                        sum_mark += Convert.ToDouble(dr0[Subjects.ARR_Subjects[j]]);
                    }

                    Students.EXCEL[0, 4] = (sum_mark / Subjects.COU_Subjects).ToString();

                    Students.Students_Group[0] = Convert.ToDouble(Students.EXCEL[0, 4]);
                    Students.COU_Students_Group++;

                    Students.min_mark = Students.Students_Group[0];
                    Students.max_mark = Students.Students_Group[0];

                    // Duyệt từng sinh viên và đưa vào mảng EXCEL tất cả các thông tin, nếu điểm trung bình các môn đã chọn của sinh viên đó chưa tồn tại trong bảng Students_Group thì thêm vào
                    for (int i = 0; i <= frm_Main.path_src.dt.Rows.Count - 1; i++)
                    {

                        int count = 0; // Biến kiểm tra trùng điểm trung bình
                        sum_mark = 0; // Biến tổng điểm các môn đã chọn của từng sinh viên
                        DataRow dr = frm_Main.path_src.dt.Rows[i];

                        Students.EXCEL[i, 0] = dr["f_masv"].ToString();
                        Students.EXCEL[i, 1] = dr["f_ho"].ToString();
                        Students.EXCEL[i, 2] = dr["f_ten"].ToString();
                        Students.EXCEL[i, 3] = dr["f_tenlop"].ToString();

                        for (int j = 0; j < Subjects.COU_Subjects; j++)  // Đưa điểm các môn đã chọn của sinh viên đó  vào mảng EXCEL
                        {
                            sum_mark += Convert.ToDouble(dr[Subjects.ARR_Subjects[j]]);
                            Students.EXCEL[i, 6 + j] = dr[Subjects.ARR_Subjects[j]].ToString();
                        }

                        Students.EXCEL[i, 4] = (sum_mark / Subjects.COU_Subjects).ToString();// Đưa điểm trung bình các môn đã chọn của sinh viên đó  vào mảng EXCEL

                        for (int j = 0; j < Students.COU_Students_Group; j++)// Duyệt mảng Students_Group xem điểm trung bình của sinh viên này đã có trong đó chưa
                        {
                            if ((Convert.ToDouble(Students.EXCEL[i, 4])) == (Students.Students_Group[j]))// Nếu đã có thì tăng biến kiểm tra
                            {
                                count++;
                            }
                        }
                        if (count == 0)// Nếu biến kiểm tra bằng 0 (tức là điểm mới chưa có trong mảng) thì thêm vào 
                        {
                            Students.Students_Group[Students.COU_Students_Group] = Convert.ToDouble(Students.EXCEL[i, 4]);

                            if (Students.Students_Group[Students.COU_Students_Group] > Students.max_mark)
                                Students.max_mark = Students.Students_Group[Students.COU_Students_Group];
                            if (Students.Students_Group[Students.COU_Students_Group] < Students.min_mark)
                                Students.min_mark = Students.Students_Group[Students.COU_Students_Group];

                            Students.COU_Students_Group++;
                        }
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi trong quá trình xử lý dữ liệu. \n_________________________________________________\n\n1. Có thể tập tin Excel có các tên cột không đúng định dạng. \n2. Có thể tập tin Excel không đầy đủ dữ liệu ở một số dòng. \n\nBạn vui lòng kiểm tra và thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;

                }


                if (Students.COU_Students_Group < KMEDOIDS_Cluster.NUM_Cluster)
                {
                    XtraMessageBox.Show("Số tâm cụm vượt quá số lượng giá trị khác nhau của dữ liệu !\n\t      ( Số tâm cụm phải '<' hoặc '=' " + Students.COU_Students_Group + " )", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    k = 0;
                    return;
                }

                Double Variance_MIN;   // Phương sai (độ lệch) bé nhất
                //Double DTB_Max = 0;// Điểm trung bình lớn nhất 
                //Double DTB_Min = 10;// Điểm trung bình bé nhất
                int stop = 0, lap = 0;// Biến kiểm tra dừng và biến đếm số lần lặp

                Double[] Variance = new Double[KMEDOIDS_Cluster.NUM_Cluster];        // Mảng phương sai (độ lệch)
                Double[] SUM_Vector = new Double[KMEDOIDS_Cluster.NUM_Cluster];      // Mảng tổng giá trị điểm trung bình của cụm
                KMEDOIDS_Center.COU_Vector = new Double[KMEDOIDS_Cluster.NUM_Cluster]; // Mảng số sinh viên của cụm

                Double[] CEN_Temp = new Double[KMEDOIDS_Cluster.NUM_Cluster];        // Mảng tâm cụm trước đó (vòng lặp kề trước của vòng lặp hiện tại)
                KMEDOIDS_Center.CENTER = new Double[KMEDOIDS_Cluster.NUM_Cluster];     // Mảng tâm cụm hiện tại (vòng lặp hiện tại)


                //========================================================BEGIN KMEDOIDS===================================================================

                KMEDOIDS_Center.CENTER = Select_Center(KMEDOIDS_Cluster.NUM_Cluster);

                DataTable dt_Center = new DataTable();

                DataRow dr_Center = dt_Center.NewRow();

                for (int i = 0; i < KMEDOIDS_Cluster.NUM_Cluster; i++)
                {

                    dt_Center.Columns.Add(new DataColumn("Cụm: " + (i + 1).ToString()));
                    dr_Center[i] = Math.Round(KMEDOIDS_Center.CENTER[i],2);
                }

                dt_Center.Rows.Add(dr_Center);

                dgv_KetQua.DataSource = dt_Center;

                KMEDOIDS_Test.location = new Int32[frm_Main.path_src.dt.Rows.Count];
                KMEDOIDS_Test.COU_location = 0;

                while (stop != 1)
                {
                    lap++;

                    for (int i = 0; i < KMEDOIDS_Cluster.NUM_Cluster; i++)
                    {
                        KMEDOIDS_Center.COU_Vector[i] = SUM_Vector[i] = 0;
                        CEN_Temp[i] = KMEDOIDS_Center.CENTER[i];// Cập nhật sanh sách tâm cụm trước 
                    }

                    //-------------------------Start Step 2--------------------------// 

                    for (int i = 0; i < frm_Main.path_src.dt.Rows.Count; i++)
                    {
                        txt_DangXet.Text = Math.Round(Convert.ToDouble(Students.EXCEL[i, 4]),2).ToString();
                        txt_DangXet.Visible = true;

                        //if (Convert.ToDouble(Students.EXCEL[i, 4]) > DTB_Max)
                        //    DTB_Max = Convert.ToDouble(Students.EXCEL[i, 4]);
                        //if (Convert.ToDouble(Students.EXCEL[i, 4]) < DTB_Min)
                        //    DTB_Min = Convert.ToDouble(Students.EXCEL[i, 4]);

                        for (int j = 0; j < KMEDOIDS_Cluster.NUM_Cluster; j++)
                        {
                            Variance[j] = 0;
                        }

                        //int MIN = 0;
                        int Location_MIN = 0;

                        Variance_MIN = Math.Sqrt(Math.Pow((Convert.ToDouble(Students.EXCEL[i, 4]) - KMEDOIDS_Center.CENTER[0]), 2));

                        Wait(time);
                        ////////////////////////////
                        txt_ChoVao.Visible = true;

                        Wait(time);
                        string kcc = "";
                        for (int j = 1; j < KMEDOIDS_Cluster.NUM_Cluster; j++)
                        {
                            Variance[j] = Math.Sqrt(Math.Pow((Convert.ToDouble(Students.EXCEL[i, 4]) - KMEDOIDS_Center.CENTER[j]), 2));
                            if (Variance[j] < Variance_MIN)
                            {
                                Variance_MIN = Variance[j];
                                Location_MIN = j;
                            }
                        }

                        //for (int j = 1; j <= KMEDOIDS_Cluster.NUM_Cluster; j++)
                        //{

                        //    kcc = kcc + (Students.EXCEL[i, 4].ToString() + "--> Cụm " + j.ToString() + " = "
                        //      + (Variance[j - 1] = Math.Sqrt(Math.Pow((Convert.ToDouble(Students.EXCEL[i, 4]) - KMEDOIDS_Center.CENTER[j - 1]), 2))).ToString()) + "\n";

                        //}
                        for (int j = 1; j <= KMEDOIDS_Cluster.NUM_Cluster; j++)
                        {

                            kcc = kcc + (Math.Round(Convert.ToDouble(Students.EXCEL[i, 4]),2).ToString() + "--> Cụm " + j.ToString() + " = "
                              + Math.Round( (Math.Abs(Convert.ToDouble(Students.EXCEL[i, 4]) - KMEDOIDS_Center.CENTER[j - 1])),2)).ToString() + "\n";

                        }

                        txt_KhoangCach.Text = kcc;
                        txt_KhoangCach.Visible = true;
                        Wait(time);
                        txt_ChoVao1.Visible = true;
                        Wait(time);

                        txt_Cum.Text = "Cụm " + (Location_MIN + 1).ToString();


                        txt_Cum.Visible = true;
                        Wait(time);
                        txt_KhoangCach.Visible = false;
                        txt_ChoVao.Visible = false;
                        txt_Cum.Visible = false;
                        txt_ChoVao1.Visible = false;
                        txt_DangXet.Visible = false;
                        Students.EXCEL[i, 5] = Convert.ToString(KMEDOIDS_Center.CENTER[Location_MIN]);

                        DataRow dr;

                        SUM_Vector[Location_MIN] += Convert.ToDouble(Students.EXCEL[i, 4]);
                        KMEDOIDS_Center.COU_Vector[Location_MIN]++;

                        dr = dt_Center.NewRow();
                        dr[Location_MIN] = Math.Round(Convert.ToDouble(Students.EXCEL[i, 4]),2);

                        dt_Center.Rows.Add(dr);


                    }


                    //-------------------------Start Step 3--------------------------//  

                    int CUO_CEN_Similar = 0;
                    DataRow dr_Center_Temp = dt_Center.NewRow();
                    for (int i = 0; i < KMEDOIDS_Cluster.NUM_Cluster; i++)
                    {
                        KMEDOIDS_Center.CENTER[i] = SUM_Vector[i] / KMEDOIDS_Center.COU_Vector[i];


                        dr_Center_Temp[i] = Math.Round(KMEDOIDS_Center.CENTER[i],2);


                        if (KMEDOIDS_Center.CENTER[i] == CEN_Temp[i])
                        {
                            CUO_CEN_Similar++;
                        }
                    }
                    dt_Center.Rows.Add(dr_Center_Temp);
                    txt_SoLanLap.Text = lap.ToString();
                    KMEDOIDS_Test.location[KMEDOIDS_Test.COU_location] = lap * (frm_Main.path_src.dt.Rows.Count + 1);
                    KMEDOIDS_Test.COU_location++;

                    if (CUO_CEN_Similar == KMEDOIDS_Cluster.NUM_Cluster)
                    {
                        stop = 1;
                    }

                    
                }

                //---------------------------------------------------END KMEDOIDS------------------------------------------------------------

            }

            k = 1;
           

        }

        private void txt_SoCum_EditValueChanged(object sender, EventArgs e)
        {
            Control crt = (Control)sender;
            if (crt.Text.Trim().Length > 0 && !Char.IsDigit(crt.Text[crt.Text.Length - 1]))
            {
                this.errorProvider1.SetError(crt, "Bạn phải nhập số!");
                k = 0;
            }
            else
            {
                this.errorProvider1.Clear();
                btn_ThucHien.Enabled = true;
            }
        }

      
        public void Hide_Button_ThucHien(object sender, EventArgs e)
        {
            btn_ThucHien.Enabled = true;
        }

        private void lst_Subject_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btn_ThucHien.Enabled = true;
        }

        private void KetQua_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.DarkRed;
                e.Appearance.ForeColor = Color.White;
            }

            for (int i = 0; i < KMEDOIDS_Test.COU_location; i++)
            {

                if (e.RowHandle == KMEDOIDS_Test.location[i])
                {
                    e.Appearance.BackColor = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void txt_Time_EditValueChanged(object sender, EventArgs e)
        {
            Control crt = (Control)sender;
            if (crt.Text.Trim().Length > 0 && !Char.IsDigit(crt.Text[crt.Text.Length - 1]))
            {
                this.errorProvider1.SetError(crt, "Bạn phải nhập số!");
                k = 0;
            }
            else
            {
                this.errorProvider1.Clear();
                btn_ThucHien.Enabled = true;
            }
        }


        public void KeyPressNumber(Control cont, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.errorProvider1.SetError(cont, "Bạn phải nhập dữ liệu là kiểu số");
                e.Handled = true;
            }
            else
                this.errorProvider1.Clear();
        }

        private void txt_SoCum_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressNumber(txt_SoCum, e);
        }

        private void txt_Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressNumber(txt_Time, e);
        }

    }    
}
