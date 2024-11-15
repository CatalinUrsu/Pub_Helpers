using System.IO;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Helpers.Editor
{
[InitializeOnLoad]
public class SubmoduleAssetPostprocessor
{
    static SubmoduleAssetPostprocessor()
    {
        if (!FileAlreadyExist())
            EditorApplication.update += OnEditorUpdate;
    }

    static void OnEditorUpdate()
    {
        var packagePath = GetPackagePath();
        
        if (File.Exists(packagePath))
        {
            Debug.Log($"Importing {packagePath}");
            AssetDatabase.ImportPackage(packagePath, false);
            AssetDatabase.Refresh();
            EditorApplication.update -= OnEditorUpdate;
        }
        else
        {
            Debug.LogError($"Unity package file not found: {packagePath}");
        }
    }

    static string GetPackagePath()
    {
        var scriptPath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        var scriptName = scriptPath.Split('\\').Last();
        
        return scriptPath.Replace(scriptName, "FMOD for Unity.unitypackage");
    }

    static bool FileAlreadyExist() => Directory.Exists(Path.Combine(Application.dataPath, "Plugins", "FMOD"));
}
}