using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public CanvasGroup mainMenuGroup;
    public CanvasGroup optionGroup;

    public TransitionController transitionGroup;

    public void NewGameClick()
    {
        mainMenuGroup.blocksRaycasts = false;
        
        StartCoroutine(transitionGroup.LoadNewScene());
    }

    public void OptionsClick()
    {
        mainMenuGroup.alpha = 0;
        mainMenuGroup.blocksRaycasts = false;

        optionGroup.alpha = 1;
        optionGroup.blocksRaycasts = true;
    }
}
