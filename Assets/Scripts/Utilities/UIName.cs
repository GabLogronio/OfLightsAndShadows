using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIName : MonoBehaviour {

    public Vector3 ZoomPosition;

    public void Selected(bool SetSelection)
    {
        if (SetSelection)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            GetComponent<RectTransform>().anchoredPosition = ZoomPosition;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        }

    }
}
