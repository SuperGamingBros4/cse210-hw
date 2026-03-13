using System;
using System.Collections.Generic;

public class CSVReader
{
    private StreamReader _streamReader;

    public CSVReader(string path)
    {
        // The CSVReader is going to read a specific file, so we need a reader
        _streamReader = new StreamReader(path);
    }

    #nullable enable
    private static bool IsEnd(string row, int i, int j)
    {
        int count = 0;
        for (int k = i; k >= j-1; k--)
        {
            // Check if the current character is a quotation mark
            if (row[k] == '"')
            {
                // Count the number of continuous quotes from right to left
                count++;
            }
        }

        // The end of the value has been reached if count is even
        // when it reaches the starting quote
        return count % 2 == 0;
    }
    public List<string>? ReadRow()
    {
        // Read a row (a line) from the file with the reader
        string? row = _streamReader.ReadLine();

        if (row is null)
        {
            return null;
        }

        // The list of values from the row
        List<string> values = new List<string>();

        bool isInValue = false;
        int j = 0;
        for (int i = 0; i < row.Length; i++)
        {
            if (!isInValue && row[i] == '"')
            {
                // Search for the first quotation mark outside of a value to be the beginning. 
                isInValue = true;
                j = i + 1;
            }
            else if (isInValue && row[i] == ',')
            {
                isInValue = !IsEnd(row, i-1, j);
                if (!isInValue)
                {
                    string capture = row.Substring(j, i-j-1);
                    values.Add(capture);
                }
            }
            else if (isInValue && i >= row.Length - 1 && row[i] == '"')
            {
                string capture = row.Substring(j, i-j);
                values.Add(capture);
            }
        }

        // Fix value quotes
        for (int i = 0; i < values.Count; i++)
        {
            string value = values[i];
            values[i] = value.Replace("\"\"", "\"");
        }

        return values;
    }

    public List<List<string>> ReadAllRows()
    {
        // The list of rows with values
        List<List<string>> rowList = new List<List<string>>();

        // Loop until reaching the end of the file
        while (true)
        {
            // Read the next row
            List<string>? rowValues = ReadRow();
            
            if (rowValues is null)
            {
                // Stop reading if the next row does not exist
                break;
            }
            else
            {
                // Add the row to the list if it does exist
                rowList.Add(rowValues);
            }
        }
        
        return rowList;
    }
}