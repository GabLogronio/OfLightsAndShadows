using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAbility1 : GenericAbility {

    public float Range;

    public override void ActivateAbility()
    {
        if (timer >= cooldown)
        {
            timer = 0f;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(hit.point, transform.position) < Range)
                {
                    transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    transform.parent.gameObject.transform.position = hit.point + Vector3.up;
                    transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
                }
            }
        }
    }

}
