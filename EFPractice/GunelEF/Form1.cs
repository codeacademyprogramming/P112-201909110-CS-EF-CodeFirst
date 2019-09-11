using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GunelEF.DAL;
using GunelEF.Models;

namespace GunelEF
{
    public partial class Form1 : Form
    {
        ComputerContext comp;
        public Form1()
        {
            InitializeComponent();
            comp = new ComputerContext();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Computer com = new Computer();
            com.Marka = textBox1.Text;
            com.Model = textBox2.Text;
            com.RAM =Convert.ToInt32( textBox3.Text);

            comp.Computers.Add(com);
            comp.SaveChanges();


        }
    }
}
