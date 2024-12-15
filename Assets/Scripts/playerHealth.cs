using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public health_bar healthBar;

    void Start()
    {
        maxHealth += PlayerPrefs.GetInt("add_hp", 20);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

}
