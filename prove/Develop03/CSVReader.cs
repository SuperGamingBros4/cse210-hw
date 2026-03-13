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

        if (row is null || row.IsWhiteSpace())
        {
            return null;
        }

        // The list of values from the row
        List<string> values = new List<string>();

        // In a value surrounded by quotes
        bool inQuotes = false;
        // In a value NOT surrounded by quotes
        bool inValue = true;

        // Initially check if the first character in the row is a quotation mark
        if (row[0] == '"')
        {
            inValue = false;
            inQuotes = true;
        }

        int j = 0;
        // Go forward through the row and parse it
        for (int i = 0; i < row.Length; i++)
        {
            if (inValue)
            {
                if (row[i] == ',')
                {
                    // This is the end of the value
                    inValue = false;

                    // Capture the value and add it to the values list
                    string capture = row.Substring(j, i-j);
                    values.Add(capture);

                    // If this is the last character, add an extra value
                    if (i == row.Length - 1)
                    {
                        // The final character is a comma, so the last value is empty
                        values.Add("");
                    }
                    else
                    {
                        // Step the pointer back because it will be stepped forward again in
                        // the next iteration, so that it will catch the next value.
                        i--;
                    }
                }
                else if (i == row.Length - 1)
                {
                    // This is the end of the value
                    inValue = false;

                    // Capture the value and add it to the values list
                    string capture = row.Substring(j, i-j+1);
                    values.Add(capture);
                }
            }
            else if (inQuotes)
            {
                if (row[i] == ',')
                {
                    // Check if this is the end of the value surrounded by quotes
                    inQuotes = !IsEnd(row, i-1, j);
                    if (!inQuotes)
                    {
                        // Capture the value within the quotes and add it to the values list
                        string capture = row.Substring(j, i - j - 1);
                        values.Add(capture);
                    }
                }
                else if (i == row.Length - 1)
                {
                    // Check if this is the end of the value surrounded by quotes
                    inQuotes = !IsEnd(row, i, j);
                    if (!inQuotes)
                    {
                        // Capture the value within the quotes and add it to the values list
                        string capture = row.Substring(j, i - j);
                        values.Add(capture);
                    }
                }
            }
            else if (!inQuotes || !inValue)
            {
                if (row[i] == ',' && row[i+1] != '"')
                {
                    // Search for values not encapsulated by quotes
                    inValue = true;
                    j = i + 1;
                }
                else if (row[i] == '"')
                {
                    // Search for values encapsulated by quotes
                    inQuotes = true;
                    j = i + 1;
                }
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