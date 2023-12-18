using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator objAnimator;
    private SpriteRenderer objRenderer;
    public bool IsJumping;
    private Rigidbody2D objRigidbody;
    public float jumpforce;
    public float cooler;
    public float dist;
    private bool canJump = true;
    public float jumpCooler;
    private bool jumpProc = true;
    private int counter;

    private IEnumerator jumpAnimation()
    {
        objAnimator.SetBool("IsJumping", true);
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        objRigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && canJump == true)
        {
            StartCoroutine(jumpAnimation());

           /* float start_time = Time.time;
            jumpCooler = Time.time + 2f;

            while (jumpProc == true)
            {
                Debug.Log("WTF");
                objAnimator.SetBool("IsJumping", true);

                Debug.Log(Time.time > jumpCooler);
                if (Time.time > jumpCooler)
                {

                    objRigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                    cooler = Time.time + 1;
                    canJump = false;
                    jumpProc = false;
                    //break;
                }
                counter++;
                if (counter >= 10000)
                {
                    jumpProc = false;
                }
            }*/
            
        }
        if (isGrounded() == true && canJump == true)
        {

            objAnimator.SetBool("IsJumping", false);
            canJump = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,dist);
        return hit.collider != null;
    }


    // Start is called before the first frame update
    void Start()
    {
        objAnimator = GetComponent<Animator>();
        objRenderer = GetComponent<SpriteRenderer>();
        objRigidbody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            objAnimator.SetBool("IsWalking", true);
            objRenderer.flipX = false;
        }
         
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            objAnimator.SetBool("IsWalking", true);
            objRenderer.flipX = true;   
        }
        else
        {
            objAnimator.SetBool("IsWalking", false);
        }

        jump();

        //Debug.Log("Time is: " + Time.time + " and cooler is " + jumpCooler);
    }
}
