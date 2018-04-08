using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLUserControls
{
    public partial class FrmSeleccionarAño : BasicForm
    {
        public int Año
        {
            get
            {
                return int.Parse(cbxAños.Text);
            }
        }

        public FrmSeleccionarAño(int AñosAtras = 20)
        {
            InitializeComponent();

            var fecha = DateTime.Now;
            for (int i = 0; i < AñosAtras; i++)
            {
                cbxAños.Properties.Items.Add(fecha.Year - i);
            }
            cbxAños.SelectedIndex = 0;
        }

        public void Accept()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
