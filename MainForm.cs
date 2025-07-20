using DATN_Linh.ClassUtils;
using MiniExcelLibs;
using MiniExcelLibs.OpenXml;
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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		public static MACBT MACBT { get; set; }
		public static MACTHEP MACTHEPCHINH { get; set; }
		public static MACTHEP MACTHEPDAI { get; set; }
		private void cbb_macbtong_SelectedIndexChanged(object sender, EventArgs e)
		{
			var mac = cbb_macbtong.Text;
			MACBT = new MACBT(mac);
			txt_Rb.Text = MACBT.Rb.ToString();
			txt_Rbt.Text = MACBT.Rbt.ToString();
			txt_Rn.Text = MACBT.E.ToString();
		}

		private void cbb_chu_SelectedIndexChanged(object sender, EventArgs e)
		{
			var mac = cbb_chu.Text;
			MACTHEPCHINH = new MACTHEP(mac);
			txt_Rschu.Text = MACTHEPCHINH.Rs.ToString();
			txt_Rscchu.Text = MACTHEPCHINH.Rsc.ToString();
			txt_Rswchu.Text = MACTHEPCHINH.Rsw.ToString();
		}

		private void cbb_dai_SelectedIndexChanged(object sender, EventArgs e)
		{
			var mac = cbb_dai.Text;
			MACTHEPDAI = new MACTHEP(mac);
			txt_Rsdai.Text = MACTHEPDAI.Rs.ToString();
			txt_Rscdai.Text = MACTHEPDAI.Rsc.ToString();
			txt_Rswdai.Text = MACTHEPDAI.Rsw.ToString();
		}

		private void LoadData()
		{
			var b = MACBT = new MACBT("B25");
			txt_Rb.Text = b.Rb.ToString();
			txt_Rbt.Text = b.Rbt.ToString();
			txt_Rn.Text = b.E.ToString();
			var c = MACTHEPCHINH = new MACTHEP("CB300-V");
			txt_Rschu.Text = c.Rs.ToString();
			txt_Rscchu.Text = c.Rsc.ToString();
			txt_Rswchu.Text = c.Rsw.ToString();

			var d = MACTHEPDAI = new MACTHEP("CB240-T");
			txt_Rsdai.Text = d.Rs.ToString();
			txt_Rscdai.Text = d.Rsc.ToString();
			txt_Rswdai.Text = d.Rsw.ToString();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btn_pathTT_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Title = "Chọn file Excel";
				ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
				ofd.Multiselect = false;

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string filePath = ofd.FileName;
					txt_pathTT.Text = filePath;
				}
			}
		}

		private void btn_nhap_Click(object sender, EventArgs e)
		{
			var config = new OpenXmlConfiguration()
			{
				FillMergedCells = true
			};
			var a = MiniExcel.Query(txt_pathTT.Text, sheetName: "Cot", configuration: config);
			var b = new XuLyEx(a.ToList());
			var c = b.Cots;
			foreach (var item in c)
			{
				string[] row = new string[]
				{   "0",
					"0",
					item.MCC.Mx.ToString(),
					item.MCC.My.ToString(),
					item.MCC.N.ToString(),
					item.MCD.Mx.ToString(),
					item.MCD.My.ToString(),
					item.MCD.N.ToString(),
				};
				dgv_frames.Rows.Add(row);
			}
		}
	}
}
