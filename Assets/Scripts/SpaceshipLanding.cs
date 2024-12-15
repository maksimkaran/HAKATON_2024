using System;
using System.Security.Cryptography;

//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class SpaceshipLanding : MonoBehaviour
{
    public float gravityStrength = 9.81f;    // The strength of gravity
    public float gravityRadius = 10f;        // The radius where gravity starts to affect objects
    public float gravityStopRadius = 15f;    // The radius where gravity stops
    public Canvas optionsCanvas; // Reference to the Canvas (to disable when closing)
    public Button button1; // Reference to Option 1 button
    public Button button2; // Reference to Option 2 button// Reference to Option 3 button
    public BarFillAndDecrease scriptA;
    public Material_Manager materialA;
    public LayerMask affectedLayer;
    int FactoryPrice = 20;// The layer containing objects affected by gravity (spaceship, etc.)
    private void Start()
    {
        button1.onClick.AddListener(OnOption1Selected);
        button2.onClick.AddListener(OnOption2Selected);

    }
    // Option 1 button clicked
    void OnOption1Selected()
    {
        int price = 10;
        int junk = PlayerPrefs.GetInt("junk", 0);
        if (junk >= price)
        {
            junk = junk - price;
            PlayerPrefs.SetInt("junk", junk);
            materialA.Junk.text = junk.ToString();
            scriptA = GameObject.Find("proccesing_counter").GetComponent<BarFillAndDecrease>();
            scriptA.SetValue(price);
            scriptA.Junk_Procesing();
            Console.WriteLine("canvas button working");
            price += price;
            
        }
        CloseOptionsMenu();
    }

    // Option 2 button clicked
    void OnOption2Selected()
    {
        int junk = PlayerPrefs.GetInt("junk", 0);
        int prerada = junk;
        junk = 0;
        PlayerPrefs.SetInt("junk", junk);
        Console.WriteLine(junk);
        materialA.Junk.text = junk.ToString();
        scriptA.SetValueMat(prerada,true);
        scriptA.Junk_Procesing();

        //CloseOptionsMenu();
    }

  
    // Close the options menu (disable the canvas)
    void CloseOptionsMenu()
    {
        optionsCanvas.enabled = false;  // Hide the canvas when any option is selected
    }
    private void FixedUpdate()
    {
    
    Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, gravityStopRadius, affectedLayer);

        foreach (Collider2D obj in objectsInRange)
        {
            // Calculate the distance between the planet and the object
            Vector2 directionToPlanet = (Vector2)(transform.position) - (Vector2)obj.transform.position;
            float distance = directionToPlanet.magnitude;

            // If the object is within the gravity range, apply the gravitational pull
            if (distance <= gravityRadius)
            {
                ApplyGravity(obj, directionToPlanet, distance);
            }
        }
    }

    void ApplyGravity(Collider2D obj, Vector2 directionToPlanet, float distance)
    {
        // Normalize the direction and calculate the gravitational force
        Vector2 gravityForce = directionToPlanet.normalized * gravityStrength / (distance * distance); // Inverse square law

        // Apply the gravitational force to the object's Rigidbody2D
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(gravityForce);
        }
    }

    // Visualize gravity effect radius in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravityStopRadius);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("help");
        // Check if the other object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Step 1: Calculate the direction vector from the center of the circle to the object
            Vector2 directionToCenter = (Vector2)(other.transform.position - transform.position);

            // Step 2: Normalize the direction vector to get the normal
            Vector2 normal = directionToCenter.normalized;

            // Step 3: Calculate the angle needed to align the object's forward vector to the normal
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;

            // Step 4: Set the object's rotation to align with the normal
            other.transform.rotation = Quaternion.Euler(0, 0, angle+-90);
            
            // Call your function when the objects touch
            

            optionsCanvas.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        optionsCanvas.enabled = false;
        // Code to execute when another collider exits this trigger
        Debug.Log("Exited Trigger: " + other.gameObject.name);
    }
}
