using System.IO;
using UnityEditor;
using UnityEngine;

namespace SavegameSystem.Editor.EditorMenus
{
    public static class EditorUtils
    {
        public static bool LoadOrCreateAsset<TAsset>(string filePath, out TAsset asset) where TAsset : ScriptableObject
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            if (!TryLoadAsset<TAsset>(filePath, out asset))
            {
                asset = ScriptableObject.CreateInstance<TAsset>();
                AssetDatabase.CreateAsset((ScriptableObject)asset, filePath);

                return false;
            }

            return true;
        }

        public static bool TryLoadAsset<TAsset>(string filePath, out TAsset asset) where TAsset : ScriptableObject
        {
            asset = (TAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TAsset));
            return asset != null;
        }

        public static void SaveAndRefresh()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
