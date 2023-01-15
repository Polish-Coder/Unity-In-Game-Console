namespace InGameConsole
{
    public static class TextStyle
    {
        public static string Default(string text)
        {
            return "<color=#FFFFFF>" + text + "</color>";
        }
        
        public static string DefaultDarker(string text)
        {
            return "<color=#cfcfcf>" + text + "</color>";
        }

        public static string Info(string text)
        {
            return "<color=#b3f9ff>" + text + "</color>";
        }
        
        public static string Warning(string text)
        {
            return "<color=#ffd900>" + text + "</color>";
        }
        
        public static string Error(string text)
        {
            return "<color=#e02f2f>" + text + "</color>";
        }
    }
}