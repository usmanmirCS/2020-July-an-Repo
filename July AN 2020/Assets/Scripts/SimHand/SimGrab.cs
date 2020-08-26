using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", true);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", false);
        }
    }
}
