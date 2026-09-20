using UnityEngine;

//Nueva mecánica añadida tarea MDA
public class Checkpoint : MonoBehaviour
{
    
    [SerializeField] private Color activeColor = Color.green;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            CheckpointManager.Instance.SetCheckpoint(transform.position);

            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = activeColor;
            }
        }
    }
}