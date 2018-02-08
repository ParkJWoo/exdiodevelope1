using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private GameObject target = null;
    private GameObject follower = null;
    private GameObject target2;
    private bool sub;
    public int i = 0;

    public GUIStyle TextStyle;

    public string[] SUBTITLE;

    private const float WAIT_TIME = 0.1f;

    private float waitTimer = 0.0f;

    private string typewriterText = "";

    private int currentIndex = 0;

    private Animator anim;
    public Animator Anim
    {
        get
        { return anim; }

        set
        { anim = value; }
    }

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("creature");
        follower = GameObject.Find("male_character");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (target.transform.position.x < 30.58f) // 열림
        {
            anim.SetBool("isOpening", true);
        }

        else if (target.transform.position.x >= 30.58f)
        {

            anim.SetBool("isOpening", false);

        }


        if (sub == true)
        {

            if (i < 8)
            {
                GameObject.Find("female_character").GetComponent<PlayerControl>().enabled = false;
                GameObject.Find("female_character").GetComponent<Animator>().SetBool("move_it", false);
            }

            if (i >= 8)
            {

                GameObject.Find("female_character").GetComponent<PlayerControl>().enabled = true;
                sub = false;

            }


            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                i++;
                currentIndex = 0;
                typewriterText = "";

            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                i--;
                currentIndex = 0;
                typewriterText = "";

            }


            waitTimer += Time.deltaTime;

            if (waitTimer > WAIT_TIME && currentIndex < SUBTITLE[i].Length)
            {
                typewriterText += SUBTITLE[i][currentIndex];
                waitTimer = 0.0f;
                ++currentIndex;
            }


        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //주인공이 문과 충돌하면
        if (collision.tag == "Player")
        {
            if (Input.GetMouseButton(0))
            {
                CastRay();
                if (target2 == this.gameObject)
                {
                    follower.GetComponent<character_follow>().enabled = false;
                    follower.GetComponent<Animator>().SetBool("move_it", false);
                    sub = true;
                    //남주가 움직이지 않는다
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

    private void OnGUI()
    {
        GUI.Label(new Rect((Screen.width) / 3, (Screen.height) * 1.7f / 3, 400.0f, 200.0f), typewriterText, TextStyle);
    }
}