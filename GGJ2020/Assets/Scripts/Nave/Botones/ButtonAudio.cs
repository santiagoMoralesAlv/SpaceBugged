using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private ActiveButton button;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();

        if (button == null)
        {
            button = this.GetComponent<ActiveButton>();
        }

        button.e_UpdateState += UpdateAudio;

    }

    private void UpdateAudio(bool value)
    {
        if (value)
        {
            source.Play();
        }
        else
        {
            source.Stop();
        }
    }
}
