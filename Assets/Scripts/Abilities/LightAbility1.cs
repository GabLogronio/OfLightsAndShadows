using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbility1 : GenericAbility
{

    private SphereCollider coll;

    public float JumpLength;
    public float PushForce;

    void Start()
    {
        coll = GetComponent<SphereCollider>();
        coll.enabled = false;
    }

    public override void ActivateAbility()
    {
        if (timer >= cooldown)
        {
            coll.enabled = true;
            timer = 0f;
            Invoke("Deactivate", duration);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                Vector3 JumpDirection = new Vector3((hit.point.x - transform.position.x), 0, (hit.point.z - transform.position.z));
                if (JumpDirection.magnitude > JumpLength) JumpDirection = JumpDirection.normalized * JumpLength;
                transform.parent.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(JumpDirection.x * 1.5f, 0.5f, JumpDirection.z * 1.5f);
            }
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
            other.gameObject.GetComponent<Rigidbody>().AddForce((other.gameObject.transform.position - transform.position) * PushForce, ForceMode.Impulse);
        }
    }

}
