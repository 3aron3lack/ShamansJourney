using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;

    [SerializeField] string nextScene;
    [SerializeField] bool isMainMenu;

    private bool inMenu = false;
    private bool inOptions = false;

    private void Start()
    {
        if(!inMenu)
        {
            Cursor.visible = false;
        }
    }
    private void Update()
    {
        if(!isMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !inMenu)
            {
                Pause();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && inMenu)
            {
                Resume();
            }
        }
        
    }

    public void Pause()
    {
        if (inOptions)
        {
            optionsMenu.SetActive(false);
            inOptions = false;
        }
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        inMenu = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        inMenu = false;
    }
    public void OptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        inOptions = true;
        Time.timeScale = 0f;
    }
    public void ExitMainMenu()
    {        
        Debug.Log("Exit to Main Menu will be added later");
        SceneManager.LoadScene(sceneName: nextScene);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    


}
