using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

    private Text FPSText;
    float deltaTime = 0.0f;

    private void Start()
    {
        FPSText = GetComponent<Text>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float fps = 1.0f / deltaTime;

        FPSText.text = "FPS " + System.Math.Round(fps, 1); ;

    }

}
