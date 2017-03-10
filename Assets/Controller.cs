using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float force;
    public score_manager score_manager;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(new Vector2(0, force));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(new Vector2(0, -force));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(force, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-force, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("coin"))
        {
            score_manager.addscore(10);
            col.gameObject.SetActive(false);
        }
    }
}
