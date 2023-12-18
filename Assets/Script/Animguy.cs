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
    private bool isWalking = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        Animeguy = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking == true)
        {
            Animeguy.SetBool("Walk", true);
        }

        else
        {
            Animeguy.SetBool("Walk", false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //flip.flipX = false;
            Quaternion Rotation = Quaternion.Euler(0, 0, 0);

            transform.rotation = Rotation;
            isWalking = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //flip.flipX = true;
            Quaternion Rotation = Quaternion.Euler(0, 180, 0);

            transform.rotation = Rotation;
            isWalking = true;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            isWalking = true;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
        }

        else
        {
            isJumping = false;
        }
    }
}
