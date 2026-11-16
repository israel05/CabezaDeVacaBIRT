using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MainMenuController : MonoBehaviour
{
    [SerializeField] private string firstScene = "Assets/Scenes/SampleScene.unity";

    private AsyncOperation sceneLoad;

    public void Play()
    {
        if (sceneLoad != null)
            return;

        int sceneIndex = SceneUtility.GetBuildIndexByScenePath(firstScene);
        if (sceneIndex < 0 || !Application.CanStreamedLevelBeLoaded(sceneIndex))
        {
            Debug.LogError($"La escena '{firstScene}' debe estar habilitada en la lista de escenas de la build.", this);
            return;
        }

        sceneLoad = SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
