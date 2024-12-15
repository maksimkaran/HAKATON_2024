using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float rate_of_fire = 2f;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance< 10)
        {
            timer += Time.deltaTime;
            if (timer >= rate_of_fire)
            {
                timer = 0;
                shoot();
            }
        }
 

    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
