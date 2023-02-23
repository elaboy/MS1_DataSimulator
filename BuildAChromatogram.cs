using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal class BuildAChromatogram
    {
        List<string> FullPathsToFastas;
        double TrainingFraction;

        public BuildAChromatogram(List<string> fullPathsToFastas, double trainingFraction)
        {
            this.FullPathsToFastas = fullPathsToFastas;
            this.TrainingFraction = trainingFraction;
            DigestProteinsIntoPeptides proteinDigest = new(fullPathsToFastas);
            SplitPeptides split = new((0, proteinDigest.Peptides.Length), trainingFraction);
            int maxNumScans = 100;
            Scan[] scans = new Scan[maxNumScans];

            Random rnd = new Random(42);

            int centerOfPeptide = 50;
            int[] chargeStates = new int[2] { 2, 3 };

            foreach (int trainingIndex in split.IndicesOfTrainingSet)
            {
                double peakArea = 10000 * rnd.NextDouble();
                GeneratePeak peak = new GeneratePeak(peakArea, centerOfPeptide);

                for (int i = 0; i < peak.RelativeScanPositions.Count; i++)
                {
                    if (peak.PeakHeights[i] > 0)
                    {
                        if(!((centerOfPeptide + peak.RelativeScanPositions[i]) > maxNumScans))
                        {
                            scans[centerOfPeptide + peak.RelativeScanPositions[i]].AddPeptideToScan(proteinDigest.Peptides[trainingIndex], peak.PeakHeights[i], chargeStates);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                centerOfPeptide++;
            }
        }

        
    }
}
