using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float pSpeed;
    private float horSpeed;
    private bool sprintActive;
    public float sprintSpeed;
    public float jumpForce;
    private Rigidbody2D rBody;

    //Sprite stuff
    private SpriteRenderer sRenderer;
    public Sprite[] runAnimation;
    public Sprite[] idleAnimation;
    public Sprite[] sprintAnimation;
    public Sprite[] jumpAnimation;
    private int imageIndex = 0;
    private float animationSpeed = 0.14f;

    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        StartCoroutine(playerAnims());
    }

    // Update is called once per frame
    void Update()
    {
        idleBehaviour();
        horizontalMovement();
        jumpMechanic();

        Debug.Log(IsGrounded());
    }

    private void idleBehaviour()
    {
        
    }
    private void horizontalMovement()
    {
        float _vertSpeed = Input.GetAxis("Vertical");
        horSpeed = Input.GetAxisRaw("Horizontal");

        //Move left and right and check whether the player is sprinting or not.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintActive = true;
            transform.Translate(Vector3.right * sprintSpeed * horSpeed * Time.deltaTime);
        }
        else
        {
            sprintActive = false;

            transform.Translate(Vector3.right * pSpeed * horSpeed * Time.deltaTime);
        }
        

    }

    private void jumpMechanic()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        //In order for this to work as intended, the player character must be on the "Ignore Raycast" layer. This can be found in the top right of the inspector.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        return hit.collider != null;

    }

    bool JumpDirection()
    {
        //This code was never needed as the spritesheet did not containt a "landing" animation.
        float vertVelocity = rBody.velocity.y;

        if(vertVelocity > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator playerAnims()
    {
        bool jumpApex = false;

        while (true)
        {
            if (IsGrounded())
            {
                jumpApex = false;

                //Player is moving to the right
                if (horSpeed > 0)
                {
                    if (sprintActive == true)
                    {
                        for (int i = 0; i < sprintAnimation.Length; i++)
                        {
                            if (horSpeed <= 0 || sprintActive == false)
                            {
                                break;
                            }
                            sRenderer.flipX = false;
                            sRenderer.sprite = sprintAnimation[i];

                            //The time between each sprite change
                            yield return new WaitForSeconds(animationSpeed);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < runAnimation.Length; i++)
                        {
                            if (horSpeed <= 0 || sprintActive == true)
                            {
                                break;
                            }
                            sRenderer.flipX = false;
                            sRenderer.sprite = runAnimation[i];

                            //The time between each sprite change
                            yield return new WaitForSeconds(animationSpeed);
                        }
                    }

                }
                //player is running to the left
                if (horSpeed < 0)
                {
                    if (sprintActive == true)
                    {
                        for (int i = 0; i < sprintAnimation.Length; i++)
                        {
                            if (horSpeed >= 0 || sprintActive == false)
                            {
                                break;
                            }
                            sRenderer.flipX = true;

                            sRenderer.sprite = sprintAnimation[i];

                            //The time between each sprite change
                            yield return new WaitForSeconds(animationSpeed);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < runAnimation.Length; i++)
                        {
                            if (horSpeed >= 0 || sprintActive == true)
                            {
                                break;
                            }
                            sRenderer.flipX = true;

                            sRenderer.sprite = runAnimation[i];

                            //The time between each sprite change
                            yield return new WaitForSeconds(animationSpeed);
                        }
                    }

                }

                if (horSpeed == 0)
                {
                    for (int i = 0; i < idleAnimation.Length; i++)
                    {
                        if (horSpeed != 0)
                        {
                            break;
                        }

                        sRenderer.sprite = idleAnimation[i];

                        //The time between each sprite change
                        yield return new WaitForSeconds(animationSpeed);
                    }
                }
            }
            else
            {
                //Jump animation here

                //check direction of the player
                if(horSpeed < 0)
                {
                    sRenderer.flipX = true;
                }
                if(horSpeed > 0)
                {
                    sRenderer.flipX = false;
                }

                if (JumpDirection() && jumpApex == false)
                {
                    for(int i = 0; i < jumpAnimation.Length; i++)
                    {
                        sRenderer.sprite = jumpAnimation[i];
                        if(i == jumpAnimation.Length)
                        {
                            jumpApex = true;
                        }
                    }
                }

            }
            

            yield return null;
        }
    }
}
