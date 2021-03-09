using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogRoot;
    public Image profilePicture;
    public Text textElement;
    string currentText;
    int reachedLetter;

    void Start()
    {
        GameEvents.Instance.DialogDisplay += OnDialogDisplay;
    }

    private void OnDialogDisplay(DialogPart dialogPart)
    {
        profilePicture.sprite = dialogPart.profile;
        currentText = dialogPart.text;
        StartCoroutine( "RunDialog" );
    }

    void Update()
    {
        if(Input.GetButtonUp("Use"))
        {
            StopCoroutine("RunDialog");
            if( textElement.text == currentText && dialogRoot.activeInHierarchy )
            {
                //If dialog finished pressing E should close dialog panel
                dialogRoot.SetActive(false);
                GameEvents.Instance.DialogClose?.Invoke();
            }
            textElement.text = currentText;
        }
    }

    void HideDialogPanel()
    {
        dialogRoot.SetActive(false);
    }

    IEnumerator RunDialog()
    {
        // currentText = _text;
        textElement.text = "";
        reachedLetter=0;
        // profilePicture.sprite = pPic;
        dialogRoot.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        while( textElement.text != currentText )
        {
            reachedLetter++;
            textElement.text = currentText.Substring(0, reachedLetter);
            yield return new WaitForSeconds(0.025f);
        }
    }
}

[Serializable]
public class DialogPart
{
    public Sprite profile;
    [TextArea]
    public string text;
}
