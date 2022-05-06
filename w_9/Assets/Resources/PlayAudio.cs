using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource effect;

    private void OnCollisionEnter(Collision collision)
    {
        effect.Play();
    }
}
