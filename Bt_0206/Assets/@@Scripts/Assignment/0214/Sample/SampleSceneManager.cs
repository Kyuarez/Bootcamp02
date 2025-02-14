using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootcamp0214
{
    public class SampleSceneManager : MonoBehaviour
    {

        private void OnEnable()
        {
            Debug.Log("OnSceneLoaded�� ��ϵǾ����ϴ�.");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;  
        }

        private void Update()
        {
            if(true == Input.GetKeyDown(KeyCode.U))
            {
                SceneManager.LoadScene(1);
            }
            if(true == Input.GetKeyDown(KeyCode.I))
            {
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
            }
            if(true == Input.GetKeyDown(KeyCode.O))
            {
                StartCoroutine(LoadSceneAsync());
            }
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            Debug.Log($"���� �ε� �� �� �̸��� {scene.name}�Դϴ�.");
        }

        IEnumerator LoadSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }

}
