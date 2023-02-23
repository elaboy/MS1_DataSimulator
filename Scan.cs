using Proteomics.ProteolyticDigestion;
using SharpLearning.Containers.Arithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal class Scan
    {
        public readonly PeptideWithSetModifications[] peptides;
        public readonly double[] peptideAbundances;
        public readonly List<int[]> peptideChargeStates;
        public readonly List<double[]> envelopeAbundances;
        public readonly List<double> peptideTotalSpectrumIntensity;
        public readonly double[] mzValues;
        public readonly double[] intensityValues;
        public readonly int scanNumber;
        public readonly string label;

        public Scan(PeptideWithSetModifications[] peptides, double[] peptideAbundances, List<int[]> peptideChargeStates, int scanNumber)
        {
            this.peptides = peptides;
            this.peptideAbundances = peptideAbundances;
            this.peptideChargeStates = peptideChargeStates;
            this.scanNumber = scanNumber;

            (double[], double[]) spectrum = PopulateSpectrum();

            this.mzValues = spectrum.Item1;
            this.intensityValues = spectrum.Item2;
            this.label = GetLabel();
        }

        private (double[], double[]) PopulateSpectrum()
        {
            List<double> mzs = new();
            List<double> intensities = new();

            for (int i = 0; i < peptides.Length; i++)
            {
                PeptideSpectrum spectrum = new(peptides[i], peptideChargeStates[i], envelopeAbundances[i], peptideTotalSpectrumIntensity[i]);
                mzs.AddRange(spectrum.mzValues);
                intensities.AddRange(spectrum.intensityValues);
            }
            intensities = intensities.SortLike(mzs.ToArray()).ToList();
            mzs.Sort();
            return (mzs.ToArray(), intensities.ToArray());
        }
        private static string GetLabel()
        {
            string label = string.Empty;
            return label;
        }        
    }
}
