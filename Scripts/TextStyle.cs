using System.Text.RegularExpressions;
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
        
        public static string FatalError(string text)
        {
            return Bold(Error(text));
        }
        
        public static string Bold(string text)
        {
            return $"<b>{text}</b>";
        }

        public static string Stacktrace(string text)
        {
            text = Default(text);
            
            const string typePattern = @"[(][a-z]+[)]";
            const string typeReplacement = "<color=#54c0ff>$&</color>";

            text = Regex.Replace(text, typePattern, typeReplacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            const string scriptPattern = @"[a-z/]*\.cs:[0-9]*";
            const string scriptReplacement = "<color=#54ff96>$&</color>";

            text = Regex.Replace(text, scriptPattern, scriptReplacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            const string classPatter = @"[a-z]*[+.]";
            const string classReplacement = "<color=#38c7b3>$&</color>";
            
            text = Regex.Replace(text, classPatter, classReplacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
            
            const string functionPatter = @"[a-z]*[ (]+[)]";
            const string functionReplacement = "<color=#1dc2d1>$&</color>";
            
            text = Regex.Replace(text, functionPatter, functionReplacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            return text;
        }
    }
}