using Easy.Common.Extensions;
using Proteomics.ProteolyticDigestion;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal class PeptideSpectrum
    {
        public readonly PeptideWithSetModifications peptideWithSetModifications;
        public readonly int[] chargeStates;
        public readonly double[] envelopeAbundances;
        public readonly double[] mzValues;
        public readonly double[] intensityValues;
        public readonly double totalSpectrumIntensity;
        public readonly string peptideSpectrumLabel;
        public readonly List<ChargeStateIsotopeCluster> ChargeStateClusters;

        public PeptideSpectrum(PeptideWithSetModifications peptideWithSetModifications, int[] chargeStates, double[] envelopeAbundances, double totalSpectrumIntensity = 1)
        {
            this.peptideWithSetModifications = peptideWithSetModifications;
            this.chargeStates = chargeStates;
            this.envelopeAbundances = envelopeAbundances;
            this.totalSpectrumIntensity = totalSpectrumIntensity;
            this.ChargeStateClusters = PopulateClusters();
            var mzAndIntensityValues = PopulateSpectrum();
            this.mzValues = mzAndIntensityValues.Item1.ToArray();
            this.intensityValues = mzAndIntensityValues.Item2.ToArray();
            this.peptideSpectrumLabel = GetLabel();
        }


        private List<ChargeStateIsotopeCluster> PopulateClusters() 
        {
            List<ChargeStateIsotopeCluster> chargeStateClusters = new();

            foreach (int chargeState in chargeStates)
            {
                IsotopicMassesAndNormalizedAbundances unchargedParentCluster = new IsotopicMassesAndNormalizedAbundances(peptideWithSetModifications);
                (double[], double[]) spectrum = unchargedParentCluster.ComputeMzAndIntensity(chargeState);
                chargeStateClusters.Add(new ChargeStateIsotopeCluster(spectrum,chargeState));
            }
            return chargeStateClusters;
        }
        private (List<double>,List<double>) PopulateSpectrum() 
        {
            List<double> mzs = new();
            List<double> intValues = new();

            for (int i = 0; i < ChargeStateClusters.Count; i++)
            {
                foreach (double mz in ChargeStateClusters[i].unitSpectrum.Item1)
                {
                    mzs.Add(mz);
                }
                foreach (double intensity in ChargeStateClusters[i].unitSpectrum.Item2)
                {
                    intValues.Add(intensity * envelopeAbundances[i]);
                }
            }

            double intensitySum = intValues.Sum();
            double intensityMultipler = totalSpectrumIntensity / intensitySum;

            for (int i = 0; i < intValues.Count; i++)
            {
                intValues[i] *= intensityMultipler;
            }

            return (mzs, intValues);
        }

        private string? GetLabel()
        {
            throw new NotImplementedException();
        }

    }
}
