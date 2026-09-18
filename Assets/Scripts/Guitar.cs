using System;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    
    public static event Action OnGuitarCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            OnGuitarCollected?.Invoke();

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}