using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Clock
{
    public partial class ChooseFont : Form
    {
        public ChooseFont()
        {
            InitializeComponent();
            LoadFonts();
        }
        void LoadFonts()
        {
            //1) Получаем список всех файлов в текущем каталоге, и сохраняем этот список в массив 'fonts'
            string[] fonts = Directory.EnumerateFiles(Directory.GetCurrentDirectory()).ToArray();
            //2) Поскольку в массиве хранятся полные пути к файлам, убираем пути, и оставляем только имена полученных файлов:
            for (int i = 0; i < fonts.Length; i++)
            {
                fonts[i] = fonts[i].Split('\\').Last();
            };
            //3) Загружаем весь массив файлов в ComboBox:
            comboBoxFonts.Items.AddRange(fonts);
        }
    }
}
