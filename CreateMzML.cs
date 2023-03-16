using MassSpectrometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS1_DataSimulator
{
    internal static class CreateMzML
    {
        public static readonly MsDataFile dataFile;

        public static MsDataFile CreatemzML(Scan[] scans)
        {
            SourceFile sourceFile = new SourceFile(nativeIdFormat: "", massSpectrometerFileFormat: "", checkSum: "", fileChecksumType: "", id: "", filePath:"");
            MsDataFile dataFile = new(scans.Length, sourceFile);
            return dataFile;
        }
        public static MsDataFile CreateMZML(this Scan[] scans) //extension method
        {
            return CreatemzML(scans);
        }

       

    }
}
