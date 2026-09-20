using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }

    private Vector3 lastCheckpointPosition;
    private bool hasCheckpoint = false;
    private Vector3 initialSpawnPosition;

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
            initialSpawnPosition = player.transform.position;
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
        hasCheckpoint = true;
    }

    public void RespawnPlayer(GameObject player)
    {
        
        Vector3 targetPos = hasCheckpoint ? lastCheckpointPosition : initialSpawnPosition;
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