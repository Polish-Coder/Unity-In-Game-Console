using UnityEditor;
using UnityEngine;

namespace InGameConsole
{
    [FilePath("ProjectSettings/InGameConsoleSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class ConsoleData : ScriptableSingleton<ConsoleData>
    {
        public Color32 DefaultColor = new(255, 255, 255, 255);
        public Color32 DefaultDarkerColor = new(200, 200, 200, 255);
        public Color32 InfoColor = new(161, 248, 255, 255);
        public Color32 WarningColor = new(255, 217, 0, 255);
        public Color32 ErrorColor = new(232, 42, 42, 255);

        public void SaveAsset()
        {
            Save(true);
        }
    }   
}