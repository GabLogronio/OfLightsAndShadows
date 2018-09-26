using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClone : MonoBehaviour {

    public GameObject Explosion;

    public void Set(float Duration, float Range)
    {
        Invoke("Explode", Duration);
    }

    void Explode ()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
