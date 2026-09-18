using System.Collections;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayBetweenLoops = 3f; 

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        StartCoroutine(PlayMusicRoutine());
    }

    private IEnumerator PlayMusicRoutine()
    {
        while (true)
        {
            audioSource.Play();

            
            yield return new WaitWhile(() => audioSource.isPlaying || Time.timeScale == 0);

           
            yield return new WaitForSeconds(delayBetweenLoops);
        }
    }
}