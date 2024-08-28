using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ResourcesAudioFileEnumGenerator : AssetPostprocessor
    {
        private const string SoundFolderPath = "Assets/Resources/Sounds";
        
        // アセット変更時に呼び出されるメソッド
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            bool resourcesChanged = false;

            // Resourcesフォルダ内の音声ファイルの変更をチェック
            foreach (var asset in importedAssets)
            {
                if (IsSoundFile(asset))
                {
                    resourcesChanged = true;
                    break;
                }
            }

            foreach (var asset in deletedAssets)
            {
                if (IsSoundFile(asset))
                {
                    resourcesChanged = true;
                    break;
                }
            }

            foreach (var asset in movedAssets)
            {
                if (IsSoundFile(asset))
                {
                    resourcesChanged = true;
                    break;
                }
            }

            // 変更があった場合、Enumを生成する
            if (resourcesChanged)
            {
                GenerateSoundEnum();
            }
        }

        // サウンドファイルかどうかをチェック
        private static bool IsSoundFile(string path)
        {
            // pathにフォルダがなかったら生成
            if (!Directory.Exists(SoundFolderPath))
            {
                Directory.CreateDirectory(SoundFolderPath);
            }
            return path.StartsWith(SoundFolderPath) &&
                   (path.EndsWith(".wav") || path.EndsWith(".mp3") || path.EndsWith(".ogg"));
        }

        // Enumを生成するメソッド
        private static void GenerateSoundEnum()
        {
            // enumファイルのパス
            string currentDirectory = Directory.GetCurrentDirectory();
            string enumFilePath = Path.Combine(currentDirectory, "Packages", "com.ayagi.soundeffectsplayer", "Runtime", "ResourcesAudioFile.cs");
            StringBuilder enumBuilder = new StringBuilder();

            // Enumのヘッダ部分
            enumBuilder.AppendLine("public enum ResourcesAudioFile");
            enumBuilder.AppendLine("{");

            // サウンドファイルを取得してEnumを構築
            string[] soundFiles = Directory.GetFiles(SoundFolderPath, "*.*", SearchOption.AllDirectories);
            foreach (string soundFile in soundFiles)
            {
                if (IsSoundFile(soundFile))
                {
                    string fileName = Path.GetFileNameWithoutExtension(soundFile);
                    enumBuilder.AppendLine($"    {fileName},");
                }
            }

            // Enumのフッタ部分
            enumBuilder.AppendLine("}");

            // ファイルを書き込む
            File.WriteAllText(enumFilePath, enumBuilder.ToString());
            AssetDatabase.Refresh();
        }
    }
}