using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;

public class BarFillAndDecrease : MonoBehaviour
{
    // Reference to the slider (progress bar) and text to display the integer
    public Slider progressBar;
    public Text integerDisplay;
    int number_of_factories = 0;
    private int making_material = 0;
    private bool is_making_material = false;
    public Animator animator;
    public float upgrade_time = 4f;
    // The integer that will be decreased over time
    private int counter = 10;  // Starting value of the integer
    public void SetValue(int newValue)
    {
        counter = newValue;
    }
    public void SetValueMat(int newValue, bool making)
    {
        is_making_material = making;
        counter = newValue;
        making_material = counter;
        Debug.Log(is_making_material);
    }
    public void Junk_Procesing()
    {
        // Initialize the UI display
        UpdateIntegerDisplay();

        // Start the coroutine to fill the bar and decrease the counter
        StartCoroutine(FillBarAndDecreaseCounter());
    }

    IEnumerator FillBarAndDecreaseCounter()
    {
        while (counter > 0)
        {
            // Fill the bar over 5 seconds
            float fillTime = upgrade_time;
            float elapsedTime = 0f;

            while (elapsedTime < fillTime)
            {
                // Calculate the slider value based on elapsed time
                progressBar.value = elapsedTime / fillTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the bar is fully filled after the 5 seconds
            progressBar.value = 1f;

            // Decrease the counter by 1
            counter--;

            // Update the integer display
            UpdateIntegerDisplay();

            // Wait for a second before starting to fill again
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Counter has reached 0.");
        if (is_making_material == false)
        {
            if (number_of_factories == 0)
            {
                animator.SetBool("c1", true);
                upgrade_time = 3f;
            }
            if (number_of_factories == 1)
            {
                animator.SetBool("c2", true);
                upgrade_time = 2f;
            }
            if (number_of_factories == 2)
            {
                animator.SetBool("c3", true);
                upgrade_time = 1f;
            }
            if (number_of_factories == 3)
            {
                animator.SetBool("c4", true);
                upgrade_time = 0.6f;
            }
            number_of_factories++;
        }
        else {
             PlayerPrefs.SetInt("zemlja_materials", making_material);
            Debug.Log(PlayerPrefs.GetInt("zemlja_materials", 0).ToString());
        }
        is_making_material = false;
        }
    

    // Update the integer display text
    void UpdateIntegerDisplay()
    {
        integerDisplay.text =counter.ToString();
    }
}
    