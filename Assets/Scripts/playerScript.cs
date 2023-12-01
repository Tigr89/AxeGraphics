using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float pSpeed;

    //Sprite stuff
    private SpriteRenderer sRenderer;
    public Sprite[] runAnimation;
    private int imageIndex = 0;

    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        idleBehaviour();
        horizontalMovement();
    }

    private void idleBehaviour()
    {

    }
    private void horizontalMovement()
    {
        float _vertSpeed = Input.GetAxis("Vertical");
        float _horSpeed = Input.GetAxis("Horizontal");

        //Move left and right
        transform.Translate(Vector3.right * pSpeed * _horSpeed * Time.deltaTime);

        //playerAnimation
        for(int i = 0; i < runAnimation.Length; i++)
        {
            sRenderer.sprite = runAnimation[i];

        }

        if(Time.time > coolDown)
        {
            
        }
    }
}
