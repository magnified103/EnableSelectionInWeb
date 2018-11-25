namespace enableWebCopy
{
    public enum patchingType
    {
        ReplaceAllMatches,
        ReplaceFirstMatch,
        ReplaceFinalMatch,
    }
    public class ReplacePair
    {
        private string toReplace;
        private string replaceWith;
        public ReplacePair(string StringToReplace, string StringReplaceWith)
        {
            toReplace = StringToReplace;
            replaceWith = StringReplaceWith;
        }
        public ReplacePair()
        {
            toReplace = string.Empty;
            replaceWith = string.Empty;
        }
        public void SetStringToReplace(string StringToReplace)
        {
            toReplace = StringToReplace;
        }
        public void SetStringToReplaceWith(string StringToReplaceWith)
        {
            replaceWith = StringToReplaceWith;
        }
        public string GetStringToReplace()
        {
            return toReplace;
        }
        public string GetStringToReplaceWith()
        {
            return replaceWith;
        }
    }
}