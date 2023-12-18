using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private SpriteRenderer rsprite;
    public Sprite[] idl;
    public Sprite[] move;
    public Sprite[] jump;
    public Sprite[] eat;
    private Rigidbody2D rigbod;
    public int speed = 5;
    private float horspeed;
    public float animspeed = 0.5f;
    public float jumpforce = 1;
    bool jumpd = false;

    // Start is called before the first frame update
    void Start()
    {
        rsprite = GetComponent<SpriteRenderer>();
        rigbod = GetComponent<Rigidbody2D>();
        StartCoroutine(anim());
    }

    // Update is called once per frame
    void Update()
    {
        moving();
        hopp();
    }
    private void moving()
    {
        horspeed = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        //print(horspeed);
    }
    private void hopp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigbod.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            print("test");
        }
    }
    bool ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        return hit.collider != null;
    }
    bool vermove()
    {
        float vervel = rigbod.velocity.y;
        if (vervel > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private IEnumerator anim()
    {
        
        while (true)
        {
            if (ground())
            {
                if (horspeed > 0)
                {
                    for (int i = 0; i < move.Length; i++)
                    {
                        if (horspeed <= 0)
                        {
                            break;
                        }
                        rsprite.sprite = move[i];
                        yield return new WaitForSeconds(animspeed);
                    }
                }
                else if (horspeed < 0)
                {
                    for (int i = 0; i < move.Length; i++)
                    {
                        if (horspeed >= 0)
                        {
                            break;
                        }
                        rsprite.sprite = move[i];
                        yield return new WaitForSeconds(animspeed);
                    }
                }
            }
            else
            {
                if (horspeed > 0)
                {
                    rsprite.flipX = false;
                }
                else if (horspeed < 0)
                {
                    rsprite.flipX = true;
                }
                if (vermove() && !jumpd)
                {
                    for (int i = 0; i < jump.Length / 2; i++)
                    {
                        if (!vermove())
                        {
                            break;
                        }
                        rsprite.sprite = jump[i];
                        yield return new WaitForSeconds(animspeed);
                    }
                }
                else if(!vermove() && !jumpd)
                {
                    for (int i = jump.Length / 2; i < jump.Length - 1; i++)
                    {
                        if (jumpd)
                        {
                            break;
                        }
                        rsprite.sprite = jump[i];
                        yield return new WaitForSeconds(animspeed);
                    }
                    jumpd = true;
                }
                else
                {
                    while (!ground())
                    {
                        yield return null;
                    }
                    rsprite.sprite = jump[jump.Length-1];
                    jumpd = false;
                }
            }
            yield return null;
        }
        yield return null;
    }
}
