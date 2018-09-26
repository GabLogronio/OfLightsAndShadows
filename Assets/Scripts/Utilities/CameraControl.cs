using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float VerBorderPercentage = 0.1f;
    private float HorBorderPercentage = 0.05f;
    private GameObject LastSelected = null;

    public float CameraSpeed = 7f;

    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKey(KeyCode.Z)) RotateCamera(true);
        else if (Input.GetKey(KeyCode.X)) RotateCamera(false);

		if (Input.GetMouseButtonDown (0)) 
		{
			SelectCharacter ();
		}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }

        if (Input.GetMouseButton(2))
        {
            transform.position = LastSelected.transform.position;
        }

        MoveCamera();

    }

    //TO CHANGE: USE EULER ANGLES
    private void RotateCamera(bool direction) 
    {
        if(direction) transform.Rotate(45f * Vector3.up * Time.deltaTime);
        else transform.Rotate(45f * Vector3.up * Time.deltaTime * -1);

    }

    private void SwitchCharacter()
    {
		if (LastSelected != null && (LastSelected.tag != "Light" || LastSelected.GetComponent<LightController>().AbilityKeyIsPressed()))
		{
			LastSelected.GetComponent<GenericPlayerController>().SetSelected(false, true);
			LastSelected = LastSelected.GetComponent<GenericPlayerController>().GetOtherCharacter();
		}   
    }

	private void SelectCharacter()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			GameObject ObjHit = hit.transform.gameObject;
            if (ObjHit.layer == 9)
            {
				if (LastSelected == null || (LastSelected != null && (LastSelected.tag != "Light" || LastSelected.GetComponent<LightController>().AbilityKeyIsPressed())))
                {
                    ObjHit.GetComponent<GenericPlayerController>().SetSelected(true, true);
                    LastSelected = ObjHit;
                }
            }
        }

	}


    private void MoveCamera()
    {
        //transform.position = ( Light.transform.position + Shadow.transform.position) / 2 ;
        if (Input.mousePosition.y > Screen.height - Screen.height * VerBorderPercentage)
            transform.Translate(Vector3.forward * CameraSpeed * Time.deltaTime);

        if (Input.mousePosition.y < Screen.height * VerBorderPercentage)
            transform.Translate(-Vector3.forward * CameraSpeed * Time.deltaTime);

        if (Input.mousePosition.x > Screen.width - Screen.width * HorBorderPercentage)
            transform.Translate(Vector3.right * CameraSpeed * Time.deltaTime);

        if (Input.mousePosition.x < Screen.width * HorBorderPercentage)
            transform.Translate(-Vector3.right * CameraSpeed * Time.deltaTime);
    }
}
