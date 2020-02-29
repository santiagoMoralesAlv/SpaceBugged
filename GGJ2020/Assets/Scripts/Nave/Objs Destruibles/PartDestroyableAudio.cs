using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDestroyableAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private PartDestruible part;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();

        if (part == null) {
            part = this.GetComponent<PartDestruible>();
        }

        Ship.Instance.e_UpdateParts += UpdateVolumen;
        
    }

    private void UpdateVolumen() {
        source.volume = (1-part.GetHeal());
    }
}
