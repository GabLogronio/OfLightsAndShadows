using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbility3 : GenericAbility
{

    private BoxCollider coll;
    public float ChargingTime = 0f;
    public bool Charging = false;
    public float PushForce;
    public float MaxCharge;

    void Start()
    {
        coll = GetComponent<BoxCollider>();
        coll.enabled = false;
    }

    void Update()
    {

        if (timer <= cooldown) timer += Time.deltaTime;

        if (Charging && ChargingTime < MaxCharge)
        {
            ChargingTime += Time.deltaTime;
        }
    }

    public override void ActivateAbility()
    {
        bool Pressed = transform.parent.gameObject.GetComponent<LightController>().AbilityKeyIsPressed();

        if (timer >= cooldown && Pressed)
        {
            ChargingTime = 0f;
            Charging = true;
        }
        else if (timer >= cooldown && !Pressed)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                transform.parent.LookAt(new Vector3 (hit.point.x, transform.position.y, hit.point.z));
                Charging = false;
                coll.enabled = true;
                coll.size = new Vector3(1 + ChargingTime / MaxCharge * 2f, coll.size.y, coll.size.z);
                Invoke("Deactivate", duration);
                timer = 0f;
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
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * PushForce * (1 + ChargingTime / MaxCharge), ForceMode.Impulse);
        }
    }

}
