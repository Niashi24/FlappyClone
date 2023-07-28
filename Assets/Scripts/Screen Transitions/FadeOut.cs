using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private List<Image> imagesToFade;

    [SerializeField]
    private float timeToFade = 0.5f;

    private float _timer = 0.0f;

    private bool _startedFade = false;

    private void Update()
    {
        if (_startedFade)
        {
            _timer = Mathf.Max(0, _timer - Time.deltaTime);
            
            float a = _timer / timeToFade;
            
            imagesToFade.ForEach(x => x.color = x.color.With(a: a));
        }
    }

    public void StartFade()
    {
        _startedFade = true;
        _timer = timeToFade;
    }
}
