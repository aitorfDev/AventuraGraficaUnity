
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    [Header("Scene Names (as in Build Settings)")]
    [SerializeField] private string sceneMenu = "MenuScene";
    [SerializeField] private string sceneMain = "MainScene";
    [SerializeField] private string sceneIntro = "IntroScene";
    [SerializeField] private string sceneFinalTime = "FinalTimeScene";
    [SerializeField] private string sceneFinalChilds = "FinalChildsScene";
    [SerializeField] private string sceneFinalGranny = "FinalGrannyScene";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Scene name is null or empty!");
            return;
        }

        // Devuelve true si:
        // La escena existe en los Build Settings(File > Build Settings... > Scenes In Build),

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' not found in Build Settings!");
        }
    }

    public void LoadMenu()
    {
        ChangeScene(sceneMenu);
    }

    public void LoadMain()
    {
        ChangeScene(sceneMain);
    }
    public void LoadIntro()
    {
        ChangeScene(sceneIntro);
    }
    public void LoadFinalTime()
    {
        ChangeScene(sceneFinalTime);
    }
    public void LoadFinalChilds()
    {
        ChangeScene(sceneFinalChilds);
    }
    public void LoadFinalGranny()
    {
        ChangeScene(sceneFinalGranny);
    }
}
