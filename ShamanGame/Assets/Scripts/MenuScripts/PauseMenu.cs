using UnityEditor.SearchService;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;

    private bool inMenu = false;
    private bool inOptions = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !inMenu)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && inMenu)
        {
            Resume();
        }
    }

    public void Pause()
    {
        if (inOptions)
        {
            optionsMenu.SetActive(false);
            inOptions = false;
        }

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        inMenu = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);

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
        //pauseMenu.SetActive(false);
        Debug.Log("Exit to Main Menu will be added later");

        Time.timeScale = 0f;
    }
    public void ExitDesktop()
    {
        //pauseMenu.SetActive(false);
        Debug.Log("Exit to Desktop will be added later");

        Time.timeScale = 0f;
    }

    


}
