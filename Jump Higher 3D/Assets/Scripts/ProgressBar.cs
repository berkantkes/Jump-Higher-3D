using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text progressText;
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject PlayerMove;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    public void IncreaseHealth()
    {
        slider.value++;
        float percentProgress = (slider.value / slider.maxValue) * 100;
        progressText.text = "%" + (percentProgress);
        if((percentProgress >= 100))
        {
            PlayerMove.GetComponent<PlayerMove>().ifLevelCompleteTrue();
            levelCompleteCanvas.SetActive(true);
            PlayerMove.GetComponent<PlayerMove>().GameOver();
        }
    }

}
