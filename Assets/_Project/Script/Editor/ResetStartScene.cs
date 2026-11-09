using UnityEditor;
using UnityEditor.SceneManagement;

public class ResetStartScene
{
    [MenuItem("Tools/Reset PlayMode Start Scene")]
    public static void Reset()
    {
        EditorSceneManager.playModeStartScene = null;
        UnityEngine.Debug.Log("PlayMode Start Scene berhasil di-reset ke normal!");
    }
}