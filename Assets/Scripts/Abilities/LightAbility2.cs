using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbility2 : GenericAbility
{

    private SphereCollider coll;
    public float Range;
    public float PushForce;

    void Start()
    {
        coll = GetComponent<SphereCollider>();
        coll.radius = Range;
        coll.enabled = false;
    }

    public override void ActivateAbility()
    {
        if (timer >= cooldown)
        {
            coll.enabled = true;
            timer = 0f;
            Invoke("Deactivate", duration);

        }
    }

    private void Deactivate()
    {
        coll.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11) //lights
        {
            //Turn Off
        }
        else if (other.gameObject.layer == 12) // enemies
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - other.gameObject.transform.position) * PushForce, ForceMode.Impulse);
        }
    }

}
