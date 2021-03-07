using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public float speed = 1;
    public Transform innerCircle;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.StartFight += OnStartFight;
        gameObject.SetActive(false);
    }

    private void OnStartFight()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 nextPos = transform.position + new Vector3( x, y, 0) * Time.deltaTime * speed;
        nextPos.x = Mathf.Clamp( nextPos.x, -3.0f, 3.0f);
        nextPos.y = Mathf.Clamp( nextPos.y, -1.5f, 1.5f);
        transform.position = nextPos;


        innerCircle.Rotate(Vector3.forward);
    }
}
