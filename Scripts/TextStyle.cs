using UnityEngine;

namespace InGameConsole
{
    public static class TextStyle
    {
        public static string Default(string text)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(ConsoleData.instance.DefaultColor)}>{text}</color>";
        }
        
        public static string DefaultDarker(string text)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(ConsoleData.instance.DefaultDarkerColor)}>{text}</color>";
        }

        public static string Info(string text)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(ConsoleData.instance.InfoColor)}>{text}</color>";
        }
        
        public static string Warning(string text)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(ConsoleData.instance.WarningColor)}>{text}</color>";
        }
        
        public static string Error(string text)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(ConsoleData.instance.ErrorColor)}>{text}</color>";
        }
    }
}