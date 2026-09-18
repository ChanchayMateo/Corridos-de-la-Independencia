using UnityEngine;


public class CoinSpinner : MonoBehaviour
{
    [SerializeField] private float velocidadGiro = 180f;

    void Update()
    {
        transform.Rotate(0f, velocidadGiro * Time.deltaTime, 0f);
    }
}