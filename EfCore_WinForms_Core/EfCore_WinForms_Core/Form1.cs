using EfCore_WinForms_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfCore_WinForms_Core
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
        }
        DataGridView dgv = new DataGridView();

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new NorthwindContext();
            dgv.DataSource = con.Employees.Where(x => x.BirthDate.Value.Month > 5).OrderBy(x => x.Address).ToList();
        }
    }
}
