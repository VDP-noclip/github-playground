using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionFader : ScreenFader
{
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private float delay = 0.3f;
    [SerializeField] private TMP_Text transitionText;

    public float Delay
    {
        get { return delay; }
    }
    
    private void Awake()
    {
        lifetime = Mathf.Clamp(lifetime, FadeOnDuration + FadeOffDuration + delay, 10f);
    }

    public void SetText(string text="")
    {
        if (transitionText != null)
        {
            transitionText.text = text;
        }
    }
    
    private IEnumerator PlayRoutine()
    {   
        SetAlpha(clearAlpha);
        yield return new WaitForSeconds(delay);

        FadeOn();

        float onTime = lifetime - (FadeOffDuration + delay);
        yield return new WaitForSeconds(onTime);

        FadeOff();
        
        print("FADER DESTROYED");
        
        Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public static void PlayTransition(TransitionFader transitionPrefab, string text = "READY")
    {
        if (transitionPrefab != null)
        {
            print("Transition Fader Created");
            TransitionFader instance = Instantiate(transitionPrefab, Vector3.zero, Quaternion.identity);
            instance.SetText(text);
            print("Transition Fader Created <" + instance.gameObject.name + ">");
            instance.Play();
        }
    }
}
