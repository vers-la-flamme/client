using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_logic : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        var head = transform.Find("head");
        head.gameObject.SetActive(false);
        var blow = transform.Find("blow");
        blow.gameObject.SetActive(true);
        Invoke("DelayedDestroy", 1.0f);
    }

    void DelayedDestroy()
    {
        Destroy(transform.gameObject);
    }
}
