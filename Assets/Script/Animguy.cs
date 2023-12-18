using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animguy : MonoBehaviour
{
    private Animator Animeguy;
    public float speed;
    private SpriteRenderer flip;

    // Start is called before the first frame update
    void Start()
    {
        Animeguy = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animeguy.SetBool("Walk", true);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Animeguy.SetBool("Walk", false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            flip.flipX = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            flip.flipX = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
