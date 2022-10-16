using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] protected float solidAlpha = 1.0f;

    [SerializeField] protected float clearAlpha = 0.0f;

    [SerializeField] private float fadeOnDuration = 2f;

    [SerializeField] private float fadeOffDuration = 2f;

    [SerializeField] private MaskableGraphic[] graphicsToFade;

    public float FadeOnDuration
    {
        get { return fadeOnDuration; }
    }

    public float FadeOffDuration
    {
        get { return fadeOffDuration; }
    }
    
    protected void SetAlpha(float alpha)
    {
        for (int i = 0; i < graphicsToFade.Length; i++)
        {
            if (graphicsToFade[i] != null)
            {
                graphicsToFade[i].canvasRenderer.SetAlpha(alpha); 
            }
        }
    }

    private void Fade(float targetAlpha, float duration)
    {
        for (int i = 0; i < graphicsToFade.Length; i++)
        {
            if (graphicsToFade[i] != null)
            {
                graphicsToFade[i].CrossFadeAlpha(targetAlpha,duration,true);
            }
        }
    }

    public void FadeOff()
    {
        SetAlpha(solidAlpha);
        Fade(clearAlpha,fadeOffDuration);
    }
    
    public void FadeOn()
    {
        SetAlpha(clearAlpha);
        Fade(solidAlpha,fadeOnDuration);
    }
}
