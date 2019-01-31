using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SupportV4Jam;

public class RandomTesting : MonoBehaviour {

    public float value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DoStuff();
	}

    public void DoStuff()
    {
        value += Time.deltaTime;
        SpinTheSkybox.UpdateSkyRotation(value);
    }
}
