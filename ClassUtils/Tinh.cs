using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Linh.ClassUtils
{
    public class Tinh
    {
        public double Rb { get; set; } = 0.0; // Độ bền kéo của bê tông
        public double Rs { get; set; } = 0.0; // Độ bền kéo của thép chịu lực
        public double Rsc { get; set; } = 0.0; // Độ bền kéo của thép chịu cắt
        public double xiR { get; set; } = 0.583; // Hệ số giảm độ bền kéo của bê tông
        public double Nc { get; set; } = 0.0; // Lực nén tác dụng lên cột (kN)
        public double Mc { get; set; } = 0;
        public double Nd { get; set; } = 0.0; // Lực nén tác dụng lên cột (kN)
        public double Md { get; set; } = 0;
        public double b { get; set; } = 0.0; // Chiều rộng của cột (mm)
        public double h { get; set; } = 0.0; // Chiều cao của cột (mm)
        public double a { get; set; } = 0.0; // lopbaove (mm)
        public double As1 { get; set; } = 0.0; // Diện tích thép chịu lực 1 (mm2)
        public double As2 { get; set; } = 0.0; // Diện tích thép chịu lực 2 (mm2)

        public Tinh(double Rb, double Rs, double Rsc, double nc, double mc, double nd, double md, double h, double b, double a)
        {
            this.Rb = Rb;
            this.Rs = Rs;
            this.Rsc = Rsc;
            this.xiR = xiR;
            this.Nc = nc * 1000; // Lực nén tác dụng lên cột (kN)
            this.Mc = mc * 1000000; // Mô
            this.Nd = nd * 1000;
            this.Md = md * 1000000;
            this.b = b; // Chiều rộng mặc định của cột (mm)
            this.h = h; // Chiều cao của cột (mm)
            this.a = a;
            Run();
        }
        public void Run()
        {
            As1 = TinhAsCotChiuNenLechTam(Nc, Mc) / 100;
            As2 = TinhAsCotChiuNenLechTam(Nd, Md) / 100;
        }
        public double TinhAsCotChiuNenLechTam(double N, double M)
        {
            var a_1 = 0.9;
            double h0 = h - a;
            double alpha_nC = N / (Rb * b * h0);
            double delta = a_1 / h0;

            // alpha_m1 = (M + N(h0 - a')) / (Rb * b * h0^2)
            double alpha_m1 = (M + N * (h0 - a_1)) / (Rb * b * h0 * h0);

            if (alpha_nC <= xiR)
            {
                double term = alpha_m1 - alpha_nC * (1 - alpha_nC / 2.0);
                double As = (Rb * b * h0 / Rs) * term / (1 - delta);
                return As;
            }
            else
            {
                // Tính xi
                double xi = Math.Min(alpha_nC + xiR / 2.0, 1);
                double term = alpha_m1 - xi * (1 - xiR / 2.0);
                double As = (Rb * b * h0 / Rsc) * term / (1 - delta);
                return As;
            }
        }

    }
}
