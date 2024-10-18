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
        ColorDialog backgroundColorDialog;
        ColorDialog foregroundColorDialog;
        public MainForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Empty;
            backgroundColorDialog = new ColorDialog();
            foregroundColorDialog = new ColorDialog();
            SetVisibility(false);
            this.Location = new Point
                (
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width,
                50
                );
            this.Text += $"Location: {this.Location.X}x{this.Location.Y}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            if (cbShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Today.ToString("yyyy.MM.dd")}";
            }
            notifyIconSystemTray.Text = labelTime.Text;
        }
        private void SetVisibility(bool visible)
        {
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
            this.FormBorderStyle = visible ? FormBorderStyle.Sizable : FormBorderStyle.None;
            this.ShowInTaskbar = visible;
            cbShowDate.Visible = visible;
            btnHideControls.Visible = visible;
            labelTime.BackColor = visible ? Color.Empty : backgroundColorDialog.Color;
        }
        private void btnHideControls_Click(object sender, EventArgs e)
        {
            //SetVisibility(false);
            showControlsToolStripMenuItem.Checked = false;
            notifyIconSystemTray.ShowBalloonTip(3, "Важная информация", "Чтобы время поменять нужно кнопочку нажать", ToolTipIcon.Warning);
        }
        //C:\Users\Pro>taskkill /f /im clock.exe (грохнуть любой процесс)

        private void labelTime_Click(object sender, EventArgs e)
        {
            //SetVisibility(true);
            showControlsToolStripMenuItem.Checked = true;
        }

        private void notifyIconSystemTray_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIconSystemTray.Text = "Current time:\n" + labelTime.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = topmostToolStripMenuItem.Checked;
        }

        private void showControlsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility(((ToolStripMenuItem)sender).Checked);
        }

        private void showDateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            cbShowDate.Checked = ((ToolStripMenuItem)sender).Checked;
        }

        private void cbShowDate_CheckedChanged(object sender, EventArgs e)
        {
            showDateToolStripMenuItem.Checked = ((CheckBox)sender).Checked;
        }

        private void notifyIconSystemTray_DoubleClick(object sender, EventArgs e)
        {
            if (!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void colorTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (foregroundColorDialog.ShowDialog(this) == DialogResult.OK)
            {
                labelTime.ForeColor = foregroundColorDialog.Color;
            }
        }

        private void colorFontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                labelTime.BackColor = backgroundColorDialog.Color;
            }
        }
    }
}
