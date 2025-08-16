using System;
using System.Globalization;

public static class HighSchoolSweethearts
{

    public static string DisplaySingleLine(string studentA, string studentB)
    {

        string content = $"{studentA} ♡ {studentB}"; 


        string leftPadding = new string(' ', 18);
        string rightPadding = new string(' ', 20);

        return leftPadding + content + rightPadding;
    }


    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA.Trim()}  +  {studentB.Trim()}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }


    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
    {
        var germanCulture = new CultureInfo("de-DE");
        return string.Format(germanCulture,
            "{0} and {1} have been dating since {2:d} - that's {3:N2} hours",
            studentA, studentB, start, hours);
    }
}
