using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider slider_master;
    [SerializeField] private Slider slider_bgm;
    [SerializeField] private Slider slider_sfx;


    private void Awake()
    {
        slider_master.onValueChanged.AddListener((float value) => SetMasterVolume(value));
        slider_bgm.onValueChanged.AddListener((float value) => SetBgmVolume(value));
        slider_sfx.onValueChanged.AddListener((float value) => SetSfxVolume(value));

    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("master_volume", Mathf.Log10(value) * 20);
        //���� ���Ǵ� Mathf �޼ҵ�
        //Mathf.Deg2Rad/ Mathf.Rad2Deg / Mathf.Abs / Mathf.Atan / Mathf.Ceil(�Ҽ��� �ø� ���) /Mathf.Clamp /
        //Mathf.Log10(���̽��� 10���� ������ ���� �α� ��ȯ) 
        //����� �ͼ��� �ּ�(-80)~�ִ�(0) ���� �� ������ �α� �Լ��� ��� 

    }
    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("bgm_volume", Mathf.Log10(value) * 20);
    }
    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("sfx_volume", Mathf.Log10(value) * 20);
    }

}
