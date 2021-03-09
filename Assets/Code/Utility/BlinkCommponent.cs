using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkCommponent : MonoBehaviour
{
    public GameObject target;
    public bool autoBlink;
    public bool stopHidden;
    public float blinkDelay = 0;
    public float blinkTimer = 0.5f;
    bool blink;



    public void StartBlink()
    {
        blink = true;
        StartCoroutine("Blink");
    }
    public void StopBlink()
    {
        blink = false;
        stopHidden = true;
    }
    public void StopBlinkHidden()
    {
        blink = false;
        stopHidden = true;
    }
    void Start()
    {
        if( autoBlink ) { StartBlink(); }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(blinkDelay);
        while( blink )
        {
            target.SetActive( target.activeSelf ? false : true );
            yield return new WaitForSeconds(blinkTimer);
        }
        target.SetActive( !stopHidden );
    }
}
