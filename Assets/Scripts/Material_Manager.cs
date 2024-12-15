using UnityEngine;
using UnityEngine.UI;
public class Material_Manager : MonoBehaviour
{
    public static Material_Manager instance;
    public Text Materials;
    int Mat_Count = 0;
    private void Awake()
    {
        instance = this;   
    }
    void Start()
    {
        Materials.text = Mat_Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add_Mat1()
    {
        Mat_Count += 1;
        Materials.text = Mat_Count.ToString();

    }
    public void Add_Mat2()
    {
        Mat_Count += 2;
        Materials.text = Mat_Count.ToString();

    }
    public void Add_Mat5()
    {
        Mat_Count += 5;
        Materials.text = Mat_Count.ToString();

    }
}
