using System;
using System.Collections.Generic;
using System.IO;

class CSVStateCensus
{
    private string csvFilePath;

    public CSVStateCensus(string filePath)
    {
        csvFilePath = filePath;
    }

    public IEnumerable<Dictionary<string, string>> LoadData()
    {
        using (StreamReader reader = new StreamReader(csvFilePath))
        {
            string[] headers = reader.ReadLine().Split(',');
            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(',');
                Dictionary<string, string> dataEntry = new Dictionary<string, string>();

                for (int i = 0; i < headers.Length; i++)
                {
                    dataEntry[headers[i]] = values[i];
                }

                yield return dataEntry;
            }
        }
    }
}

class StateCensusAnalyser
{
    private CSVStateCensus csvStateCensus;

    public StateCensusAnalyser(string filePath)
    {
        csvStateCensus = new CSVStateCensus(filePath);
    }

    public IEnumerable<Dictionary<string, string>> Analyze()
    {
        IEnumerable<Dictionary<string, string>> data = csvStateCensus.LoadData();

        // Perform analysis on the loaded data
        // You can implement your analysis logic here

        return data;  // Return the analyzed data
    }
}

class Program
{
    static void Main(string[] args)
    {
        string csvFilePath = "path_to_your_csv_file.csv"; // Replace with the actual path to your CSV file

        StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(csvFilePath);
        IEnumerable<Dictionary<string, string>> analyzedData = stateCensusAnalyser.Analyze();

        // Print or process the analyzed data as needed
    }
}
