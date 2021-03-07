using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour
{
    public Image bg;
    Color color;
    public Text textElement;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.DisplayTrasactionScreen += OnDisplayTransactionScreen;
    }

    private void OnDisplayTransactionScreen(string _text)
    {
        StartCoroutine( "StartTransition", _text );
    }

    IEnumerator StartTransition( string _text )
    {
        textElement.text = _text;
        yield return new WaitForSeconds(0.1f);

        //black bg and mute sound
        color = bg.color;
        while( bg.color.a < 0.999f )
        {
            AudioListener.volume += -Time.deltaTime;
            color = new Color(bg.color.r, bg.color.g, bg.color.b, bg.color.a + Time.deltaTime );
            bg.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.1f);

        //display text
        textElement.color = new Color(1,1,1,0);
        textElement.enabled = true;
        color = textElement.color;
        while( textElement.color.a < 0.999f )
        {
            color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, textElement.color.a + Time.deltaTime * 2 );
            textElement.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);
        //Mid point
        

        //hide tex
        textElement.color = new Color(1,1,1,1);
        color = textElement.color;
        while( textElement.color.a > 0.01f )
        {
            color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, textElement.color.a - Time.deltaTime * 2 );
            textElement.color = color;
            yield return new WaitForEndOfFrame();
        }
        textElement.enabled = false;


        //black bg and turn on sound
        color = bg.color;
        while( bg.color.a > 0.01f )
        {
            AudioListener.volume += Time.deltaTime;
            color = new Color(bg.color.r, bg.color.g, bg.color.b, bg.color.a - Time.deltaTime );
            bg.color = color;
            yield return new WaitForEndOfFrame();
        }

        color.a = 0;
        bg.color = color;
        AudioListener.volume = 1;
    }
}
