using System.Collections.Generic;

public class CSVReader
{
    
    private static bool IsEnd(string row, int i, int j)
    {
        int count = 0;
        for (int k = i; k >= j-1; k--)
        {
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

    public static List<string> ReadLine(string row)
    {
        List<string> list = new List<string>();

        bool isInValue = false;
        int j = 0;
        for (int i = 0; i < row.Length; i++)
        {
            if (!isInValue && row[i] == '"')
            {
                // Search for the first double quote outside of a value to
                // be the beginning. 
                isInValue = true;
                j = i + 1;
            }
            else if (isInValue && row[i] == ',')
            {
                isInValue = !IsEnd(row, i-1, j);
                if (!isInValue)
                {
                    string capture = row.Substring(j, i-j-1);
                    list.Add(capture);
                }
            }
            else if (isInValue && i >= row.Length - 1 && row[i] == '"')
            {
                string capture = row.Substring(j, i-j);
                list.Add(capture);
            }
        }

        // Fix value quotes
        for (int i = 0; i < list.Count; i++)
        {
            string value = list[i];
            list[i] = value.Replace("\"\"", "\"");
        }

        return list;
    }

    public static List<List<string>> ReadAllLines(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        List<List<string>> list = new List<List<string>>();

        foreach (string line in lines)
        {
            list.Add(ReadLine(line));
        }
        
        return list;
    }
}