using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericAbility : MonoBehaviour {

    public float cooldown, duration;
    protected float timer = 0f;

	void Update () {

        if (timer <= cooldown) timer += Time.deltaTime;

	}

    abstract public void ActivateAbility();
}
