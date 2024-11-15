using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Helpers.Editor
{
[InitializeOnLoad]
public static class GitPackagesResolver
{
    static readonly string _manifestPath = "Packages/manifest.json";

    static readonly string _unitaskName = "com.cysharp.unitask";
    static readonly string _unitaskUrl = "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask";

    static readonly string _unirxName = "com.neuecc.unirx";
    static readonly string _unirxURL = "https://github.com/neuecc/UniRx.git?path=Assets/Plugins/UniRx/Scripts";

    static readonly string _assetsRelationsName = "com.innogames.asset-relations-viewer";
    static readonly string _assetsRelationsUrl = "https://github.com/innogames/asset-relations-viewer.git";

    static GitPackagesResolver()
    {
        if (!TryGetManifest(out var manifest)) return;
        if (!TryGetDependencies(manifest, out var dependencies)) return;

        AddPackageIfNotExists(manifest, dependencies, _unitaskName, _unitaskUrl);
        AddPackageIfNotExists(manifest, dependencies, _unirxName, _unirxURL);
        AddPackageIfNotExists(manifest, dependencies, _assetsRelationsName, _assetsRelationsUrl);

        AssetDatabase.Refresh();
    }

    static void AddPackageIfNotExists(JObject manifest, JObject dependencies, string package, string url)
    {
        if (dependencies.ContainsKey(package)) return;
        
        dependencies[package] = url;
        File.WriteAllText(_manifestPath, manifest.ToString());
        Debug.Log($"Added package {package} to manifest.json.");
    }

    static bool TryGetManifest(out JObject manifest)
    {
        manifest = null;
        if (!File.Exists(_manifestPath))
        {
            Debug.LogError("manifest.json not found at: " + _manifestPath);
            return false;
        }

        manifest = JObject.Parse(File.ReadAllText(_manifestPath));
        return true;
    }

    static bool TryGetDependencies(JObject manifest, out JObject dependencies)
    {
        dependencies = manifest["dependencies"] as JObject;
        if (dependencies == null)
        {
            Debug.LogError("Dependencies not found in manifest.json");
            return false;
        }

        return true;
    }
}
}