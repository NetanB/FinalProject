using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UiFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeRoutine;

    public void FadetoBlack()
    {
        if(fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    
    } 
}
