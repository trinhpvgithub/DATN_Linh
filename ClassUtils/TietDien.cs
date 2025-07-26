using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DATN_Linh.ClassUtils
{
	public class TietDien
	{
		public string Story { get; set; }
		public string Label { get; set; }
		public string UniqueName { get; set; }
		public string DesignType { get; set; }
		public string Length { get; set; }
		public string AnalysisSection { get; set; }
		public string DesignSection { get; set; }
		public string MaxStationSpacing { get; set; }
		public string MinNumberStations { get; set; }

	}
}
