using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.Audio;

namespace Bootcamp0207
{
    public class AudioBoardVisualizer : MonoBehaviour
    {
        public AudioClip audioClip;
        public AudioSource audioSource;
        public AudioMixer audioMixer;

        public Board[] boards;

        public float minBoardY = 50.0f;
        public float maxBoardY = 500.0f;
        public int samples = 64;
        
        void Start()
        {
            boards = GetComponentsInChildren<Board>();

            if(audioSource == null)
            {
                audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            }
            else
            {
                audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();   
            }

            audioSource.clip = audioClip;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
            audioSource.Play();
        }

        void Update()
        {
            //samples = FFT(신호에 대한 주파수 영역)을 저장할 배열, 이 배열 값은 2의 제곱수로 표현한다.
            //채널은 최대 8개의 채널을 지원, 일반적으로는 0을 사용
            //FFTWindow는 샘플링 진행할 때 쓰는 값

            float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

            for (int i = 0; i < boards.Length; i++)
            {
                var size = boards[i].GetComponent<RectTransform>().rect.size;
                size.y = minBoardY + (data[i] * (maxBoardY - minBoardY) * 3.0f);
                boards[i].GetComponent<RectTransform>().sizeDelta = size;
                //size delta : 부모를 기준으로 크기가 얼마나 큰지 적은지 나타낸 수치
            }
        }
    }

}
