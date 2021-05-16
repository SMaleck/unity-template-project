using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Frameworks;
using Source.Frameworks.SavegameSystem;
using Source.Frameworks.SavegameSystem.Utility;
using Source.Frameworks.SavegameSystem.Editor.Constants;
using UnityEditor;

namespace Assets.Source.Frameworks.SavegameSystem.Editor.EditorMenus
{
    public static class SavegameSystemMenus
    {
        [MenuItem(MenuConstants.MenuRoot + "/OpenSettings", priority = MenuConstants.Priority1)]
        public static void OpenSettings()
        {
            
        }
    }
}
