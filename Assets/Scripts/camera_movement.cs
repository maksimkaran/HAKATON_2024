using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Vector2 minBound, maxBound; // Set min and max bounds in the Inspector
    public Transform player;       // Reference to the player's Transform
    public float smoothing = 2f;
    public float yOffset = 1f; // Smoothing factor for camera movement
    private void FixedUpdate()
    {

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, targetPosition, smoothing*Time.deltaTime);
    }

}
