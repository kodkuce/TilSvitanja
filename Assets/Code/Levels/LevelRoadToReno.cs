using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoadToReno : Level
{
    [Header("Dialog Settings")]
    public GameObject copCinematic;
    public GameObject teddy;
    Animator tanim;


    bool nextDpart;
    List<DialogPart> currentDialog;

    public List<DialogPart> dialogPart1;
    public List<DialogPart> dialogPart2;
    public List<DialogPart> dialogPart3;

    [Header("Fight Settings")]
    public string enemy;
    public int enemyCount;
    public List<Transform> spawnPositions;

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
        tanim.SetTrigger("back");

        yield return new WaitForSeconds(3f);
        currentDialog = dialogPart1;
        yield return RunDialog();

        yield return new WaitForSeconds(0.1f);
        tanim.SetTrigger("gunmirror");
        currentDialog = dialogPart2;
        yield return RunDialog();

        yield return new WaitForSeconds(0.1f);
        teddy.GetComponent<FadeComponent>().FadeIn(2);
        foreach( FadeComponent fc in copCinematic.GetComponentsInChildren<FadeComponent>() )
        {
            fc.FadeIn(2);
        }

        yield return new WaitForSeconds(1.5f);
        GameEvents.Instance.FightStart?.Invoke();
        GameEvents.Instance.DisplayNotification?.Invoke("FIGHT STARTED");

        yield return new WaitForSeconds(1.2f);
        int spawncount = enemyCount;
        while( spawncount > 0 )
        {
            spawncount--;
            // GameEvents.Instance.SpawnGameObject(enemy, ) CONTINUE HERE
        }
        yield return new WaitUntil( () => nextDpart );



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
}
