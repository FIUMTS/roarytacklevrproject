using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayECM : MonoBehaviour
{
    // Start is called before the first frame update
    private EvercoastPlayer ecmPlayer;

    private void Start()
    {
        ecmPlayer = GetComponent<EvercoastPlayer>();
    }

    public void Play()
    {
        ecmPlayer.Play();
    }

    public void Stop()
    {
        ecmPlayer.Pause();
    }
}
