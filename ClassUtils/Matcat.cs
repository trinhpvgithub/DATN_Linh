using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
	public class Matcat
	{
		public double Mx { get; set; }
		public double My { get; set; }
		public double N { get; set; }

		public Matcat(List<dynamic> data)
		{
			var mx = data.FirstOrDefault(x =>
			{
				var mm = Convert.ToString(x.H);
				if (mm == null) return false;
				return mm.StartsWith("MX");
			});
			var my = data.FirstOrDefault(x =>
			{
				var mm = Convert.ToString(x.H);
				if (mm == null) return false;
				return mm.StartsWith("MY");
			});
			var n = data.FirstOrDefault(x =>
			{
				var mm = Convert.ToString(x.H);
				if (mm == null) return false;
				return mm.StartsWith("N");
			});
			List<double> mxmax = GetValue(mx);
			List<double> mymax = GetValue(my);
			List<double> nmax = GetValue(n);
			if (mxmax.Count > 0) Mx = mxmax.Max(x => Math.Abs(x));
			if (mymax.Count > 0) My = mymax.Max(x => Math.Abs(x));
			if (nmax.Count > 0) N = nmax.Max(x => Math.Abs(x));
		}

		public List<double> GetValue(dynamic dy)
		{
			var result = new List<double>();
			if (dy == null) return result;
			if (Convert.ToString(dy.O) != "-" && dy.O != null)
				result.Add(dy.O);
			if (Convert.ToString(dy.P) != "-" && dy.P != null)
				result.Add(dy.P);
			if (Convert.ToString(dy.Q) != "-" && dy.Q != null)
				result.Add(dy.Q);
			if (Convert.ToString(dy.R) != "-" && dy.R != null)
				result.Add(dy.R);
			if (Convert.ToString(dy.S) != "-" && dy.S != null)
				result.Add(dy.S);
			if (Convert.ToString(dy.T) != "-" && dy.T != null)
				result.Add(dy.T);
			if (Convert.ToString(dy.U) != "-" && dy.U != null)
				result.Add(dy.U);
			if (Convert.ToString(dy.V) != "-" && dy.V != null)
				result.Add(dy.V);
			return result;
		}
	}
}
