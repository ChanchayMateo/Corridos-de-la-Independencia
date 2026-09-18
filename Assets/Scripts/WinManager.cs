using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    
    public TMP_Text timeText;

   
    public string mainMenuSceneName = "MainMenu"; 

    private void Start()
    {
        
        float timeTaken = PlayerPrefs.GetFloat("LastLevelTime", 0f);
        
        if (timeText != null)
        {
            timeText.text = $"Tiempo: {timeTaken:F2} segundos";
        }
    }

    
    public void RestartLevel()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 1);
        SceneManager.LoadScene(lastLevelIndex);
    }

    
    public void GoToMainMenu()
    {
        
        SceneManager.LoadScene(mainMenuSceneName); 
    }
}