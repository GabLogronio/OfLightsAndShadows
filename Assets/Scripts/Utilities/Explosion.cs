using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private SphereCollider coll;
    public float ExplosionRange;
    public float PushForce;

    void Awake()
    {
        coll = GetComponent<SphereCollider>();
        coll.radius = ExplosionRange;
        Invoke("Destroy", 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11) //lights
        {
            //Turn Off
        }
        else if (other.gameObject.layer == 12) // enemies
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((other.gameObject.transform.position - transform.position) * PushForce, ForceMode.Impulse);
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
