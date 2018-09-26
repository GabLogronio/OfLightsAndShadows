using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ShadowController : GenericPlayerController
{
    // Update is called once per frame
    void Update()
    {
        /*if (rb.velocity.magnitude > 0.1f) agent.enabled = false;
        else agent.enabled = true;*/


        if (IsGrounded())
        {
            if (Input.GetMouseButtonDown(1) && IsSelected)
            {
                agent.enabled = true;
                Move();

            }

            if (Input.GetKeyDown(KeyCode.Space) && IsSelected)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Q) && IsSelected)
            {
                UseAbility1();
            }

        }

        if (Input.GetKeyDown(KeyCode.W) && IsSelected)
        {
            UseAbility2();
        }

        if (Input.GetKeyDown(KeyCode.E) && IsSelected)
        {
            UseAbility3();
        }

    }

	public override void IsInLight(bool InLight)
	{
		if (InLight) 
		{
		//Take Damage
		}
	}

    protected override void UseAbility1()
    {

        Ability1.GetComponent<GenericAbility>().ActivateAbility();

    }

    protected override void UseAbility2()
    {
		
		Ability2.GetComponent<GenericAbility>().ActivateAbility();

    }

    protected override void UseAbility3()
    {

        Ability3.GetComponent<GenericAbility>().ActivateAbility();

    }
}
