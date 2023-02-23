using Proteomics;
using Proteomics.ProteolyticDigestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefulProteomicsDatabases;

namespace MS1_DataSimulator
{
    internal class DigestProteinsIntoPeptides
    {
        public readonly PeptideWithSetModifications[] Peptides;

        public DigestProteinsIntoPeptides(List<string> fullPathsToFastaFiles, int minPeptideLength = 7, int maxMissedCleavages = 0)
        {
            List<PeptideWithSetModifications> peptides = new();
            foreach (string path in fullPathsToFastaFiles)
            {
                if (File.Exists(path))
                {
                    List<Protein> proteins = ProteinDbLoader.LoadProteinFasta(path, true, DecoyType.Reverse, false, out var a,
                        ProteinDbLoader.UniprotAccessionRegex, ProteinDbLoader.UniprotFullNameRegex, ProteinDbLoader.UniprotNameRegex, ProteinDbLoader.UniprotGeneNameRegex,
                        ProteinDbLoader.UniprotOrganismRegex);
                    foreach (Protein protein in proteins)
                    {
                        peptides.AddRange(protein.Digest(new DigestionParams(minPeptideLength: minPeptideLength, maxMissedCleavages: maxMissedCleavages), new List<Modification>(), new List<Modification>()).ToList());
                    }
                } 
            }

            Peptides = peptides.ToArray();
            peptides.Clear();
        }
    }
}
