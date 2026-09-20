using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }

    private Vector3 UltimoCheckpoint;
    private bool hasCheckpoint = false;
    private Vector3 SpawnInicial;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SpawnInicial = player.transform.position;
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        UltimoCheckpoint= position;
        hasCheckpoint = true;
    }

    public void RespawnPlayer(GameObject player)
    {
        
        Vector3 targetPos = hasCheckpoint ? UltimoCheckpoint: SpawnInicial;
        player.transform.position = targetPos;

        
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.ChangeState(new GroundedState());
        }
    }
}