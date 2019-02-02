using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour {

    public string tag_name;
    public bool have_jumped = false;

    void Awake()
    {        
        if (!have_jumped)
        {
            GameObject[] this_objects = GameObject.FindGameObjectsWithTag(tag_name);

            if (this_objects.Length > 1)
            {
                Destroy(this.gameObject);
            }

       }

        DontDestroyOnLoad(this);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnSceneChanged(Scene previous, Scene actual)
    {
        this.have_jumped = true;
    }
}
