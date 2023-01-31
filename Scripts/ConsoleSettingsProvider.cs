using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace InGameConsole
{
    class ConsoleSettingsProvider : SettingsProvider
    {
        private SerializedObject consoleSettings;

        private SerializedProperty defaultColor;
        private SerializedProperty defaultDarkerColor;
        private SerializedProperty infoColor;
        private SerializedProperty warningColor;
        private SerializedProperty errorColor;
        private SerializedProperty displayStacktrace;
        
        private ConsoleSettingsProvider(string path, SettingsScope scope = SettingsScope.User) : base(path, scope) {}

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            ConsoleData.instance.SaveAsset();
            consoleSettings = new SerializedObject(ConsoleData.instance);
            defaultColor = consoleSettings.FindProperty("DefaultColor");
            defaultDarkerColor = consoleSettings.FindProperty("DefaultDarkerColor");
            infoColor = consoleSettings.FindProperty("InfoColor");
            warningColor = consoleSettings.FindProperty("WarningColor");
            errorColor = consoleSettings.FindProperty("ErrorColor");
            displayStacktrace = consoleSettings.FindProperty("DisplayStacktrace");
        }

        public override void OnGUI(string searchContext)
        {
            using (CreateSettingsWindowGUIScope())
            {
                consoleSettings.Update();
                EditorGUI.BeginChangeCheck();

                if (GUILayout.Button("Set Default Values"))
                {
                    defaultColor.colorValue = new Color32(255, 255, 255, 255);
                    defaultDarkerColor.colorValue = new Color32(200, 200, 200, 255);
                    infoColor.colorValue = new Color32(161, 248, 255, 255);
                    warningColor.colorValue = new Color32(255, 217, 0, 255);
                    errorColor.colorValue = new Color32(232, 42, 42, 255);
                    displayStacktrace.boolValue = true;
                }
                
                EditorGUILayout.Space(10);

                defaultColor.colorValue = EditorGUILayout.ColorField(EditorGUIUtility.TrTextContent("Default Color"), defaultColor.colorValue);
                defaultDarkerColor.colorValue = EditorGUILayout.ColorField(EditorGUIUtility.TrTextContent("Default Darker Color"), defaultDarkerColor.colorValue);
                infoColor.colorValue = EditorGUILayout.ColorField(EditorGUIUtility.TrTextContent("Info Color"), infoColor.colorValue);
                warningColor.colorValue = EditorGUILayout.ColorField(EditorGUIUtility.TrTextContent("Warning Color"), warningColor.colorValue);
                errorColor.colorValue = EditorGUILayout.ColorField(EditorGUIUtility.TrTextContent("Error Color"), errorColor.colorValue);
                displayStacktrace.boolValue = EditorGUILayout.Toggle(EditorGUIUtility.TrTextContent("Display Stacktrace"), displayStacktrace.boolValue);

                if (!EditorGUI.EndChangeCheck()) return;
                
                consoleSettings.ApplyModifiedProperties();
                ConsoleData.instance.SaveAsset();
            }
        }

        [SettingsProvider]
        public static SettingsProvider CreateConsoleSettingsProvider()
        {
            var provider = new ConsoleSettingsProvider("Project/InGameConsole", SettingsScope.Project)
            {
                label = "In-game Console",
                keywords = new[] { "In-game", "Console", "Colors", "Default", "Info", "Warning", "Error", "Stacktrace" }
            };

            return provider;
        }
        
        private static IDisposable CreateSettingsWindowGUIScope()
        {
            var unityEditorAssembly = Assembly.GetAssembly(typeof(EditorWindow));
            var type = unityEditorAssembly.GetType("UnityEditor.SettingsWindow+GUIScope");
            return Activator.CreateInstance(type) as IDisposable;
        }
    }
}