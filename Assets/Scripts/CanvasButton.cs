using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CanvasButton : MonoBehaviour
{
    public BarFillAndDecrease scriptA;
    public void ZemljaBuyFactory()
    {
     int price = 10;
        int junk = PlayerPrefs.GetInt("junk", 0);
        if (junk >= price) { 

            PlayerPrefs.SetInt("junk", junk-price);
            scriptA = GameObject.Find("proccesing_counter").GetComponent<BarFillAndDecrease>();
            scriptA.SetValue(price);
            scriptA.Junk_Procesing();
            Console.WriteLine("canvas button working");
            price += price;

        }   
    }
}
