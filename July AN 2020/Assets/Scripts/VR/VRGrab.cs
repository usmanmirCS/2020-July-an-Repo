using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public Animator m_anim;

    public string m_menuButtonName;

    public string m_gripName;
    private bool m_gripHeld;

    public string m_triggerName;
    private bool m_triggerHeld;

    private GameObject m_touchingObject;
    private GameObject m_heldObject;

    private Vector3 m_oldPos;
    private Vector3 m_handVelocity;

    private Vector3 m_oldEulerAngles;
    private Vector3 m_handAngularVelocity;
    
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
        m_handVelocity = transform.position - m_oldPos;
        m_oldPos = transform.position;

        m_handAngularVelocity = transform.eulerAngles - m_oldEulerAngles;
        m_oldEulerAngles = transform.eulerAngles;

        if (Input.GetAxis(m_gripName) > 0.5f && m_gripHeld == false)
        {
            m_gripHeld = true;
            m_anim.SetBool("isGrabbing", true);

            if(m_touchingObject)
            {
                AdvGrab();
            }
        }
        else if(Input.GetAxis(m_gripName) < 0.5f && m_gripHeld == true)
        {
            m_gripHeld = false;
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                m_heldObject.SendMessage("Released");
                AdvRelease();
            }
        }

        if (Input.GetAxis(m_triggerName) > 0.5f && m_triggerHeld == false)
        {
            m_triggerHeld = true;
            if (m_heldObject)
            {
                m_heldObject.SendMessage("TriggerDown");
            }
        }
        else if(Input.GetAxis(m_triggerName) < 0.5f && m_triggerHeld == true)
        {
            m_triggerHeld = false;
            if (m_heldObject)
            {
                m_heldObject.SendMessage("TriggerUp");
            }
        }

        if(Input.GetButtonDown(m_menuButtonName) && m_heldObject)
        {
            m_heldObject.SendMessage("MenuDown");
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

        Rigidbody rb = m_heldObject.GetComponent<Rigidbody>();
        rb.velocity = m_handVelocity * 75 / rb.mass;
        rb.angularVelocity = m_handAngularVelocity * 5 / rb.mass;

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
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }
}
