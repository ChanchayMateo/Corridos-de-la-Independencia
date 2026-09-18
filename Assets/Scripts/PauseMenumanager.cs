using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenumanager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";
    public GameObject pauseMenu;
    public GameObject pauseButton;
    
    [Header("Audio")]
    public AudioSource backgroundMusic; 

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (pauseButton != null) pauseButton.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(true);

        // Pausa la música
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(mainMenuSceneName); 
    }
}