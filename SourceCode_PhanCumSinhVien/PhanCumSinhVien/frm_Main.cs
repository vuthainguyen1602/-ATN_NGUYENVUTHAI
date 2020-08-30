using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.IO;
using DevExpress.XtraTab;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
namespace PhanCumSinhVien
{
    public partial class frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public event ThucHien_Click ThucHien_Click=null;
        public frm_Main()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Dark");  // Chọn giao diện mặc định   
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            lab_NgayThang.Caption = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            timer1.Enabled = true;

            btn_PhanTich.Enabled = btn_MenuPhanTich.Enabled = btn_XuatExcel.Enabled = btn_MenuXuat.Enabled=  btn_MenuPhanTichChiTiet.Enabled= false;
        }
        
        private void btn_MenuDocDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btn_MenuPhanTich_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhanCum frm = new frm_PhanCum();
            frm.Dock = DockStyle.Fill;
            frm.ThucHien_Click += new ThucHien_Click(ThucHien_Event);
            AddTabControl(frm, "Phân tích dữ liệu", "Chart_16x16.png");
            btn_XuatExcel.Enabled = true;
        }

        private void btn_DocDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        //------------------------------Thêm 1 tab mới-------------------------------------
        public void AddTabControl(UserControl userControl, string itemTabName, string icon)
        {
            bool isExists = false;
            foreach (XtraTabPage tabItem in TabMain.TabPages)// Kiểm tra tab mới đã được mở trước đó hay chưa
            {
                if (tabItem.Text == itemTabName)// Nếu đã mở trước đó thì chọn lại tab trước đó
                {
                    isExists = true;
                    TabMain.SelectedTabPage = tabItem;
                }
            }
            if (isExists == false)// Nếu chưa có thì tạo tab mới
            {
                AddTab addTab = new AddTab();
                addTab.AddTabControl(TabMain, itemTabName, icon, userControl);
            }
        }
        //--------------------------------------------------------------------------------
        
        public class path_src
        {
            public static string path = "";// Đường dẫn của file excel input
            public static DataTable dt;// Dùng lưu trữ dữ liệu từ file excel
            //public static string path_subject = "C:\\Users\\thainv\\Desktop\\DiemSV.xlsx";// Đường dân của file excel input
            public static string path_subject = @"Resource\DanhSachMonHoc.xlsx";
            public static DataTable dt_subject;// Dùng lưu trữ dữ liệu từ file excel
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            path_src.path = filePath;
            // Kiểm tra dường dẫn của file đã hợp lệ hay chưa
            if (frm_Main.path_src.path != "")
            {
                
                string extension = Path.GetExtension(filePath);
                
                int test_excel = 0;// Biến kiểm tra

                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        test_excel = 1;
                        break;
                    case ".xlt": //Excel 97-03
                        test_excel = 1;
                        break;
                    case ".xlsx": //Excel 07
                        test_excel = 1;
                        break;
                }

                if (test_excel == 1)
                {
                   
                    SplashScreenManager.ShowForm(typeof(frm_DangXuLy));

                    frm_Main.path_src.dt = ReadFromExcelfile(path_src.path, null);// Gán dt = dữ liệu đọc từ file excel
                    frm_Main.path_src.dt_subject = ReadFromExcelfile(path_src.path_subject, null);

                    if (frm_Main.path_src.dt == null)
                    {
                        SplashScreenManager.CloseForm();
                        return;
                    }

                    frm_DocDuLieu frm = new frm_DocDuLieu();
                    frm.Dock = DockStyle.Fill;
                    AddTabControl(frm, "Đọc dữ liệu", "LoadFrom_16x16.png");
                    SplashScreenManager.CloseForm();

                    btn_DocDuLieu.Enabled = btn_MenuDocDuLieu.Enabled = false;
                    btn_MenuPhanTich.Enabled = btn_PhanTich.Enabled = btn_MenuPhanTichChiTiet.Enabled = true;
                    
                }
                else
                {
                    XtraMessageBox.Show("Bạn vui lòng chọn tập tin có phần mở rộng là *.xls , *.xlsx , *.xlt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }       
        }

        private DataTable ReadFromExcelfile(string path, string sheetName)
        {
            // Khởi tạo data table
            DataTable dt = new DataTable();
            // Load file excel và các setting ban đầu
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    if (package.Workbook.Worksheets.Count < 1)
                    { // Log - Không có sheet nào tồn tại trong file excel của bạn 
                        return null;
                    }
                    // Lấy Sheet đầu tiện trong file Excel để truy vấn 
                    // Truyền vào name của Sheet để lấy ra sheet cần, 
                    //nếu name = null thì lấy sheet đầu tiên 
                    ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == sheetName) ?? package.Workbook.Worksheets.FirstOrDefault();
                    // Đọc tất cả các header
                    foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                    {
                        dt.Columns.Add(firstRowCell.Text);
                    }
                    // Đọc tất cả data bắt đầu từ row thứ 2
                    for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        // Lấy 1 row trong excel để truy vấn
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        // tạo 1 row trong data table
                        var newRow = dt.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Text;
                        }
                        dt.Rows.Add(newRow);
                    }
                }       
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi trong quá trình đọc dữ liệu. \nCó thể tập tin Excel đang mở hoặc dữ liệu chưa đúng định dạng, bạn vui lòng đóng tập tin Excel và thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return null;
            }
            return dt;
        }

        private void btn_Thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void TabMain_CloseButtonClick(object sender, EventArgs e)
        {
            if (TabMain.SelectedTabPage.Text == "Phân tích dữ liệu")
            {
                btn_XuatExcel.Enabled = false;
                btn_MenuXuat.Enabled = false;
            }

            TabMain.TabPages.RemoveAt(TabMain.SelectedTabPageIndex);

            TabMain.SelectedTabPageIndex = TabMain.TabPages.Count - 1;

            if (TabMain.TabPages.Count <= 1)
            {
                btn_PhanTich.Enabled = btn_XuatExcel.Enabled = btn_MenuPhanTich.Enabled = btn_MenuXuat.Enabled =  btn_MenuPhanTichChiTiet.Enabled = false;
                btn_DocDuLieu.Enabled = btn_MenuDocDuLieu.Enabled = true;
            }
        }

        private void btn_PhanTich_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhanCum frm = new frm_PhanCum();
            frm.Dock = DockStyle.Fill;
            frm.ThucHien_Click += new ThucHien_Click(ThucHien_Event);
            AddTabControl(frm, "Phân tích dữ liệu", "Chart_16x16.png");
            
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắn chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TabMain_ControlAdded_1(object sender, ControlEventArgs e)
        {
            TabMain.SelectedTabPageIndex = TabMain.TabPages.Count - 1;
        }

        private void btn_GioiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_GioiThieu frm = new frm_GioiThieu();
            frm.ShowDialog();
        }

        private void btn_TroGiup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_TroGiup frm = new frm_TroGiup();
            frm.Dock = DockStyle.Fill;
            AddTabControl(frm, "Trợ giúp", "About_16x16.png");
        }

        int hours = DateTime.Now.Hour, minute = DateTime.Now.Minute, second = DateTime.Now.Second;

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            lab_Date.Caption = hours.ToString() + " : " + minute.ToString() + ":" + second.ToString();
            if (second == 59)
            {
                second = -1;
                minute++;
            }
            if (minute == 59)
            {
                minute = -1;
                hours++;
            }
        }

        public void fnExportTableToExcel(DataTable dt_ThongSo)// Đưa dữ liệu từ các DataTable ra file excel mới
        {
            // Hiện hộp thoại chọn đường dẫn lưu file Excel
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (Phiên bản 2007 trở lên (.xlsx)|*.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);

                    SplashScreenManager.ShowForm(typeof(frm_DangXuLy));

                    int n = frm_PhanCum.KMEDOIDS_Cluster.NUM_Cluster;// Số lượng Sheet với nội dung chi tiết từng cụm có trong file excel mới = Số lượng cụm người dùng nhập vào 
                    DataTable[] dt_Array = new DataTable[n];   // Mảng 1 chiều DataTable 
                    DataRow  [] dr_Array = new DataRow[n];     // Mảng 1 chiều DataRow

                    for (int i = 0; i < n; i++)// Mỗi lần lặp tạo ra một DataTable mới, giới hạn lặp là số cụm người dùng nhập vào
                    {
                        dt_Array[i] = new DataTable("DataTable" + i);

                        dt_Array[i].Columns.Add(new DataColumn("f_masv"));// Cột mã sinh viên
                        dt_Array[i].Columns.Add(new DataColumn("f_lop" ));// Cột lớp
                        dt_Array[i].Columns.Add(new DataColumn("f_ho"  ));// Cột họ
                        dt_Array[i].Columns.Add(new DataColumn("f_ten" ));// Cột tên
                        dt_Array[i].Columns.Add(new DataColumn("f_dtb", typeof(Double)));// Cột này là Điểm trung bình nên phải là kiểu Double

                        for (int j = 0; j < frm_PhanCum.Subjects.COU_Subjects; j++)// Mỗi lần lặp tạo ra 1 cột môn học, giới hạn lặp là số môn học người dùng chọn khi check vào checkbox
                            dt_Array[i].Columns.Add(new DataColumn(frm_PhanCum.Subjects.ARR_Subjects[j], typeof(Double)));

                        dr_Array[i] = dt_Array[i].NewRow();
                    }
                    
                    for (int i = 0; i < frm_Main.path_src.dt.Rows.Count; i++)// Mỗi lần lặp thêm 1 sinh viên(1 dòng) vào DataTable với số điểm trung bình tương ứng thuộc cụm đó
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (frm_PhanCum.Students.EXCEL[i, 5] == frm_PhanCum.KMEDOIDS_Center.CENTER[j].ToString())// EXCEL[i, 5] là nơi lưu tâm cụm của sinh viên từ các môn học đã chọn. CENTER[j] lưu các giá trị tâm cụm
                            {
                                dr_Array[j] = dt_Array[j].NewRow();// Tạo ra 1 DataRow(1 dòng) mới

                                dr_Array[j]["f_masv"] = frm_PhanCum.Students.EXCEL[i, 0];
                                dr_Array[j]["f_lop" ] = frm_PhanCum.Students.EXCEL[i, 3];
                                dr_Array[j]["f_ho"  ] = frm_PhanCum.Students.EXCEL[i, 1];
                                dr_Array[j]["f_ten" ] = frm_PhanCum.Students.EXCEL[i, 2];
                                dr_Array[j]["f_dtb" ] = Math.Round(Convert.ToDouble(frm_PhanCum.Students.EXCEL[i, 4]), 2);

                                for (int k = 0; k < frm_PhanCum.Subjects.COU_Subjects; k++)// Mỗi lần lặp gán vào các ô từ ô thứ 6 trở đi là điểm của từng môn người dùng chọn ứng với sinh viên đó.
                                    dr_Array[j][frm_PhanCum.Subjects.ARR_Subjects[k]] = frm_PhanCum.Students.EXCEL[i, 6 + k];

                                dt_Array[j].Rows.Add(dr_Array[j]);
                            }
                        }
                    }

                    using (var package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Thông số các cụm");// Tạo Sheet chứa thông số các cụm

                        int colIndex = 1;
                        foreach (DataColumn dc in dt_ThongSo.Columns) //Tạo các Header
                        {
                            var cell = worksheet.Cells[1, colIndex];

                            var fill = cell.Style.Fill;               // Tạo định dạng
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(Color.Green);

                            for (int j = 1; j < frm_PhanCum.KMEDOIDS_Cluster.NUM_Cluster + 2; j++)
                            {
                                var cell_PC = worksheet.Cells[j, colIndex];
                                var border_PC = cell_PC.Style.Border;
                                border_PC.Bottom.Style = border_PC.Top.Style = border_PC.Left.Style = border_PC.Right.Style = ExcelBorderStyle.Thin;
                                cell_PC.Value = dc.ColumnName;
                            }
                            colIndex++;
                        }

                        //--------------------------------------Sheet đầu tiên--------------------------------------//
                        worksheet.Cells["A1"].LoadFromDataTable(dt_ThongSo, true, TableStyles.None);

                        //--------------------Xuat Bieu Do--------------------//
                        // Biểu đồ cột
                        OfficeOpenXml.Drawing.Chart.ExcelChart chart = (OfficeOpenXml.Drawing.Chart.ExcelChart)worksheet.Drawings.AddChart("chart_1", OfficeOpenXml.Drawing.Chart.eChartType.ColumnStacked);
                        chart.SetPosition(10, 300);
                        chart.Title.Text = "Biểu đồ cột";
                        chart.Title.Font.Bold = true;
                        chart.Title.Font.Size = 12;
                        chart.SetSize(500, 400);

                        var series = (ExcelChartSerie)(chart.Series.Add(worksheet.Cells[2, 3, dt_ThongSo.Rows.Count + 1, 3], worksheet.Cells[2, 1, dt_ThongSo.Rows.Count + 1, 1]));
                        series.Header = "Số PT";
                        chart.Legend.Add();
                        chart.Legend.Border.Width = 0;
                        chart.Legend.Font.Size = 12;
                        chart.Legend.Font.Bold = true;
                        chart.Legend.Position = eLegendPosition.Right;

                        // Biểu đồ tròn
                        OfficeOpenXml.Drawing.Chart.ExcelPieChart chart_pie = (OfficeOpenXml.Drawing.Chart.ExcelPieChart)worksheet.Drawings.AddChart("chart_2", OfficeOpenXml.Drawing.Chart.eChartType.Pie);
                        chart_pie.SetPosition(10, 810);
                        chart_pie.Title.Text = "Biểu đồ tròn";
                        chart_pie.Title.Font.Bold = true;
                        chart_pie.Title.Font.Size = 12;
                        chart_pie.SetSize(500, 400);

                        var series_pie = (ExcelPieChartSerie)(chart_pie.Series.Add(worksheet.Cells[2, 4, dt_ThongSo.Rows.Count + 1, 4], worksheet.Cells[2, 1, dt_ThongSo.Rows.Count + 1, 1]));
                        var pieSeries = (ExcelPieChartSerie)series_pie;
                        pieSeries.Explosion = 5;

                        //Format the labels
                        pieSeries.DataLabel.Font.Bold = true;
                        pieSeries.DataLabel.ShowValue = true;
                        pieSeries.DataLabel.ShowLeaderLines = true;

                        pieSeries.DataLabel.Position = eLabelPosition.OutEnd;

                        chart_pie.Legend.Add();
                        chart_pie.Legend.Border.Width = 0;
                        chart_pie.Legend.Font.Size = 12;
                        chart_pie.Legend.Font.Bold = true;
                        chart_pie.Legend.Position = eLegendPosition.Right;

                        //-------------------------------------Sheet thứ hai trở đi--------------------------------------//
                        ExcelWorksheet[] Sheet = new ExcelWorksheet[n];

                        for (int i = 0; i < n; i++)
                        {
                            Sheet[i] = package.Workbook.Worksheets.Add("Chi tiết cụm " + (i + 1).ToString());

                            int colIndex1 = 1;

                            foreach (DataColumn dc in dt_Array[i].Columns) //Creating Headings
                            {
                                var cell1 = Sheet[i].Cells[1, colIndex1];

                                var fill = cell1.Style.Fill;
                                fill.PatternType = ExcelFillStyle.Solid;
                                fill.BackgroundColor.SetColor(Color.Green);

                                for (int j = 1; j < frm_PhanCum.KMEDOIDS_Center.COU_Vector[i] + 2; j++)
                                {
                                    var cell_N = Sheet[i].Cells[j, colIndex1];
                                    var border = cell_N.Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    cell_N.Value = dc.ColumnName;
                                }

                                colIndex1++;
                            }

                            Sheet[i].Cells["A1"].LoadFromDataTable(dt_Array[i], true, TableStyles.None);
                        }

                        package.Save();
                        SplashScreenManager.CloseForm();

                        XtraMessageBox.Show("Tạo file excel thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        ProcessStartInfo pi = new ProcessStartInfo(exportFilePath);
                        Process.Start(pi);
                    }
                }
            }
        }

        void ThucHien_Event(object sender, ThucHien_Clicked e)  //Sự kiện nhấn nút thực hiện ở frm_PhanCum được thực hiện thì gán btn_XuatExcel.Enabled = true.
        {
            btn_XuatExcel.Enabled = true;
            btn_MenuXuat.Enabled = true;
        }

        private void btn_XuatExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm_PhanCum.KMEDOIDS_Result.dt_View_Clustering_Detail != null)
            {
                fnExportTableToExcel(frm_PhanCum.KMEDOIDS_Result.dt_Export_Excel);
                
            }
            else
            {
                XtraMessageBox.Show("Chưa có dữ liệu phân tích. !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_MenuTroGiup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_TroGiup frm = new frm_TroGiup();
            frm.Dock = DockStyle.Fill;
            AddTabControl(frm, "Trợ giúp", "About_16x16.png");
        }

        private void btn_MenuGioiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_GioiThieu frm = new frm_GioiThieu();
            frm.ShowDialog();
        }

        private void btn_MenuThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_MenuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm_PhanCum.KMEDOIDS_Result.dt_View_Clustering_Detail != null)
            {
                fnExportTableToExcel(frm_PhanCum.KMEDOIDS_Result.dt_Export_Excel);
            }
            else
            {
                XtraMessageBox.Show("Chưa có dữ liệu phân tích. !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_PhanTichChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhanCumChiTiet frm = new frm_PhanCumChiTiet();
            frm.Dock = DockStyle.Fill;
            AddTabControl(frm, "Phân tích chi tiết", "PieLabelsDataLabels_16x16.png");
        }

        private void btn_MenuPhanTichChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhanCumChiTiet frm = new frm_PhanCumChiTiet();
            frm.Dock = DockStyle.Fill;
            AddTabControl(frm, "Phân tích chi tiết", "PieLabelsDataLabels_16x16.png");
        }
    }
}