using MassSpectrometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal static class CreateMzML
    {
        public static readonly MsDataFile? dataFile;
        public static readonly Scan scan;

        public static MsDataFile CreatemzML(Scan[] scans)
        {
            SourceFile sourceFile = new SourceFile(nativeIdFormat: "", massSpectrometerFileFormat: "mzML", checkSum: "", fileChecksumType: "",
                id: "", filePath: @"C:\Users\Edwin\Documents\GitHub\MS1_DataSimulator\TestingData\uniprot-download_true_format_fasta_query__28yeast_29_20AND_20_28mode-2023.03.16-18.38.12.39.fasta");
            
           // scan = scans.Spectrum();
            return dataFile;
        }
        public static MsDataFile CreateMZML(this Scan[] scans) //extension method
        {
            return CreatemzML(scans);
        }

       

    }
}
