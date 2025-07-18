using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
	public class MACTHEP
	{
		public double Rs { get; set; }
		public double Rsw { get; set; }
		public double Rsc { get; set; }
		public MACTHEP(string mac) { Set(mac); }
		public void Set(string mac)
		{
			switch (mac)
			{
				case "CB240-T":
					Rs = 210;
					Rsc = 210;
					Rsw = 170;
					break;
				case "CB300-V":
					Rs = 260;
					Rsc = 260;
					Rsw = 210;
					break;
				case "CB400-V":
					Rs = 350;
					Rsc = 350;
					Rsw = 280;
					break;
				case "CB500-V":
					Rs = 435;
					Rsc = 400;
					Rsw = 300;
					break;
				default:
					break;
			}
		}
	}
}
