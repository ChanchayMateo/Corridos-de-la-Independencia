using UnityEngine;

public class CameraFollow : MonoBehaviour


{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Follow")]
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    [Header("Camera Bounds")]
    [SerializeField] private Vector2 boundsmin;
    [SerializeField] private Vector2 boundsmax;

    private void Awake()
    {
        if (player == null)
        {   
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null){
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError
                (
                    "CameraFollow no se encuentra",
                    this
                );
            }
        }

    }

    private void LateUpdate()
    {
        if (player == null) //si no hay player no te sigue
            return;
        
        Vector3 targetPosition = player.position + offset;

        targetPosition.x = Mathf.Clamp(targetPosition.x, boundsmin.x, boundsmax.x); // 
        // me respetas los limites que hay en x los limites izquierdo y derecho en bounds max

        targetPosition.y = Mathf.Clamp(targetPosition.y, boundsmin.y, boundsmax.y);
        // me respetas los limites que hay en y los limites izquierdo y derecho en bounds max

        targetPosition.z = transform.position.z; // mantengo la posicion de la camara en z

        transform.position = Vector3.Lerp(transform.position, targetPosition, 1f - Mathf.Exp(-followSpeed * Time.deltaTime));
        //

        



    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}