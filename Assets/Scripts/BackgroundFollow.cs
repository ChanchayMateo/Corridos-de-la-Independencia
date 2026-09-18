using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform camara;
    [Range(0f, 1f)]
    public float efectoParallax = 1f; 

    private Vector3 ultimaPosicionCamara;

    void Start()
    {
        if (camara == null) camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
    }

    void LateUpdate()
    {
        Vector3 desplazamiento = camara.position - ultimaPosicionCamara;
        transform.position += new Vector3(desplazamiento.x * efectoParallax, desplazamiento.y * efectoParallax, 0);
        ultimaPosicionCamara = camara.position;
    }
}