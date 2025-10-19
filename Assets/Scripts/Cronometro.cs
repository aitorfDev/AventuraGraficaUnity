using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private GameObject timerTextItem;
    private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 300f; 

    float currentTime;
    bool running = true;

    void Start()
    {
        timerText = timerTextItem.GetComponent<TextMeshProUGUI>();
        currentTime = startTime;
    }

    void Update()
    {
        if (!running) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            running = false;
            timerText.text = "00:00";

            GameSceneManager.Instance.LoadFinalTime();
        }
        else
        {
            int min = Mathf.FloorToInt(currentTime / 60);
            int sec = Mathf.FloorToInt(currentTime % 60);
            timerText.text = $"{min}:{sec:00}";
        }
    }

    public void StopTimer()
    {
        running = false;
    }
}
