using MassSpectrometry;
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
        public readonly List<PeptideWithSetModifications> peptides;
        public readonly List<double> peptidePeakAreas;
        public readonly List<int[]> peptideChargeStates;
        public readonly int scanNumber;
        public readonly string label;

        public Scan(List<PeptideWithSetModifications> peptides, List<double> peptidePeakAreas, List<int[]> peptideChargeStates, int scanNumber)
        {
            this.peptides = peptides;
            this.peptidePeakAreas = peptidePeakAreas;
            this.peptideChargeStates = peptideChargeStates;
            this.scanNumber = scanNumber;
            this.label = GetLabel();
        }

        public MzSpectrum ToMzSpectrum()
        {
            List<double> mzs = new();
            List<double> intensities = new();

            int maxNumberChargeStates = 3;
            int minChargeState = 1;
            int maxChargeState = 4;
            double minEnvelopeAbundance = 0.1;
            double totalSpectrumIntensity = 1;


            for (int i = 0; i < peptides.Count; i++)
            {
                PeptideSpectrum spectrum = new(peptides[i], maxNumberChargeStates, minChargeState, maxChargeState, minEnvelopeAbundance, totalSpectrumIntensity);
                mzs.AddRange(spectrum.mzValues);
                intensities.AddRange(spectrum.intensityValues);
            }
            intensities = intensities.SortLike(mzs.ToArray()).ToList();
            mzs.Sort();
            return new MzSpectrum(mzs.ToArray(), intensities.ToArray(), true);
        }

        public (double[], double[]) Spectrum()
        {
            List<double> mzs = new();
            List<double> intensities = new();

            int maxNumberChargeStates = 3;
            int minChargeState = 1;
            int maxChargeState = 4;
            double minEnvelopeAbundance = 0.1;
            double totalSpectrumIntensity = 1;


            for (int i = 0; i < peptides.Count; i++)
            {
                PeptideSpectrum spectrum = new(peptides[i], maxNumberChargeStates, minChargeState, maxChargeState, minEnvelopeAbundance, totalSpectrumIntensity);
                mzs.AddRange(spectrum.mzValues);
                intensities.AddRange(spectrum.intensityValues);
            }
            intensities = intensities.SortLike(mzs.ToArray()).ToList();
            mzs.Sort();
            return (mzs.ToArray(), intensities.ToArray());
        }
        public void AddPeptideToScan(PeptideWithSetModifications peptide, double abundance, int[] chargeStates)
        {
            peptides.Add(peptide);
            peptidePeakAreas.Add(abundance);
            peptideChargeStates.Add(chargeStates);
        }
        private static string GetLabel()
        {
            string label = string.Empty;
            return label;
        }        

    }
}
