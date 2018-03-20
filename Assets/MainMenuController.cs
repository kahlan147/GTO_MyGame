using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text text;
    public Slider slider;

    private AsyncOperation asyncOperation = null; // When assigned, load is in progress.
    private float test = 0;

    // Use this for initialization
    void Start () {

        StartCoroutine(LoadingBarTest());
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void LoadNextScene()
    {
        StartCoroutine(AsynchronousLoad("MainScene"));
    }

    private IEnumerator AsynchronousLoad(string scene)
    {
        yield return null;
        slider.enabled = true;
        asyncOperation = SceneManager.LoadSceneAsync(scene);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            // Loading completed
            if (asyncOperation.progress == 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private IEnumerator LoadingBarTest()
    {
        while (test < 1)
        {
            test += .05f;
            Debug.Log(test);
            slider.value = test;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

}
