using UnityEngine;

public class manager_socre : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("junk", 0);
        PlayerPrefs.SetInt("materials", 0);
        PlayerPrefs.SetFloat("speed", 0);
        PlayerPrefs.SetFloat("capacity", 0);
        PlayerPrefs.SetFloat("shooting", 0);
        PlayerPrefs.SetInt("zemlja_materials", 0);
        PlayerPrefs.SetFloat("fire_rate", 0.5f);
        PlayerPrefs.SetFloat("speed_multiplier", 4f);
        PlayerPrefs.SetInt("add_hp", 20);

    }
    private int counter = 20;  // Starting value of the integer
    public void SetValue(int newValue)
    {
        counter = newValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
