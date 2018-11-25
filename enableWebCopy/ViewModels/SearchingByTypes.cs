using System;
using System.Collections.Generic;
using System.Reflection;

namespace enableWebCopy.ViewModels
{
    public static class SearchingByTypes
    {
        public static List<int> AllIndexesOf(string String, string value, Log OutputLogs, string PropretyName)
        {
            PropertyInfo prop = OutputLogs.GetType().GetProperty(PropretyName);
            List<int> indexes = new List<int>();
            if (string.IsNullOrEmpty(value))
            {
                prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "Error: The string to find is empty.\r\n");
                return indexes;
            }
            if (String.IndexOf(value) == -1)
            {
                prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "Error: The string \"" + value + "\" can't be found.\r\n");
                return indexes;
            }
            for (int index = 0; ; index++)
            {
                index = String.IndexOf(value, index);
                if (index == -1)
                {
                    break;
                }
                indexes.Add(index);
                prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "Found match at offset 0x" + index.ToString("X") + "\r\n");
            }
            return indexes;
        }
    }
}
