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
        //자주 사용되는 Mathf 메소드
        //Mathf.Deg2Rad/ Mathf.Rad2Deg / Mathf.Abs / Mathf.Atan / Mathf.Ceil(소수점 올림 계산) /Mathf.Clamp /
        //Mathf.Log10(베이스가 10으로 지정된 수의 로그 반환) 
        //오디오 믹서의 최소(-80)~최대(0) 볼륨 값 때문에 로그 함수를 사용 

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
