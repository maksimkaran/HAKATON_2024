using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public health_bar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

}
