using UGF;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Persistence
{
    public static class PlayerPrefsTool
    {
        [MenuItem(Constants.MenuRoot + "PlayerPrefs - Clear")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
