using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATN_Linh
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		public static MainForm view;
		private void button2_Click(object sender, EventArgs e)
		{
			view = new MainForm();
			view.ShowDialog();
			this.Close(); 
		}
	}
}
