using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class GenericPlayerController : MonoBehaviour {

    public Camera cam;
    public GameObject OtherCharacter;
    public GameObject Crystal;
    public LayerMask GroundLayer;

    public GameObject UI;

    public GenericAbility Ability1, Ability2, Ability3;

    [Header("Control Parameters")]
    public float JumpHeight;
    public float JumpLength;

    protected Rigidbody rb;
    protected NavMeshAgent agent;
    protected CapsuleCollider CapsuleColl;
    protected bool IsSelected = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        CapsuleColl = GetComponent<CapsuleCollider>();
    }

    protected void Move()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    protected void Jump()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.enabled = false;
            Vector3 JumpDirection = new Vector3((hit.point.x - transform.position.x), 0, (hit.point.z - transform.position.z));
            if (JumpDirection.magnitude > JumpLength) JumpDirection = JumpDirection.normalized * JumpLength;
            rb.velocity = new Vector3(JumpDirection.x, JumpHeight, JumpDirection.z);
        }
    }

    protected bool IsGrounded()
    {
        return Physics.CheckCapsule(CapsuleColl.bounds.center, new Vector3(CapsuleColl.bounds.center.x, CapsuleColl.bounds.min.y, CapsuleColl.bounds.center.z), CapsuleColl.radius * 0.9f, GroundLayer);
    }

    public void SetSelected(bool SelectedStatus, bool SwitchOther)
    {
        IsSelected = SelectedStatus;
        if (IsSelected) UI.GetComponent<UIName>().Selected(true);
        else UI.GetComponent<UIName>().Selected(false);
        Crystal.GetComponent<Crystal>().SetRotating(SelectedStatus);
        if(SwitchOther) OtherCharacter.GetComponent<GenericPlayerController>().SetSelected(!SelectedStatus, false);
    }

    public bool GetSelected()
    {
        return IsSelected;
    }

    public GameObject GetOtherCharacter()
    {
        return OtherCharacter;
    }

    abstract public void IsInLight(bool InLight);

    abstract protected void UseAbility1();

    abstract protected void UseAbility2();

    abstract protected void UseAbility3();

}
