using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
	public class MACBT
	{
		public double Rb { get; set; }
		public double Rbt { get; set; }
		public double E { get; set; }
		public MACBT(string mac) { Set(mac); }
		private void Set(string mac)
		{
			switch (mac)
			{
				case "B15":
					Rb = 8.5;
					Rbt = 0.75;
					E = 24000;
					break;
				case "B20":
					Rb = 11.5;
					Rbt = 0.9;
					E = 27500;
					break;
				case "B22.5":
					Rb = 11.5;
					Rbt = 0.9;
					E = 28750;
					break;
				case "B25":
					Rb = 14.5;
					Rbt = 1.05;
					E = 30000;
					break;
				case "B30":
					Rb = 17;
					Rbt = 1.15;
					E = 32500;
					break;
				case "B35":
					Rb = 19.5;
					Rbt = 1.3;
					E = 34500;
					break;
				case "B40":
					Rb = 22;
					Rbt = 1.4;
					E = 36000;
					break;
				default:
					break;
			}
		}
	}
}
