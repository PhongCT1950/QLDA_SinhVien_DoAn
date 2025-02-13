using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using BusinessLogicLayer;
using DTO;

namespace QLDA_SinhVien
{
    public partial class Form1: Form
    {
        SinhVienService sinhVienService = new SinhVienService();
        public Form1()
        {
            InitializeComponent();
            Guna2BorderlessForm gunaBorderlessForm = new Guna2BorderlessForm();
            gunaBorderlessForm.ContainerControl = this;
        }

        public void LoadListSinhVien()
        {
            List<SinhVienDTO> sinhvien = sinhVienService.getSinhVien();

            foreach(var sv in sinhvien)
            {
                ListViewItem item = new ListViewItem(sv.MaSV);
                item.SubItems.Add(sv.TenSV);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                lsvt_SinhVien.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListSinhVien();
        }
    }
}
