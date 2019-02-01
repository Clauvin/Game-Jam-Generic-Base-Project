using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupportV4Jam
{

public class PlayTimedSounds : MonoBehaviour
{

    public AudioSource[] sound_list_to_play;
    public bool[] play_once_or_repeat_it;
    private bool[] played_once;
    public float[] when_sound_starts_playing;
    public float[] when_sound_ends_playing;

    public float time;

    // Use this for initialization
    void Start()
    {
        played_once = new bool[play_once_or_repeat_it.Length];
        for (int i = 0; i < played_once.Length; i++)
        {
            played_once[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sound_list_to_play.GetLength(0); i++)
        {
            PlayIfItsTime(i);
        }
        UpdateTime();
    }

    void UpdateTime()
    {
        time += Time.deltaTime;
    }

    void PlayIfItsTime(int i)
    {
        if ((time >= when_sound_starts_playing[i]) && (play_once_or_repeat_it[i]))
        {

            if (!played_once[i])
            {
                sound_list_to_play[i].enabled = true;
                sound_list_to_play[i].Play();
                played_once[i] = true;
            }
        }
        else if ((time >= when_sound_starts_playing[i]) && (time <= when_sound_ends_playing[i]) &&
                    !play_once_or_repeat_it[i])
        {
            Debug.Log(i + " - " + sound_list_to_play[i].isPlaying);
            if (!sound_list_to_play[i].isPlaying)
            {
                sound_list_to_play[i].enabled = true;
                sound_list_to_play[i].Play();
                Debug.Log(sound_list_to_play[i].isPlaying);
            }
        }
        else if (!play_once_or_repeat_it[i])
        {
            if (sound_list_to_play[i].isPlaying)
            {
                Debug.Log(time);
                sound_list_to_play[i].Stop();
                sound_list_to_play[i].enabled = false;
            }
        }
    }
}


}

