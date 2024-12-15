using UnityEngine;
using UnityEngine.UI;
public class BuyScript : MonoBehaviour
{
    public Button button1; // Reference to Option 1 button
    public Button button2;
    public Button button3; // Reference to Option 1 button
    public Text materials;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        button1.onClick.AddListener(OnOption1Selected);
        button2.onClick.AddListener(OnOption2Selected);
        button3.onClick.AddListener(OnOption3Selected);
    }
    void OnOption1Selected()
    {
        int price1 = 20;
        if (price1 < PlayerPrefs.GetInt("materials", 0))
        {
            int num = PlayerPrefs.GetInt("materials", 0) - price1;
            PlayerPrefs.SetInt("materials", num);
            materials.text = num.ToString();
            int num1 = PlayerPrefs.GetInt("speed_multiplier", 0)+1;
            PlayerPrefs.SetFloat("speed_multiplier", num1);
        }
    }
    void OnOption2Selected()
    {
        int price2 = 50;
        if (price2 < PlayerPrefs.GetInt("materials", 0))
        {
            int num = PlayerPrefs.GetInt("materials", 0) - price2;
            PlayerPrefs.SetInt("materials", num);
            materials.text = num.ToString();
            float num1 = PlayerPrefs.GetFloat("fire_rate", 0)+0.1f;
            PlayerPrefs.SetFloat("fire_rate", num1);
        }
    }
    void OnOption3Selected()
    {
        int price3 = 30;
        if(price3 < PlayerPrefs.GetInt("materials", 0))
        {
            int num = PlayerPrefs.GetInt("materials", 0) - price3;
            PlayerPrefs.SetInt("materials", num);
            materials.text = num.ToString();
            num = PlayerPrefs.GetInt("add_hp", 0)+20;
            PlayerPrefs.SetFloat("add_hp", num);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
