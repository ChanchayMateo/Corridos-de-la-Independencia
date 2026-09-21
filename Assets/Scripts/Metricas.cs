using UnityEngine;

public class Metricas : MonoBehaviour
{
    public static Metricas Instance { get; private set; }

    private float levelTimer = 0f;
    private int guitarsCollected = 0;
    private int deathCount = 0;
    private bool isLevelFinished = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        Guitar.OnGuitarCollected += TrackGuitar;
    }

    private void OnDisable()
    {
        Guitar.OnGuitarCollected -= TrackGuitar;
    }

    private void Update()
    {
        if (!isLevelFinished)
        {
            levelTimer += Time.deltaTime;
        }
    }

    private void TrackGuitar()
    {
        guitarsCollected++;
        Debug.Log($"Guitarras: {guitarsCollected} Tiempo: {levelTimer:F2}s");
    }

    
    public void RegisterDeath()
    {
        deathCount++;
        Debug.Log($"Muerte: {deathCount}");
    }

    public void FinishLevel()
    {
        isLevelFinished = true;
        float rate = (guitarsCollected / Mathf.Max(levelTimer, 1f)) * 60f;
        Debug.Log($"Total Guitarras: {guitarsCollected} Ritmo: {rate:F1} guitarras/min");
        Debug.Log($"Tiempo Final: {levelTimer:F2} segundos");
        Debug.Log($"Muertes Totales: {deathCount}");
    }
}