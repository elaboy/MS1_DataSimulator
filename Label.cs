using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal class Label
    {
        public readonly string PeptideName;
        public readonly string Spectrum;
        public readonly string ClusterLabel;

        public Label(string peptideName, ChargeStateIsotopeCluster cluster, int maxSpectrumLength)
        {
            this.PeptideName = peptideName;
            this.Spectrum = GetPaddedSpectrum(cluster, maxSpectrumLength);
            this.clusterLabel = clusterLabel;
        }

        private string GetPaddedSpectrum(ChargeStateIsotopeCluster cluster, int maxLength)
        {
            List<double> spectrum = new();
            spectrum.AddRange(cluster.unitSpectrum.Item1.ToList());
            List<double> zeros = new(new double[maxLength - cluster.unitSpectrum.Item1.Length]);
            spectrum.AddRange(zeros);
            spectrum.AddRange(cluster.unitSpectrum.Item2.ToList());
            spectrum.AddRange(zeros);

            return String.Join('\t',spectrum.ToArray());
        }
    }
}
