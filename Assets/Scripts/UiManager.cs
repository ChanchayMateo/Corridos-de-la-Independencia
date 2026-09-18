using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TMP_Text guitarText;
    public TMP_Text timeText;
    public float startTime = 10;

    
    [SerializeField] private GameObject mexicoFlag; 

    private int totalGuitars = 0;
    private int collectedGuitars = 0;
    private float timeleft;

    private void Start()
    {
        GameObject[] guitars = GameObject.FindGameObjectsWithTag("Guitar");
        totalGuitars = guitars.Length;
        UpdateGuitarText();

        timeleft = startTime;

        
        if (mexicoFlag != null)
        {
            mexicoFlag.SetActive(false);
        }
    }

    public void GuitarCollected()
    {
        collectedGuitars++;

        
        if (collectedGuitars == totalGuitars)
        {
            if (mexicoFlag != null)
            {
                mexicoFlag.SetActive(true);
            }
        }

        UpdateGuitarText();
    }

    private void Update()
    {
        if (timeleft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        timeleft -= Time.deltaTime;
        timeleft = Mathf.Max(timeleft, 0);

        timeText.text = $"Tiempo: {timeleft.ToString("F2")}";
    }

    private void UpdateGuitarText()
    {
        guitarText.text = $"Guitarras: {collectedGuitars} / {totalGuitars}";
    }

    
public void LoadNextLevel()
{
    
    float timeTaken = startTime - timeleft;

    
    PlayerPrefs.SetFloat("LastLevelTime", timeTaken);
    PlayerPrefs.SetInt("LastLevelIndex", SceneManager.GetActiveScene().buildIndex);
    PlayerPrefs.Save();

    
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex + 1);
}

    
    private void OnEnable()
    {
        
        Guitar.OnGuitarCollected += GuitarCollected;
    }

    private void OnDisable()
    {
        
        Guitar.OnGuitarCollected -= GuitarCollected;
    }
}