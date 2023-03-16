// See https://aka.ms/new-console-template for more information

using MS1_DataSimulator;
using System;
using System.Collections.Generic;

List<string> fullPathToFastas = new List<string>() { @"C:\Users\Edwin\Documents\GitHub\MS1_DataSimulator\TestingData\uniprot - download_true_format_fasta_query__28yeast_29_20AND_20_28mode - 2023.03.16 - 18.38.12.39.fasta" };
BuildAChromatogram chromatogram = new (fullPathToFastas, 0.9);


Console.WriteLine("Hello, World!");
