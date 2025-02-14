using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    private static UILoading _instance;

    public static UILoading Instance 
    {
        get 
        {
            return _instance; 
        }
    }


    [SerializeField] private GameObject panel;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;

    private void Awake()
    {
        ResetUILoading();
        _instance = this;
    }

    public void ResetUILoading()
    {
        loadingSlider.value = 0;
        loadingText.text = "로딩 중...";
        
        if(true == panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    public void OnUILoading(float progressValue)
    {
        if(panel.activeSelf != true)
        {
            panel.SetActive(true);
        }

        float uiProgress = (progressValue <= 0.5f) ? 0.5f : progressValue;
        loadingSlider.value = uiProgress;
        loadingText.text = string.Format("로딩 중...( {0}%)", Math.Round((uiProgress * 100), 2));
    }
}
