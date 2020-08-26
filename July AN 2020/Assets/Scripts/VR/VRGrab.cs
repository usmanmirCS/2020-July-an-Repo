using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public string m_gripName;
    private bool m_gripHeld;

    public Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(m_gripName) > 0.5f && m_gripHeld == false)
        {
            m_gripHeld = true;
            m_anim.SetBool("isGrabbing", true);
        }
        else if(Input.GetAxis(m_gripName) < 0.5f && m_gripHeld == true)
        {
            m_gripHeld = false;
            m_anim.SetBool("isGrabbing", false);
        }
    }
}
