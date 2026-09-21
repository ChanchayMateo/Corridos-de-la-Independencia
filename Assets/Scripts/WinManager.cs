using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{ 
    public TMP_Text timeText;
    public GameObject mainWinPanel;   
    public GameObject surveyPanel;   
    

    private void Start()
    {
        
        float timeTaken = PlayerPrefs.GetFloat("LastLevelTime", 0f);
        
        if (timeText != null)
        {
            timeText.text = $"Tiempo: {timeTaken:F2} segundos";
        }

        
        if (surveyPanel != null)
        {
            surveyPanel.SetActive(false);
        }

        if (mainWinPanel != null)
        {
            mainWinPanel.SetActive(true);
        }
    }

    
    public void OpenSurvey()
    {
        if (surveyPanel != null)
        {
            surveyPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 1);
        SceneManager.LoadScene(lastLevelIndex);
    }


}