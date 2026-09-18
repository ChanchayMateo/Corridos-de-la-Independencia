using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePages : MonoBehaviour
{
    public GameObject[] paginas;
    public GameObject botonRegresar; 
    
    private int paginaActual = 0;

    void Start()
    {
        ActualizarPaginas();
    }

    public void Siguiente()
    {
        paginaActual++;

        
        if (paginaActual >= paginas.Length)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ActualizarPaginas();
        }
    }

    public void Regresar()
    {
        if (paginaActual > 0)
        {
            paginaActual--;
            ActualizarPaginas();
        }
    }

    private void ActualizarPaginas()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(i == paginaActual);
        }

       
        if (botonRegresar != null)
        {
            botonRegresar.SetActive(paginaActual > 0);
        }
    }
}