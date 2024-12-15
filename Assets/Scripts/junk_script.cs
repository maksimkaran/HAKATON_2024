using UnityEngine;

public class junk_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            if (CompareTag("Screw"))
            {
                Material_Manager.instance.Add_Junk1();
                Destroy(gameObject);
            }
            if (CompareTag("Panel"))
            {
                Material_Manager.instance.Add_Junk2();
                Destroy(gameObject);
            }
            if (CompareTag("Foil"))
            {
                Material_Manager.instance.Add_Junk5();
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
