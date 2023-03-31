using ManagementStudentApp.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementStudentApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCBBLopSH();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void setCBBLopSH()
        {
            QLSVBLL bll = new QLSVBLL();
            cbLopSH.Items.Add("All");
            cbLopSH.Items.AddRange(bll.SetCBBLSH().ToArray());
        }

        public void ShowDRV(string LSH, string txt)
        {
            QLSVBLL bll = new QLSVBLL();
            dataGridView1.DataSource = bll.GetStudentDRV(LSH, txt);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.d += new Form2.MyDel(ShowDRV);
            f.Show();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form2 f = new Form2();
                f.SetGUI(dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString());
                f.d += new Form2.MyDel(ShowDRV);
                f.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            QLSVBLL bll = new QLSVBLL();
            if (dataGridView1.SelectedRows.Count > 0 )
            {
                List<string> li = new List<string>();
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    li.Add(i.Cells["MSSV"].Value.ToString());
                }
                bll.DeleteStudentBll(li);
            }
            ShowDRV(cbLopSH.Text, txbSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            ShowDRV(cbLopSH.Text, txbSearch.Text);
        }
        
    }
}
