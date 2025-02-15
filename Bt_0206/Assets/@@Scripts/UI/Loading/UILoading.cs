using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : TSingleton<UILoading>
{

    [SerializeField] private GameObject panel;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;

    [SerializeField] private Sprite loadingBg;
    [SerializeField] private Sprite downloadBg;

    public void ResetUILoading()
    {
        loadingSlider.value = 0;
        loadingText.text = "�ε� ��...";
        
        if(true == panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    public void OnUILoading(LoadingType loadingType, float progressValue)
    {
        float uiProgress; 
        
        switch (loadingType)
        {
            case LoadingType.Scene:
                uiProgress = (progressValue <= 0.5f) ? 0.5f : progressValue;
                backgroundImage.sprite = loadingBg;
                loadingText.text = string.Format("�ε� ��...( {0}%)", Math.Round((uiProgress * 100), 2));
                break;
            case LoadingType.Download:
                uiProgress = progressValue;
                backgroundImage.sprite = downloadBg;
                loadingText.text = string.Format("�ٿ�ε� ��...( {0}%)", Math.Round((uiProgress * 100), 2));
                break;
            default:
                uiProgress = progressValue;
                backgroundImage.sprite = loadingBg;
                break;
        }

        loadingSlider.value = uiProgress;

        if (panel.activeSelf != true)
        {
            panel.SetActive(true);
        }
    }
}
