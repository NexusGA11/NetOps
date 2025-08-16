using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[~*=\-^]+>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Matches(lines, "\".*password.*\"", RegexOptions.IgnoreCase).Count;
    }

    public string RemoveEndOfLineText(string text)
    {
        return Regex.Replace(text, @"end-of-line\d+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new List<string>();
        var passwordRegex = new Regex(@"password\w+", RegexOptions.IgnoreCase);

        foreach (var line in lines)
        {
            Match match = passwordRegex.Match(line);
            if (match.Success)
            {
                result.Add($"{match.Value}: {line}");
            }
            else
            {
                result.Add($"--------: {line}");
            }
        }
        return result.ToArray();
    }
}
