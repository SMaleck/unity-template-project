using Source.Frameworks;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Persistence
{
    public static class SavegameTool
    {
        private static readonly string SavegamePath = Application.dataPath + "/../Savegame";

        [MenuItem(Constants.MenuRoot + "Savegame - Open Folder")]
        public static void OpenSavegameFolder()
        {
            EditorUtility.RevealInFinder(SavegamePath);
        }
    }
}
