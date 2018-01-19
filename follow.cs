using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    public float xDis = 0;
    public float speed = 1.0f;
    private GameObject target = null;
    private Vector2 follower;
    private Animator animator;
    private bool isFacingRight = true;
    new SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        follower.y = transform.position.y;
        animator = this.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        float dis = Vector2.Distance(transform.position, target.transform.position);
         if (transform.position.x < 6.0f)
        {

            if (dis < xDis)
            {
                Flip();
                animator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Flip();
                animator.SetBool("isMoving", false);
            }
        }
        else if(transform.position.x >= 6)
        {
            animator.SetBool("isMoving", false);
        }
	}
    
    void Flip()
    {
        if(target.transform.position.x < this.transform.position.x && isFacingRight == true)
        {
            isFacingRight = !isFacingRight;
            renderer.flipX = true;
        }
        else if(target.transform.position.x > this.transform.position.x && isFacingRight == false)
        {
            isFacingRight = !isFacingRight;
            renderer.flipX = false;
        }
    }
}
