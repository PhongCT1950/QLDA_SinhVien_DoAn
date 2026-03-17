using BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
namespace QLDA_SinhVien.AdminGUI
{
    public partial class frmAdminDashBoard : Form
    {
        GiangVienService giangVienService = new GiangVienService();
        SinhVienService sinhVienService = new SinhVienService();
        DeTaiService deTaiService = new DeTaiService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        public frmAdminDashBoard()
        {
            InitializeComponent();
        }

        private void frmAdminDashBoard_Load(object sender, EventArgs e)
        {
            LoadListNienKhoa();
            LoadGiangVienThongKe();
            LoadTongGiangVien();
            try
            {
                string MANK = cmb_NienKhoa.SelectedValue.ToString();
                DataTable dtThongKe = deTaiService.GetDataThongKeDeTaiTheoNganh(MANK);

                VeBieuDoThongKe(MANK);
                VeBieuDoDeTai(dtThongKe);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load biểu đồ: " + ex.Message);
            }
        }
        public void LoadListNienKhoa()
        {
            DataTable NienKhoa = sinhVienService.getListNienKhoa();
            NienKhoa.Columns.Add("CotHienThi", typeof(string), "TENNK + ' - ' + NIENKHOA");

            cmb_NienKhoa.DisplayMember = "CotHienThi";
            cmb_NienKhoa.ValueMember = "MANK";
            cmb_NienKhoa.DataSource = NienKhoa;
        }

        public void LoadGiangVienThongKe()
        {
            string MANK = cmb_NienKhoa.SelectedValue.ToString();
            lbTongGVThamGia.Text = giangVienService.getDataSoGiangVienThamGia(MANK).ToString();
        }

        public void LoadTongGiangVien()
        {
            string TongGV = giangVienService.getDataTongGiangVien().ToString();
            lbTongGV.Text = $"Trên tổng số {TongGV} của toàn khoa";
        }

        private void VeBieuDoDeTai(DataTable dtThongKe)
        {
            Series series = loadGiaoDienChart();
            if (dtThongKe != null && dtThongKe.Rows.Count > 0)
            {
                foreach (DataRow row in dtThongKe.Rows)
                {
                    string tenNganh = row["TENNGANH"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuongDeTai"]);

                    string tenNganhVietTat = TaoTuVietTat(tenNganh);

                    int index = series.Points.AddXY(tenNganhVietTat, soLuong);

                    series.Points[index].ToolTip = $"{tenNganh}\nSố lượng: #VALY đề tài";
                }
            }
        }
        
        private void VeBieuDoThongKe(string MANK)
        {
            int svDaCoNhom = nhomSinhVienService.DemSinhVienDaCoNhom(MANK);
            int TongSoSV = nhomSinhVienService.DemTongSinhVien(MANK);
            int svChuaCoNhom = TongSoSV - svDaCoNhom;

            double tyLeDaCo = 0, tyLeChuaCo = 0;
            if (TongSoSV > 0)
            {
                tyLeDaCo = Math.Round(((double)svDaCoNhom / TongSoSV) * 100);
                tyLeChuaCo = Math.Round(100 - tyLeDaCo);
            }

            string labelDaCoNhom = $"Đã có\n{tyLeDaCo}%";
            string labelChuaCoNhom = $"Chưa có\n{tyLeChuaCo}%";

            Chart chartNhomHienTai = panelTyLeNhom.Controls.OfType<Chart>().FirstOrDefault();

            if (chartNhomHienTai == null)
            {
                Chart chartNhom = TaoBieuDoDoughnut(
                    labelDaCoNhom, svDaCoNhom, Color.FromArgb(46, 204, 113),
                    labelChuaCoNhom, svChuaCoNhom, Color.FromArgb(236, 240, 241),
                    "Đã có", "Chưa có"
                );
                panelTyLeNhom.Controls.Add(chartNhom);
            }
            else
            {
                Series seriesNhom = chartNhomHienTai.Series[0];
                seriesNhom.Points.Clear();

                int pt1 = seriesNhom.Points.AddXY(labelDaCoNhom, svDaCoNhom);
                seriesNhom.Points[pt1].Color = Color.FromArgb(46, 204, 113);
                seriesNhom.Points[pt1].Label = labelDaCoNhom;
                seriesNhom.Points[pt1].LegendText = "Đã có";

                int pt2 = seriesNhom.Points.AddXY(labelChuaCoNhom, svChuaCoNhom);
                seriesNhom.Points[pt2].Color = Color.FromArgb(236, 240, 241);
                seriesNhom.Points[pt2].Label = labelChuaCoNhom;
                seriesNhom.Points[pt2].LegendText = "Chưa có";
            }

            int doAnDaNop = deTaiService.DemDoAnDaNop(MANK);
            int TongDoAn = deTaiService.DemTongDoAn(MANK);
            int doAnChuaNop = TongDoAn - doAnDaNop;

            double tyLeDaNop = 0, tyLeChuaNop = 0;
            if (TongDoAn > 0)
            {
                tyLeDaNop = Math.Round(((double)doAnDaNop / TongDoAn) * 100);
                tyLeChuaNop = Math.Round(100 - tyLeDaNop);
            }

            string labelDaNop = $"Đã nộp\n{tyLeDaNop}%";
            string labelChuaNop = $"Chưa nộp\n{tyLeChuaNop}%";

            Chart chartDoAnHienTai = panelDoAnNop.Controls.OfType<Chart>().FirstOrDefault();

            if (chartDoAnHienTai == null)
            {
                Chart chartDoAn = TaoBieuDoDoughnut(
                    labelDaNop, doAnDaNop, Color.FromArgb(52, 152, 219),
                    labelChuaNop, doAnChuaNop, Color.FromArgb(236, 240, 241),
                    "Đã nộp", "Chưa nộp"
                );
                panelDoAnNop.Controls.Add(chartDoAn);
            }
            else
            {
                Series seriesDoAn = chartDoAnHienTai.Series[0];
                seriesDoAn.Points.Clear();

                int pt1 = seriesDoAn.Points.AddXY(labelDaNop, doAnDaNop);
                seriesDoAn.Points[pt1].Color = Color.FromArgb(52, 152, 219);
                seriesDoAn.Points[pt1].Label = labelDaNop;
                seriesDoAn.Points[pt1].LegendText = "Đã nộp";

                int pt2 = seriesDoAn.Points.AddXY(labelChuaNop, doAnChuaNop);
                seriesDoAn.Points[pt2].Color = Color.FromArgb(236, 240, 241);
                seriesDoAn.Points[pt2].Label = labelChuaNop;
                seriesDoAn.Points[pt2].LegendText = "Chưa nộp";
            }
        }

        private Chart TaoBieuDoDoughnut(string tenMuc1, int giaTri1, Color mau1, string tenMuc2, int giaTri2, Color mau2, string labelx1, string labelx2)
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.Transparent;

            area.Position.X = 60;
            area.Position.Y = 50;
            area.Position.Height = 100;
            area.Position.Width = 100;

            chart.ChartAreas.Add(area);

            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Segoe UI", 10F);
            chart.Legends.Add(legend);

            Series series = new Series("Data");
            series.ChartType = SeriesChartType.Doughnut;
            series.CustomProperties = "DoughnutRadius=60";
            series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Gray";

            int pt1 = series.Points.AddXY(tenMuc1, giaTri1);
            series.Points[pt1].Color = mau1;

            series.Points[pt1].Label = tenMuc1;
            series.Points[pt1].LabelForeColor = Color.Black;

            series.Points[pt1].LegendText = labelx1;

            int pt2 = series.Points.AddXY(tenMuc2, giaTri2);
            series.Points[pt2].Color = mau2;
            series.Points[pt2].Label = tenMuc2;
            series.Points[pt2].LabelForeColor = Color.Black;
            series.Points[pt2].LegendText = labelx2;

            chart.Series.Add(series);
            return chart;
        }

        private void cmb_NienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_NienKhoa.SelectedValue == null || cmb_NienKhoa.SelectedValue is DataRowView)
            {
                return;
            }

            string MANK = cmb_NienKhoa.SelectedValue.ToString();

            LoadGiangVienThongKe();

            DataTable dtThongKe = deTaiService.GetDataThongKeDeTaiTheoNganh(MANK);
            VeBieuDoDeTai(dtThongKe);

            VeBieuDoThongKe(MANK);
        }

        private string TaoTuVietTat(string tenDayDu)
        {
            if (string.IsNullOrWhiteSpace(tenDayDu)) return "";

            string[] words = tenDayDu.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string vietTat = "";
            foreach (string word in words)
            {
                vietTat += word[0].ToString().ToUpper();
            }
            return vietTat;
        }

        public Series loadGiaoDienChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Enabled = false;
            chartArea.AxisX.MajorTickMark.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisX.LabelStyle.ForeColor = Color.Gray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Số lượng");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(52, 152, 219);
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            series.LabelForeColor = Color.Black;
            series["PointWidth"] = "0.5";

            chart1.Series.Add(series);

            return series;
        }
    }
}
