using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenTest : MonoBehaviour
{
    Tween t;
    private void Start()
    {
        t = transform.DOMoveX(5, 2).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            t.Play();
        }
        if (Input.GetKeyDown("space"))
        {
            t.Pause();
        }
    }
}
