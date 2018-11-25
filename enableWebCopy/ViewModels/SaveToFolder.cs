using System.IO;
using System.Reflection;

namespace enableWebCopy.ViewModels
{
    public static class SaveToFolder
    {
        public static void SaveFileToFolder(string Location, string FileName, string TextToWrite, Log OutputLogs, string PropertyName)
        {
            PropertyInfo prop = OutputLogs.GetType().GetProperty(PropertyName);
            File.WriteAllText(Location + "\\" + FileName, TextToWrite);
            prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "File was saved to \"" + Location + "\\" + FileName + "\"\r\n");
        }
    }
}
