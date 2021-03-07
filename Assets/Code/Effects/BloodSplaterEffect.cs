using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplaterEffect : MonoBehaviour
{
    public List<Sprite> bloodLooks;
    SpriteRenderer spriteRenderer;
    Color color;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Setup();
    }

    void Setup()
    {
        spriteRenderer.color = Color.red;
        spriteRenderer.sprite =  bloodLooks[ Random.Range(0, bloodLooks.Count) ];
        transform.localScale = Vector3.one * Random.Range(0.75f, 1.0f );
        StartCoroutine( "Disapire" );
    }

    IEnumerator Disapire()
    {
        yield return new WaitForSeconds(0.5f);
        color = spriteRenderer.color;

        while( spriteRenderer.color.a >= 0 )
        {
            color.a = color.a - Time.deltaTime * 1.2f;
            spriteRenderer.color = color;
            yield return new WaitForEndOfFrame();
        }
    }

    public void Reuse()
    {
        Setup();
    }
}
