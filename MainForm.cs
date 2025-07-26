using DATN_Linh.ClassUtils;
using MiniExcelLibs;
using MiniExcelLibs.OpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		public static List<Cot> Cots { get; set; } = new List<Cot>();
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
			var folderPath = "";
			string a="";
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Title = "Chọn file Excel";
				ofd.Multiselect = false;

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string filePath = ofd.FileName;
					txt_pathTT.Text = filePath;
					folderPath = Path.GetDirectoryName(filePath);
				}
			}
		}

		private void btn_nhap_Click(object sender, EventArgs e)
		{
			var tt = MiniExcel.Query<TietDien>(txt_PathTD.Text);
			var data = tt.Where(x => x.DesignType.Equals("Column")).GroupBy(x => x.Label).ToList();
			var config = new OpenXmlConfiguration()
			{
				FillMergedCells = true
			};
			var a = MiniExcel.Query(txt_pathTT.Text);
			var b = new XuLyEx(a.ToList());
			var c = b.Cots;
			int i = 1;
			foreach (var item in c)
			{
				string[] row = new string[]
				{   i.ToString(),
					item.Ten,
					item.MCC.Mx.ToString(),
					item.MCC.My.ToString(),
					item.MCC.N.ToString(),
					item.MCD.Mx.ToString(),
					item.MCD.My.ToString(),
					item.MCD.N.ToString(),
				};
				dgv_frames.Rows.Add(row);
				i++;
			}
			foreach (var cot in c)
			{
				var TTT = data.FirstOrDefault(x => x.Key.Equals(cot.Ten));
				cot.Rong = Split(TTT.FirstOrDefault().AnalysisSection, false);
				cot.Cao = Split(TTT.FirstOrDefault().AnalysisSection);
				Cots.Add(cot);
			}
		}
		private double Split(string data, bool c = true)
		{
			double result = 0;
			string[] kq = data.Split('X');
			if (c)
			{
				result = Convert.ToDouble(kq.LastOrDefault()) * 10;
			}
			else
			{
				result = Convert.ToDouble(kq.FirstOrDefault().Substring(1)) * 10;
			}
			return result;
		}
		private void btn_TT_Click(object sender, EventArgs e)
		{
			var a = Convert.ToDouble(txt_cover.Text);
			int i = 1;
			foreach (var cot in Cots)
			{
				var Result = new Tinh(MACBT.Rb,
					MACTHEPCHINH.Rs, MACTHEPCHINH.Rsc,
					cot.MCC.N, cot.MCC.Mx, cot.MCD.N, cot.MCD.My,
					cot.Cao, a);
				string[] beamresult = new string[]
				{
					i.ToString(),
					cot.Ten,
					Math.Round( Result.As1,4).ToString(),
					Math.Round( Result.As2,4).ToString(),
				};
				dataGridView2.Rows.Add(beamresult);
				i++;
			}
		}

		private void btn_td_Click(object sender, EventArgs e)
		{
			var folderPath = "";
			string a = "";
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Title = "Chọn file Excel";
				ofd.Multiselect = false;

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string filePath = ofd.FileName;
					txt_PathTD.Text = filePath;
					folderPath = Path.GetDirectoryName(filePath);
				}
			}
		}
	}
}
