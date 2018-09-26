using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAbility2 : GenericAbility {

    public float Range;
    public GameObject Projectile;

    public override void ActivateAbility()
    {
        if (timer >= cooldown)
        {
            timer = 0f;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Throw(Range, hit.point);
            }
        }
    }

    private void Throw(float abilityRange, Vector3 Destination)
    {
        GameObject project = Instantiate(Projectile, transform.position + new Vector3 (0f, 0f, 0.5f), Quaternion.identity);
        project.GetComponent<Projectile>().Set(abilityRange, Destination);
    }

}
