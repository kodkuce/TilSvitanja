//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public float speed = 1;
    public Transform innerCircle;
    public GameObject aimRoot;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.FightStart += OnFightStart;
        GameEvents.Instance.FightEnd += OnFightEnd;
        GameEvents.Instance.PlayerShoot += OnPlayerShoot;
    }

    private void OnPlayerShoot()
    {
        anim.SetTrigger("shoot");
        RaycastHit2D hit = Physics2D.Raycast( transform.position, Vector2.zero );
        if( hit.collider != null )
        {
            // Debug.Log("Hitted something: " + hit.collider.gameObject.name );
            hit.collider.GetComponent<IEatDamage>()?.ReciveDamage(1, hit.point );

        }else{
            Debug.Log("Miss");
        }
    }

    private void OnFightEnd()
    {
        aimRoot.SetActive(false);
    }

    private void OnFightStart()
    {
        transform.position = new Vector3( Random.Range(-1.3f, 1.3f), Random.Range(-1.3f, 1.3f), -9 );
        aimRoot.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float x = -Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 nextPos = transform.position + new Vector3( x, y, 0) * Time.deltaTime * speed;
        nextPos.x = Mathf.Clamp( nextPos.x, -3.0f, 3.0f);
        nextPos.y = Mathf.Clamp( nextPos.y, -1.5f, 1.5f);
        transform.position = nextPos;


        innerCircle.Rotate(Vector3.forward);
    }
}
