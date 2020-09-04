using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoll : MonoBehaviour
{
    public Rigidbody m_diceRB;

    public float m_randomness = 250;
    public float m_torqueRandomness = 500;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomDirection;
            Vector3 randomAngle;

            randomDirection = new Vector3(Random.Range(100, m_randomness), Random.Range(100, m_randomness), Random.Range(100, m_randomness));
            randomAngle = new Vector3(Random.Range(100, m_torqueRandomness), Random.Range(100, m_torqueRandomness), Random.Range(100, m_torqueRandomness));

            m_diceRB.AddForce(randomDirection);
            m_diceRB.AddTorque(randomAngle);
        }
    }
}
