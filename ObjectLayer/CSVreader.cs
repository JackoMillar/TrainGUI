using System;
using System.Collections.Generic;
using System.IO;

public class CSVReader
{
    private string filePath;

    public CSVReader(string filePath)
    {
        this.filePath = filePath;
    }

    public List<string[]> ReadFile()
    {
        var header = true;
        List<string[]> data = new List<string[]>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!header)
                    {
                        string[] values = line.Split(',');
                        data.Add(values);
                    }
                    header = false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading CSV file: " + ex.Message);
        }

        return data;
    }
}

