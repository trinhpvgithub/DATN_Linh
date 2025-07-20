using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
	public class Cot
	{
		public double Rong { get; set; }
		public double Cao { get; set; }	
		public double Tang { get; set; }
		public double Ten { get; set; }
		public Matcat MCD { get; set; }
		public Matcat MCC { get; set; }
		public Cot(IGrouping<dynamic, dynamic> c)
		{
			//Tang = Convert.ToString();
			var sectionA = c.Where(x =>
			{
				string s = Convert.ToString(x.B);
				return s.Equals("0");
			});
			var sectionB = c.Where(x =>
			{
				string s = Convert.ToString(x.B);
				return !s.Equals("0");
			});
			MCC = new Matcat(sectionA.ToList());
			MCD = new Matcat(sectionB.ToList());
		}
	}
}
