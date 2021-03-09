using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeComponent : MonoBehaviour
{
    
    public SpriteRenderer target;
    Color color;
  

    public void FadeIn(float _speed)
    {
        StopAllCoroutines();
        StartCoroutine("FIn",_speed);
    }
    IEnumerator FIn(float speed)
    {
        color = target.color;
        while( color.a > 0.01f )
        {
            color.a += -Time.deltaTime * speed;
            target.color = color;
            yield return new WaitForEndOfFrame();
        }
    }

    public void FadeOut(float _speed)
    {
        StopAllCoroutines();
        StartCoroutine("FOut", _speed);
    }

    IEnumerator FOut(float speed)
    {
        color = target.color;
        while( color.a < 0.99f )
        {
            color.a += Time.deltaTime;
            target.color = color;
            yield return new WaitForEndOfFrame();
        }
    }
}
