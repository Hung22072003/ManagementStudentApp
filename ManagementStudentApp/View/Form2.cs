using ManagementStudentApp.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementStudentApp.DTO;

namespace ManagementStudentApp
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(string LSH, string txt);
        public MyDel d { get; set; }
        public Form2()
        {
            InitializeComponent();
            setCBBLopSH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txbMSSV.Text == "")
            {
                MessageBox.Show("Vui long nhap MSSV");
            } else if (txbName.Text == "")
            {
                MessageBox.Show("Vui long nhap ten");
            } else if (cbbLopSH.Text == "")
            {
                MessageBox.Show("Vui long lua chon LopSH");
            } else if (dtpNgaysinh.Value == DateTime.Now)
            {
                MessageBox.Show("Vui long thay doi Ngaysinh");
            }else if (txbDTB.Text == "")
            {
                MessageBox.Show("Vui long nhap DTB");
            }else if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Vui long lua chon Gender");
            }

            if (txbMSSV.Text != "" && txbName.Text != "" && cbbLopSH.Text != "" && txbDTB.Text != "")
            {
                Student data = new Student { MSSV = txbMSSV.Text, Name = txbName.Text, LopSH = cbbLopSH.Text, Gender = (rbMale.Checked) ? true : false, DTB = Convert.ToDouble(txbDTB.Text.ToString()), Ngaysinh = dtpNgaysinh.Value, Anh = cbPicture.Checked, HocBa = cbHocBa.Checked, CCCD = cbCCCD.Checked };
                QLSVBLL bll = new QLSVBLL();
                bll.AddUpdate(data);
                d("All", "");
                this.Close();
            }
            
        }
        public void SetGUI(string str)
        {
            QLSVBLL bll = new QLSVBLL();
            Student st = bll.FindStudent(str);
            if (st != null)
            {
                txbMSSV.Text = st.MSSV;
                txbName.Text = st.Name;
                cbbLopSH.Text = st.LopSH;
                dtpNgaysinh.Value = st.Ngaysinh;
                txbDTB.Text = st.DTB.ToString();
                if (st.Gender == true) rbMale.Checked = true;
                else rbFemale.Checked = true;
                if (st.Anh == true) cbPicture.Checked = true;
                if (st.HocBa == true) cbHocBa.Checked = true;
                if (st.CCCD == true) cbCCCD.Checked = true;
                txbMSSV.ReadOnly = true;
            }
        }
        public void setCBBLopSH()
        {
            QLSVBLL bll = new QLSVBLL();
            cbbLopSH.Items.AddRange(bll.SetCBBLSH().ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
