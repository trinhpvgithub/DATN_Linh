using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
	public class XuLyEx
	{
		public List<Cot> Cots { get; set; } = new List<Cot>();
		public XuLyEx(List<dynamic> data)
		{
			var groupname = data.GroupBy(x => x.E);// group theo giá trị của cột A
			foreach (var group in groupname)
			{
				var groupbyF = group.Where(x =>
				  {
					  var dong = @"{ x.F}";
					  return dong.StartsWith("C");
				  }).GroupBy(x => x.F).ToList();
				foreach(var item in groupbyF)
				{
					if(item.Count()>0)
					{
						var cot = new Cot(item);
						Cots.Add(cot);
					}
				}
			}
		}
	}
}
