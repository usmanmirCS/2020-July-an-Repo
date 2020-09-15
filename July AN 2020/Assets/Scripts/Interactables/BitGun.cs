using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : MonoBehaviour
{
    public GameObject m_prefabBit;
    public Transform m_bitSpawn;
    public float m_shootForce;

    void TriggerDown()
    {
        GameObject bit = Instantiate(m_prefabBit, m_bitSpawn.position, m_bitSpawn.rotation);
        bit.GetComponent<Rigidbody>().AddForce(m_bitSpawn.forward * m_shootForce);
        Destroy(bit, 5);
    }
}