using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DATN_Linh.ClassUtils
{
	public class Cot
	{
		public double Rong { get; set; }
		public double Cao { get; set; }	
		public string Tang { get; set; }
		public string Ten { get; set; }
		public Matcat MCD { get; set; }
		public Matcat MCC { get; set; }
		public Cot(IGrouping<dynamic, dynamic> c)
		{
			Tang = Convert.ToString(c.Select(x => x?.E).First());
			Ten = Convert.ToString(c.Select(x => x?.F).First());
			var sectionA = c.Where(x =>
			{
				string s = Convert.ToString(x.G);
				return s.Equals("C");
			});
			var sectionB = c.Where(x =>
			{
				string s = Convert.ToString(x.G);
				return s.Equals("D");
			});
			MCC = new Matcat(sectionA.ToList());
			MCD = new Matcat(sectionB.ToList());
		}
	}
}
