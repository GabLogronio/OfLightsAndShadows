using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public GameObject Explosion;

	void Update () {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Set(float Range, Vector3 Destination)
    {
        transform.LookAt(Destination);
        Invoke("Destroy", Range / speed);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider coll)
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy();
    }

}
