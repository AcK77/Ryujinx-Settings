using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class IniParser
{
    private Dictionary<string, string> Values;

    public IniParser(string Path)
    {
        Values = File.ReadLines(Path)
        .Where(Line => (!String.IsNullOrWhiteSpace(Line) && !Line.StartsWith("#")))
        .Select(Line => Line.Split(new char[] { '=' }, 2, 0))
        .ToDictionary(Parts => Parts[0].Trim(), Parts => Parts.Length > 1 ? Parts[1].Trim() : null);
    }

    public string Value(string Name, string Value = null)
    {
        if (Values != null && Values.ContainsKey(Name))
        {
            return Values[Name];
        }
        return Value;
    }

    public void WriteFile(string Path, Dictionary<string, string> Ini)
    {
        StringBuilder Sb = new StringBuilder();

        foreach (KeyValuePair<string, string> Property in Ini)
            Sb.AppendLine($"{Property.Key} = {Property.Value}");

        File.WriteAllText(Path, Sb.ToString());
    }
}