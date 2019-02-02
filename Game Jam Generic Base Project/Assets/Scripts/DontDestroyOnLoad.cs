using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

    public string tag_name;
    public bool have_jumped = false;

    void Awake()
    {
        SceneManager.activeSceneManager += OnSceneChanged;
        
        if (!have_jumped)
        {
            Gameobject[] this_objects = GameObject.FindGameObjectsWithTag(tag_name);

            if (objs.Length > 1)
            {
                Destroy(this.gameobject);
            }

       }

        DontDestroyOnLoad(this);
    }

    void OnSceneChanged()
    {
        this.have_jumped = true;
    }
}
