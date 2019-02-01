using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreditUpAndGoBackToMainMenu : MonoBehaviour {

    public float y_velocity_per_frame;
    public float position_to_trigger_main_menu_loading;
    private float gambiarra = 138;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveUp();
        TriggerToLoadMainMenu();
    }

    void MoveUp()
    {
        GetComponent<RectTransform>().Translate(new Vector3(0, y_velocity_per_frame, 0), Space.World);
    }

    void TriggerToLoadMainMenu()
    {
        if (GetComponent<RectTransform>().position.y >= position_to_trigger_main_menu_loading + gambiarra)
        {
            SupportV4Jam.LoadScene.LoadMainScreen();
        }
    }
}
