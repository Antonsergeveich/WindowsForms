﻿using System;
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
    public partial class AddAlarm : Form
    {
        public Alarm Alarm { get;set; }
        public AddAlarm()
        {
            InitializeComponent();
            Alarm = new Alarm();
            //labelFilename.SetBounds(labelFilename.Location.X,labelFilename.Location.Y, this.Width - 10, 25);
            labelFilename.MaximumSize = new Size(this.Width - 25, 75);
            openFileDialogSound.Filter = "MP-3 (*.mp3)|*.mp3|Flac (*.flac)|*.flac|All Audio|*.mp3;*.flac";
            openFileDialogSound.FilterIndex = 3;
            for(int i = 0; i < checkedListBoxWeek.Items.Count; i++)
            {
                checkedListBoxWeek.SetItemChecked(i, true);
            }
        }
        public AddAlarm(Alarm alarm):this()
        {
            Alarm = alarm;
            InitWindowFromAlarm();
        }
        void InitWindowFromAlarm()
        {
            if(Alarm.Date != DateTime.MinValue)this.dateTimePickerDate.Value = Alarm.Date;
            this.dateTimePickerTime.Value = Alarm.Time;
            this.labelFilename.Text = Alarm.Filename;
            for (int i = 0; i < Alarm.Weekdays.Length; i++)
            {
                checkedListBoxWeek.SetItemChecked(i, Alarm.Weekdays[i]);
                //(checkedListBoxWeek.Items[i] as CheckBox).Checked = Alarm.Weekdays[i];
            }
        }
        private void AddAlarm_Load(object sender, EventArgs e)
        {

        }
        void InitAlarm()
        {
            Alarm.Date = dateTimePickerDate.Enabled ? dateTimePickerDate.Value : DateTime.MinValue;
            Alarm.Time = dateTimePickerTime.Value;
            Alarm.Filename = labelFilename.Text;
            for (int i = 0; i < Alarm.Weekdays.Length; i++) Alarm.Weekdays[i] = false;
            for(int i = 0; i < checkedListBoxWeek.CheckedIndices.Count; i++) 
            {
                //свойство CheckedIndices - это коллекция, которая содержит индексы выбранных Галочек в checkedListBox.
                //Alarm.Weekdays[i] = (checkedListBoxWeek.Items[i] as CheckBox).Checked;
                Alarm.Weekdays[checkedListBoxWeek.CheckedIndices[i]] = true;
                Console.Write(checkedListBoxWeek.CheckedIndices[i] + "\t");
            }
            Console.WriteLine();
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            InitAlarm();
            if(Alarm.Filename == "Falename:")
            {
                MessageBox.Show("Выберите файл", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }
        }

        private void checkBoxExactDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDate.Enabled = ((CheckBox)sender).Checked;
        }

        private void labelFilenameTextChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            if(openFileDialogSound.ShowDialog() == DialogResult.OK)
            {
                Alarm.Filename = labelFilename.Text = openFileDialogSound.FileName;
            }
        }
    }
}
