using UnityEditor;
using UnityEditor.Compilation;

namespace Editor
{
    public static class UpdateResourcesAudioFileMenu
    {
        [UnityEditor.MenuItem("Tools/Update Resources Audio File")]
        public static void UpdateResourcesAudioFile()
        {
            // Refresh the asset database
            AssetDatabase.SaveAssets();
            AssetDatabase.ImportAsset("Packages/com.ayagi.soundeffectsplayer/Runtime/Anchor.cs", ImportAssetOptions.ForceUpdate);
        }
    }
}