using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public LayerMask LightsLayer;
    public int LightsRange = 10;

    private Collider[] NearbyLights = new Collider[10];
    private int LightsInRange = 0;

	
	// Update is called once per frame
	void Update () {

        if (!HitByDirectionalLight())
        {
            HitByPointLights();
        }

    }

    private bool HitByPointLights()
    {
        LightsInRange = Physics.OverlapSphereNonAlloc(transform.position, LightsRange, NearbyLights, LightsLayer);

        if (LightsInRange > 0)
        {
            for (int i = 0; i < LightsInRange; i++)
            {
                if (CanSee(NearbyLights[i].gameObject))
                {
                    transform.parent.GetComponent<GenericPlayerController>().IsInLight(true);
                    return true;
                }
            }
        }
        transform.parent.GetComponent<GenericPlayerController>().IsInLight(false);
        return false;
    }

    private bool HitByDirectionalLight()
    {
        RaycastHit AbilityHit;
        Ray AbilityRay = new Ray(transform.position, new Vector3(-2f, 1.5f, 2f));
        if (Physics.Raycast(AbilityRay, out AbilityHit, LightsRange * 5))
        {
            transform.parent.GetComponent<GenericPlayerController>().IsInLight(false);
            return false;
        }
        else
        {
            transform.parent.GetComponent<GenericPlayerController>().IsInLight(true);
            return true;
        }

    }

    private bool CanSee(GameObject target)
    {
        RaycastHit AbilityHit;
        Ray AbilityRay = new Ray(transform.position, target.transform.position - transform.position);
        if (Physics.Raycast(AbilityRay, out AbilityHit, LightsRange))
        {
            if (AbilityHit.collider.gameObject == target)
            {
                return true;
            }
        }
        return false;

    }

    public void SetRotating(bool rotating)
    {

    }
}
