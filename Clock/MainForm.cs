using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            if(cbShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Today.ToString("yyyy.MM.dd")}";
            }
        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            this.TransparencyKey = this.BackColor;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            cbShowDate.Visible = false;
            btnHideControls.Visible = false;
            labelTime.BackColor = Color.Coral;
            //C:\Users\Pro>taskkill /f /im clock.exe (грохнуть любой процесс)
        }

        private void labelTime_Click(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Empty;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowInTaskbar = true;
            cbShowDate.Visible = true;
            btnHideControls.Visible = true;
            labelTime.BackColor = Color.Coral;
        }
    }
}
