using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAbility3 : GenericAbility {

    public float Range;
	public GameObject ClonePrefab;
    public bool switched = false;
    private GameObject Clone;

    public override void ActivateAbility()
    {
		if (timer >= cooldown) 
		{
			timer = 0;
            switched = false;
            Clone = Instantiate (ClonePrefab, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Clone.GetComponent<ShadowClone>().Set(duration, Range);
            transform.parent.gameObject.transform.Translate(Vector3.forward * 0.5f);

		} 
		else if (Clone != null && !switched) 
		{
            switched = true;
            Vector3 ClonePosition = Clone.transform.position;
            Clone.transform.position = transform.position + new Vector3(0f, 1f, 0f);

            transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            transform.parent.gameObject.transform.position = ClonePosition + new Vector3(0f, 1f, 0f);
            transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            transform.parent.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(ClonePosition);

        }
    }
}
