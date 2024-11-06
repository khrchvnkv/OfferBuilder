using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor
{
    public static class MenuItemTool
    {
        [MenuItem("Shortcuts/Open Bootstrap Scene", false, 1)]
        public static void OpenBootstrapScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Bootstrap.unity", OpenSceneMode.Single);
        }
        
        [MenuItem("Shortcuts/Open Gameplay Scene", false, 1)]
        public static void OpenGameplayScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity", OpenSceneMode.Single);
        }
    }
}