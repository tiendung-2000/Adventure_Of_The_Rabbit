using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text loadingText;

    public float duration = 5.0f;
    public bool process;

    private void OnEnable()
    {
        slider.value = 0;
        process = true;
    }

    void Update()
    {
        loadingText.text = "Loading... " + slider.value + "%";
    }

    void Start()
    {
        // Start the coroutine when the script starts
        StartCoroutine(MoveSlider());
    }

    IEnumerator MoveSlider()
    {
        float elapsedTime = 0.0f;
        float startValue = slider.value;

        while (process)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the value based on elapsed time and duration
            float sliderValue = Mathf.Lerp(startValue, 100f, elapsedTime / duration);

            // Set the slider value
            slider.value = sliderValue;

            // Break the loop if the duration has passed
            if (elapsedTime >= duration)
            {
                // Reset the elapsed time and start value for next iteration
                elapsedTime = 0.0f;
                startValue = slider.value;
            }

            if (slider.value >= 100)
            {
                process = false;
                menuUI.SetActive(true);
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }
}
