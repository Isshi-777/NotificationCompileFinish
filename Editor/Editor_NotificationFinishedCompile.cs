using UnityEditor;
using UnityEngine;

namespace Isshi777
{
    [InitializeOnLoad]
    public class Editor_NotificationFinishedCompile
    {
        private const string TexturePath = "Assets/NotificationCompileFinish/Image.png";
        private const string DefaultTexturePath = "Packages/com.isshi-777.notification-compile-finish/EditorResource/DefaultImage.png";

        static Editor_NotificationFinishedCompile()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorApplication.delayCall += () =>
                {
                    Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(TexturePath);
                    if (texture == null)
                    {
                        texture = AssetDatabase.LoadAssetAtPath<Texture>(DefaultTexturePath);
                    }

                    if (texture != null)
                    {
                        var assembly = typeof(EditorWindow).Assembly;
                        var type = assembly.GetType("UnityEditor.GameView");
                        EditorWindow.GetWindow(type).ShowNotification(new GUIContent(texture));
                    }
                };
            }
        }
    }
}
