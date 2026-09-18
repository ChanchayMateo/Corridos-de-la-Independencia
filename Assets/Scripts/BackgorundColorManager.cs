using UnityEngine;

public class BackgroundColorManager : MonoBehaviour
{
    public SpriteRenderer backgroundSprite; 
    public Transform player;                 
    public float transitionSpeed = 3f;      

    [System.Serializable]
    public struct Phase
    {
        public string phaseName; 
        public float minY;       
        public Color color;      
    }

    public Phase[] phases; 

    private Color targetColor;

    void Update()
    {
        if (player == null || backgroundSprite == null || phases.Length == 0) return;

        
        for (int i = phases.Length - 1; i >= 0; i--)
        {
            if (player.position.y >= phases[i].minY)
            {
                targetColor = phases[i].color;
                break;
            }
        }

        
        backgroundSprite.color = Color.Lerp(backgroundSprite.color, targetColor, Time.deltaTime * transitionSpeed);
    }
}