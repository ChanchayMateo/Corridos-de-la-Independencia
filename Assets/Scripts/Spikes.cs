using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Metricas.Instance?.RegisterDeath();
            if (CheckpointManager.Instance != null)
            {
                CheckpointManager.Instance.RespawnPlayer(collision.gameObject);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
                );
            }
        }
    }
}