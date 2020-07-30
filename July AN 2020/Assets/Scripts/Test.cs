using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject prefab;
    float shootForce;
    // Start is called before the first frame update
    int Sum(int x, int y)
    {
        int result = x + y;
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = Instantiate(prefab, transform.position, transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(transform.up * shootForce);
    }
}