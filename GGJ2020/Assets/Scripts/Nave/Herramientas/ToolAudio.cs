using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private ActiveTool tool;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();

        if (tool == null)
        {
            tool = this.GetComponent<ActiveTool>();
        }

        tool.e_InUse += UpdateAudio;

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
