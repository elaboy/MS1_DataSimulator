using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal class GeneratePeak
    {
        public readonly double PeakArea;
        public readonly double PeakHeightAtCenter;
        public readonly double PeakWidth;
        public readonly int CenterScanNumber;
        public readonly double MinimumFraction;
        public readonly List<double> PeakHeights = new();
        public readonly List<int> RelativeScanPositions = new();
        
        public GeneratePeak(double peakArea, int centerScanNumber = 0, double minimumFraction = 0.1)
        {
            this.MinimumFraction= minimumFraction;
            this.CenterScanNumber = centerScanNumber;
            this.PeakArea = peakArea;
            this.PeakHeightAtCenter = Math.Sqrt((peakArea * 100)/(Math.Sqrt(2 * Math.PI)));
            this.PeakWidth = this.PeakHeightAtCenter / 100;

            double alpha = -1.0 / (2 * Math.Pow(this.PeakHeightAtCenter,2));
            double beta = (double)this.CenterScanNumber / Math.Pow(this.PeakHeightAtCenter, 2);
            double gamma = Math.Log(this.PeakHeightAtCenter - ((Math.Pow(this.CenterScanNumber, 2)) / (2 * Math.Pow(this.PeakWidth, 2))));

            List<(int, double)> scanAndHeight = new();
            for (int i = -100; i <= 100; i++)
            {
                //this is the gaussia formula
                scanAndHeight.Add((i, Math.Exp(alpha * Math.Pow((double)i, 2) + beta * (double)i + gamma)));
            }

            double peakSum = scanAndHeight.Select(s => s.Item2).Sum();
            foreach ((int,double) scan in scanAndHeight)
            {
                if (scan.Item2/peakSum > minimumFraction)
                {
                    RelativeScanPositions.Add(scan.Item1);
                    PeakHeights.Add(scan.Item2);
                }
            }
        }
    }
}
