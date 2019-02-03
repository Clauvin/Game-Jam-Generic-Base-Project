using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSpecificScene : MonoBehaviour {

    public AbstractConditionToLoadScene condition_to_load_scene;
    public SupportV4Jam.Game_Scenes qual_cena;
    public bool time_to_load_scene;

    // Use this for initialization
    void Start () {
		if (condition_to_load_scene == null)
        {
            condition_to_load_scene = GetComponent<AbstractConditionToLoadScene>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        IsTimeToLoadScene();

		if (time_to_load_scene)
        {
            LoadTheScene();
        }
	}

    public void IsTimeToLoadScene()
    {
        time_to_load_scene = condition_to_load_scene.ConditionToLoadHasBeenFulfilled();
    }

    public void LoadTheScene()
    {
        SupportV4Jam.LoadScene.Load((int)qual_cena);
    }
}
