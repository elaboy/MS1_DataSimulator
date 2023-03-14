// See https://aka.ms/new-console-template for more information

using MS1_DataSimulator;

List<string> fullPathToFastas = new List<string>() { @"E:\junk\Downloads_Edrive\yeast.fasta" };
BuildAChromatogram chromatogram = new (fullPathToFastas, 0.9);

Console.WriteLine("Hello, World!");
