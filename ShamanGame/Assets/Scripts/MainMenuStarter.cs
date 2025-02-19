using UnityEngine;

public class MainMenuStarter : MonoBehaviour
{
    public PauseMenu pauseMenu;
    void Start()
    {
        pauseMenu.Pause();
    }

}
