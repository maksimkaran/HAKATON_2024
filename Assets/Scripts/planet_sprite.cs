using UnityEngine;

public class planet_sprite : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite newSprite;  // New sprite to assign

    void Start()
    {
        // Check if the target SpriteRenderer is assigned
        if (targetSpriteRenderer != null)
        {
            targetSpriteRenderer.sprite = newSprite;  // Set the sprite to the new one
        }
        else
        {
            Debug.LogError("Target SpriteRenderer is not assigned!");
        }
    }
}
