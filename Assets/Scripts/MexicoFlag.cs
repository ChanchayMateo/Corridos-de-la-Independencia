using UnityEngine;

public class MexicoFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiManager uiManager = Object.FindFirstObjectByType<UiManager>();
            
            if (uiManager != null)
            {
                uiManager.LoadNextLevel(); 
            }
            else
            {
                Debug.LogError("No se encontró la UI");
            }
        }
    }
}