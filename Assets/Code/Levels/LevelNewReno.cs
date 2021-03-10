using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNewReno : Level
{
     [Header("Dialog Settings")]
    public GameObject oldman;
    public GameObject teddy;
    public GameObject thugRoot;
    Animator tanim;


    bool nextDpart;
    List<DialogPart> currentDialog;

    public List<DialogPart> dialogPart1;
    public List<DialogPart> dialogPart2;

    [Header("Fight Settings")]
    public int enemyCount = 3;
    public List<Transform> spawnPositions;


    protected override void VStart()
    {
        tanim = teddy.GetComponent<Animator>();
        GameEvents.Instance.DialogClose += OnDialogClose;
        GameEvents.Instance.EnemyDied += OnEnemyDied;

        StartCoroutine( "ProcessLevel" );
    }

    private void OnEnemyDied()
    {
        enemyCount--;
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
        teddy.GetComponent<FadeComponent>().FadeIn(2);
        oldman.GetComponent<FadeComponent>().FadeIn(2);
        foreach( FadeComponent fc in thugRoot.GetComponentsInChildren<FadeComponent>() )
        {
            fc.FadeIn(2);
        }


        yield return new WaitForSeconds(0.1f);
        GameEvents.Instance.DisplayNotification?.Invoke("FIGHT STARTED");
        yield return new WaitForSeconds(2f);
        GameEvents.Instance.FightStart?.Invoke();
        yield return new WaitForSeconds(0.75f);

        float spawndelay = 2f;
        int spawncount = enemyCount;
        while( spawncount > 0 )
        {
            //pick a random place to spawn
            Vector3 rpos = spawnPositions[ Random.Range(0, spawnPositions.Count) ].position;
            RaycastHit2D hit = Physics2D.Raycast( rpos, Vector2.zero );
            if( hit.collider != null )
            {
                //if we hit some enemy it means we should not spawn enemy there
                continue; //so we skip
            }

            spawncount--;
            if( spawncount == 0 )
            {
                GameEvents.Instance.SpawnGameObject( "npcEnemyThugBoss" , new Vector3( 0, -0.73f, 0 ), Quaternion.identity );
            }else{
                GameEvents.Instance.SpawnGameObject( "npcEnemyThug" , rpos , Quaternion.identity );
            }

            yield return new WaitForSeconds( Random.Range(spawndelay, spawndelay*2));
            if( spawncount == 18 ) { spawndelay = 1.75f;} //dirty hardness buff
            if( spawncount == 12 ) { spawndelay = 1.5f;} 
            if( spawncount == 6 ) { spawndelay = 1f;}
        }


        yield return new WaitUntil( () => enemyCount <= 0 );
        GameEvents.Instance.FightEnd?.Invoke();
        yield return new WaitForSeconds( 1 );
        teddy.GetComponent<FadeComponent>().FadeOut(2);
        oldman.GetComponent<FadeComponent>().FadeOut(2);
        yield return new WaitForSeconds( 1 );


        currentDialog = dialogPart2;
        yield return RunDialog();
        GoNextLevel();
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
        GameEvents.Instance.EnemyDied -= OnEnemyDied;
    }
}
