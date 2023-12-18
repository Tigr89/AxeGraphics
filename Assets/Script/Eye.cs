using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Animator eyenimator;
    // Start is called before the first frame update
    void Start()
    {
        eyenimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eyenimator.SetBool("isBlinking", true);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            eyenimator.SetBool("isBlinking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            eyenimator.SetBool("LookAround", true);
        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            eyenimator.SetBool("LookAround", false);
        }
    }
}
