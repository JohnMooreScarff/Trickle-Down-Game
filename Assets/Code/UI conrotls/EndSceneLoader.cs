using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneLoader : MonoBehaviour
{
    public static EndSceneLoader Instance;
    public string winScene;
    public string looseScene;
    public string bankruptScene;

    private bool sceneLoaded = false;

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
    void Update()
    {
        if (!sceneLoaded)
        {
            if (ResourceData.QOL >= 100 && ResourceData.Pollution <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                LoadScene(winScene);
            }
            else if (ResourceData.Pollution >= 100)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                LoadScene(looseScene);
            }
            else if (ResourceData.Money <= -100000)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                LoadScene(bankruptScene);
            }
        }
    }
    private void LoadScene(string sceneName)
    {
        sceneLoaded = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
