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
            //samples = FFT(��ȣ�� ���� ���ļ� ����)�� ������ �迭, �� �迭 ���� 2�� �������� ǥ���Ѵ�.
            //ä���� �ִ� 8���� ä���� ����, �Ϲ������δ� 0�� ���
            //FFTWindow�� ���ø� ������ �� ���� ��

            float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

            for (int i = 0; i < boards.Length; i++)
            {
                var size = boards[i].GetComponent<RectTransform>().rect.size;
                size.y = minBoardY + (data[i] * (maxBoardY - minBoardY) * 3.0f);
                boards[i].GetComponent<RectTransform>().sizeDelta = size;
                //size delta : �θ� �������� ũ�Ⱑ �󸶳� ū�� ������ ��Ÿ�� ��ġ
            }
        }
    }

}
