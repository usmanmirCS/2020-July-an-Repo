using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator m_anim;

    private GameObject m_touchingObject;
    private GameObject m_heldObject;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
        {
            m_touchingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_touchingObject = null;
    }

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
            if(m_touchingObject)
            {
                AdvGrab();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                m_heldObject.SendMessage("Released"); //send Released message
                AdvRelease();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && m_heldObject)
        {
            m_heldObject.SendMessage("TriggerDown");
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && m_heldObject)
        {
            m_heldObject.SendMessage("TriggerUp"); //send TriggerUp message
        }

        if (Input.GetKeyDown(KeyCode.Mouse2) && m_heldObject)
        {
            m_heldObject.SendMessage("MenuDown"); //send TriggerUp message
        }
    }

    void AdvGrab()
    {
        m_heldObject = m_touchingObject;

        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = m_heldObject.GetComponent<Rigidbody>();
        fx.breakForce = 2500;
        fx.breakTorque = 2500;

        m_heldObject.transform.SetParent(transform);
    }

    void AdvRelease()
    {
        m_heldObject.transform.SetParent(null);
        Destroy(GetComponent<FixedJoint>());
        m_heldObject = null;
    }

    private void OnJointBreak(float breakForce)
    {
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }



    void Grab()
    {
        m_heldObject = m_touchingObject;
        m_heldObject.transform.SetParent(transform);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Release()
    {
        m_heldObject.transform.SetParent(null);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_heldObject = null;
    }
}
