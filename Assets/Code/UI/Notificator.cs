using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notificator : MonoBehaviour
{
    public Text notificationText;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.DisplayNotification += OnDisplayNotification;
    }

    void OnDestroy()
    {
        GameEvents.Instance.DisplayNotification -= OnDisplayNotification;
    }

    private void OnDisplayNotification(string _text)
    {
        notificationText.text = _text;
        StopAllCoroutines();
        StartCoroutine("BlinkToEnd");
    }

    IEnumerator BlinkToEnd()
    {
        GetComponent<BlinkCommponent>().StartBlink();
        yield return new WaitForSeconds(2);
        GetComponent<BlinkCommponent>().StopBlinkHidden();
    }
}
