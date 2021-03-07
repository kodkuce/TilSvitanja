using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public GameObject ammoHolder;
    public GameObject reloadText;
    int currentAmmo = 5;
    bool blinkReload;
    float blinkTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        currentAmmo = 5;
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Testing atm TODO DEL
        if( Input.GetMouseButtonUp(0) )
        {
            Debug.Log("Try bang");
            PullTrigger();
        }

        if( Input.GetMouseButtonUp(1) )
        {
            Debug.Log("Try reload");
            Reload();
        }

        if( blinkReload ) 
        { 
            blinkTimer += -Time.deltaTime;
            if( blinkTimer < 0 )
            {
                blinkTimer = 0.5f;
                reloadText.SetActive( reloadText.activeSelf ? false : true );
            }

        }else{
            reloadText.SetActive(false);
            blinkTimer = 0.5f;
        }
    }

    void Reload()
    {
        GameEvents.Instance.PlaySFX("reloadAmmo",0.8f);
        blinkReload = false;
        currentAmmo = 5;
        UpdateAmmoUI();
    }
    void UpdateAmmoUI()
    {
        for( int i =0; i<5; i++ )
        {
            if( i >= currentAmmo )
            {
                ammoHolder.transform.GetChild(i).gameObject.SetActive(false);
            }else
            {
                ammoHolder.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    void PullTrigger()
    {
        if( currentAmmo > 0 )
        {
            //Fire bullet
            GameEvents.Instance.PlaySFX?.Invoke("revolverShoots",0.8f);

            currentAmmo--;
            if( currentAmmo == 0) { blinkReload = true; }
            UpdateAmmoUI();
        }else{
            GameEvents.Instance.PlaySFX?.Invoke("outOfAmmo",0.8f);
        }
    }

    void OnApplicationQuit()
    {

    }
}
