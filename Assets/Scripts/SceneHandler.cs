using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private int nextButtonIndex = 0;
    [SerializeField] private int preveButtonIndex = 0;

    private const float FADING_DURATION = 1.5f;
    private Coroutine routine;

    private void Start()
    {
        routine = StartCoroutine(Fade());
    }

    public void Home()
    {
        StopCoroutine(routine);
        routine = StartCoroutine(Fade(true, LoadHome));
    }

    public void LoadNext()
    {
       StopCoroutine(routine);
       routine =  StartCoroutine(Fade(true, LoadNextScene));
    }

    public void LoadPrev()
    {
        StopCoroutine(routine);
        routine = StartCoroutine(Fade(true, LoadPrevScene));
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextButtonIndex);
    }

    private void LoadPrevScene()
    {
        SceneManager.LoadScene(preveButtonIndex);
    }

    private void LoadHome()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator Fade(bool isFadeIn = false, Action loadSceneCallBack = null)
    {
        var fadeToValue = isFadeIn ? 0 : 1;
        var startValue = canvasGroup.alpha;
        var time = 0f;
        while (time < FADING_DURATION)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, fadeToValue, time / FADING_DURATION);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = fadeToValue;

        if(loadSceneCallBack != null)
        {
            loadSceneCallBack.Invoke();
        }
    }
}
