using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator transitionGroup;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        
        transitionGroup.SetTrigger("fadeIn");

        yield return new WaitForSeconds(1f);

        while (async.progress > 0.9f)
        {
            yield break;
        }
        
        transitionGroup.SetTrigger("fadeOut");

        async.allowSceneActivation = true;
    }
}
