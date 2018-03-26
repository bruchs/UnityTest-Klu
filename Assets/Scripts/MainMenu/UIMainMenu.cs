using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public Image loadingProgressImage;
    private Text loadingProgressText;

    private void Start()
    {
        if(loadingProgressImage != null)
        {
            loadingProgressText = loadingProgressImage.GetComponentInChildren<Text>();
            loadingProgressImage.fillAmount = 0;
            loadingProgressText.text = "0 %";
        }
    }

    private IEnumerator WaitToLoadAsyncScene(string SceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            if (loadingProgressImage != null)
            {
                loadingProgressImage.fillAmount = asyncLoad.progress;

                string currentProgress = (Mathf.RoundToInt(asyncLoad.progress * 100)).ToString();
                loadingProgressText.text = currentProgress  + " %";
            }

            Debug.Log(asyncLoad.progress);
            yield return null;
        }
    }

    public void LoadAsyncScene(string SceneName)
    {
        StartCoroutine(WaitToLoadAsyncScene(SceneName));
    }
}
