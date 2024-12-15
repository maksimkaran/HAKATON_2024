using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;
public class Material_Manager : MonoBehaviour
{
    public static Material_Manager instance;
    public Text Junk;
    public Text Multiply;
    public Text Materials;
    
    int Junk_Count = 0;
    int Mat_Count = 0;
    private void Awake()
    {
        
        instance = this;   
    }
    void Start()
    {
        int Junk_Count = PlayerPrefs.GetInt("junk");
        int Mat_Count = PlayerPrefs.GetInt("zemlja_materials");
        Junk.text = Junk_Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Materials.text = PlayerPrefs.GetInt("zemlja_materials").ToString();
    }
    public void Add_Junk1()
    {
        int Junk_Count = PlayerPrefs.GetInt("junk", 0);
        PlayerPrefs.SetInt("junk", Junk_Count + 1);
        Junk_Count += 1;
        Junk.text = Junk_Count.ToString();
        Multiply.text = "+1";
        StartCoroutine(PerformActionAfterDelay(3f));

    }
    public void Add_Junk2()
    {
        int Junk_Count = PlayerPrefs.GetInt("junk", 0);
        PlayerPrefs.SetInt("junk", Junk_Count + 2);
        Junk_Count += 2;
        Junk.text = Junk_Count.ToString();
        Multiply.text = "+2";
        StartCoroutine(PerformActionAfterDelay(3f));
    }
    public void Add_Junk5()
    {
        int Junk_Count = PlayerPrefs.GetInt("junk", 0);
        PlayerPrefs.SetInt("junk", Junk_Count + 5);
        Junk_Count += 5;
        Junk.text = Junk_Count.ToString();
        Multiply.text = "+5";
        StartCoroutine(PerformActionAfterDelay(3f));
    }
    public void Add_Materials(int availabel_mats)
    {
        int Mat_Count = PlayerPrefs.GetInt("materials", 0);
        PlayerPrefs.SetInt("materials", Mat_Count + availabel_mats);
        Materials.text = Mat_Count.ToString();
    }
    IEnumerator PerformActionAfterDelay(float delay)
    {
        // Wait for the specified time (3 seconds)
        yield return new WaitForSeconds(delay);
        Multiply.text = "";
    }
}

