using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : Level
{
    public GameObject teddy;
    Animator tanim;
    public GameObject wife;
    public GameObject zzz;


    public List<DialogPart> dialogPart1;
    public List<DialogPart> dialogPart2;
    public List<DialogPart> dialogPart3;
    List<DialogPart> currentDialog;
    bool nextDpart;

    protected override void VStart()
    {
        tanim = teddy.GetComponent<Animator>();
        GameEvents.Instance.DialogClose += OnDialogClose;
        StartCoroutine( "ProcessLevel" );
    }

    private void OnDialogClose()
    {
        nextDpart = true;
        currentDialog.RemoveAt(0);
    }

    IEnumerator ProcessLevel()
    {
        tanim.SetTrigger("sleep");

        yield return new WaitForSeconds(3f);
        currentDialog = dialogPart1;
        yield return RunDialog();

        yield return new WaitForSeconds(0.1f);
        zzz.SetActive(false);
        tanim.SetTrigger("idle");
        yield return new WaitForSeconds(0.2f);

        currentDialog = dialogPart2;
        yield return RunDialog();

        tanim.SetTrigger("givemirror");
        currentDialog = dialogPart3;
        yield return RunDialog();

        GoNextLevel();
        Debug.Log("Finished"); 
    }

    IEnumerator RunDialog( )
    {
        while( currentDialog.Count > 0 )
        {
            GameEvents.Instance.DialogDisplay?.Invoke( currentDialog[0] );
            yield return new WaitUntil( () => nextDpart );
            nextDpart = false;
        }
    }

    protected override void VOnDestory()
    {
        GameEvents.Instance.DialogClose -= OnDialogClose;
    }

}
