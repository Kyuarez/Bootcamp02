# 유니티 부트캠프 2월 관련 리포지토리

### [25.02.27] 내용 정리
-------
#### 오디오 소스(AudioSource)

**[오디오 소스]**
씬에서 오디오 클립을 재생하는 도구이다. 
+ 재생을 위해서는 오디오 리스너(Audio Listener)나 오디오 믹서(Audio Mixer)가 필요하다.
+ 중요 프로퍼티
  + Output : None이면 오디오 리스너에서 처리, 그 외에는 믹서를 넣으면 믹서에 출력
  + Volume : **"리스너 거리"** 기준으로 소리에 대한 수치
  + Pitch : 재생 속도
  + Spatial Blend : (0 ~ 1) 0에 가까울 수록 거리와 상관 없이 일정하게 전달
 

[대표적인 코드]
그냥 UnityWebRequest로 동적으로 음원 파일 불러오기 (메소드 나가면, 변수 사라지니까 sfx 같은 거 구현에 유리)

'''
IEnumerator GetAudioClip()
{


    using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/GleeClubPolka.mp4", AudioType.WAV))
    {
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            audioSourceBGM.clip = DownloadHandlerAudioClip.GetContent(www);
        }
    }

}
'''

------
#### 오디오 믹서(AudioMixer)

**[오디오 소스]**
오디오 소스에 대한 제어, 균형, 조정을 제공하는 도구
+ 최초 생성 시, Master 그룹이 존재.
+ 각 변수 별로 스크립트로 조정할 수 있음. Expose to Scripts하면 파라미터 생성 됨.


[대표적인 코드]
'''
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
'''


#### 참고 : 왜 Mathf.Log10(value) * 20 사용해?
오디오 믹서의 최소, 최대 데시벨은 (-80db ~ 0db)이다.
그래서, 슬라이더의 값을 (0.0001 ~ 1)까지로 설정하면, Log10^-4 * 20 ~ 1 * Log1 * 20 라서 -80 ~ 0으로 설정된다.
그냥 계산하기 편해서 사용한 것이다. ㅎㅎ


