using enableWebCopy.ViewModels;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;

namespace enableWebCopy
{
    public class WebPatching
    {
        private patchingType PatchType = patchingType.ReplaceAllMatches;
        private List<ReplacePair> ReplacePairs = new List<ReplacePair>();
        bool PairsLoaded = false;
        private XmlDocument PatchDefinitionsDoc = new XmlDocument();
        public WebPatching(patchingType type, string XmlToLoad, Log OutputLogs, string PropertyName)
        {
            PatchType = type;
            LoadPairsViaXml(XmlToLoad, OutputLogs, PropertyName);
        }
        bool IsLoaded()
        {
            return PairsLoaded;
        }
        public void LoadPairsViaXml(string XmlToLoad, Log OutputLogs, string PropertyName)
        {
            PropertyInfo prop = OutputLogs.GetType().GetProperty(PropertyName);
            PatchDefinitionsDoc.LoadXml(XmlToLoad);
            switch (PatchType)
            {
                case patchingType.ReplaceAllMatches:
                    foreach (XmlNode patchNode in PatchDefinitionsDoc.DocumentElement.ChildNodes[0].ChildNodes)
                    {
                        ReplacePairs.Add(new ReplacePair(patchNode.ChildNodes[0].InnerText, patchNode.ChildNodes[1].InnerText));
                    }
                    break;
                case patchingType.ReplaceFirstMatch:
                    foreach (XmlNode patchNode in PatchDefinitionsDoc.DocumentElement.ChildNodes[1].ChildNodes)
                    {
                        ReplacePairs.Add(new ReplacePair(patchNode.ChildNodes[0].InnerText, patchNode.ChildNodes[1].InnerText));
                    }
                    break;
            }
            PairsLoaded = true;
            prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "Pre-defined patches were loaded\r\n");
        }
        public string PatchByReplaceAllMatches(string content, Log OutputLogs, string PropertyName)
        {
            PropertyInfo prop = OutputLogs.GetType().GetProperty(PropertyName);
            foreach (ReplacePair Pair in ReplacePairs)
            {
                List<int> PositionMatches = SearchingByTypes.AllIndexesOf(content, Pair.GetStringToReplace(), OutputLogs, PropertyName);
                foreach(int index in PositionMatches)
                {
                    content = content.Remove(index, Pair.GetStringToReplace().Length).Insert(index, Pair.GetStringToReplaceWith());
                    prop.SetValue(OutputLogs, prop.GetValue(OutputLogs) + "Patched " + Pair.GetStringToReplace().Length.ToString() + " bytes at offset 0x" + index.ToString("X") + "\r\n");
                }
            }
            return content;
        }
    }
}