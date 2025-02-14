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
            Debug.Log("OnSceneLoaded가 등록되었습니다.");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;  
        }

        private void Update()
        {
            //if(true == Input.GetKeyDown(KeyCode.U))
            //{
            //    SceneManager.LoadScene(1);
            //}
            //if(true == Input.GetKeyDown(KeyCode.I))
            //{
            //    SceneManager.LoadScene(1, LoadSceneMode.Additive);
            //}
            if(true == Input.GetKeyDown(KeyCode.O))
            {
                StartCoroutine(LoadSceneAsync());
            }
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            Debug.Log($"현재 로드 된 씬 이름은 {scene.name}입니다.");
        }

        IEnumerator LoadSceneAsync()
        {
            UILoading.Instance.OnUILoading(0f);

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                UILoading.Instance.OnUILoading(progress);
                yield return null;
            }

            UILoading.Instance.OnUILoading(1f);
            yield return new WaitForSeconds(1f);
            UILoading.Instance.ResetUILoading();
        }
    }

}
