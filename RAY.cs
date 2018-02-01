using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RAY : MonoBehaviour
{
    private GameObject target = null;
    private GameObject target2;

    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //주인공이 문과 충돌하면
        if (collision.tag == "Player")
        {
            Debug.Log("We arrived at the door");
            if (Input.GetMouseButton(0))
            {
                CastRay();
                if (target2 == this.gameObject)
                {
                    SceneManager.LoadScene("1");
                }
            }
        }
    }

    void CastRay()
    {
        target2 = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target2 = hit.collider.gameObject;
        }
    }
}