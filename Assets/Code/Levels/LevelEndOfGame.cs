using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndOfGame : Level
{

    public GameObject teddy;
    Animator tanim;
    public GameObject wife;
    public GameObject loveParticle;
    public GameObject snowMassacre;
    public GameObject cryForewer;
    public FadeComponent blackFade;


    public List<DialogPart> dialogPart1;
    public List<DialogPart> dialogPart2;
    public List<DialogPart> dialogPart3;
    public List<DialogPart> badDialog;
    public List<DialogPart> goodDialog;
    List<DialogPart> currentDialog;
    bool nextDpart;
    bool canExit;

    protected override void VStart()
    {
        canExit = false;
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
        tanim.SetTrigger("walk");

        //Game diffrent endings
        bool goodend = PlayerPrefs.GetInt("goodend",0) == 0 ? true : false;

        yield return new WaitForSeconds(3f);
        currentDialog = dialogPart1;
        yield return RunDialog();

        wife.GetComponent<FadeComponent>().FadeOut(2);
        currentDialog = dialogPart2;
        yield return RunDialog();
        tanim.SetTrigger("idle");

        currentDialog = dialogPart3;
        yield return RunDialog();
        tanim.SetTrigger("back");

        if( goodend )
        {
            currentDialog = goodDialog;
            yield return RunDialog();
            wife.transform.position = new Vector3( 0.43f, -0.47f, -0.45f );
            loveParticle.SetActive(true);
            yield return new WaitForSeconds(5);
            blackFade.FadeOut(2);
            yield return new WaitForSeconds(3);
            snowMassacre.SetActive(true);
            blackFade.FadeIn(2);
            

        }else{
            currentDialog = badDialog;
            yield return RunDialog();
            tanim.SetTrigger("hurt");
            yield return new WaitForSeconds(2);
            blackFade.FadeOut(2);
            yield return new WaitForSeconds(3);
            cryForewer.SetActive(true);
            blackFade.FadeIn(2);
        }

        yield return new WaitForSeconds(5);
        canExit = true;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            canExit = false;
            GameEvents.Instance.DisplayTrasactionScreen("");
            Invoke("GoMainMenu", 2f );
        }
    }

    void GoMainMenu()
    {
        Destroy(gameObject);
        Instantiate( mainMenuLevel );
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
