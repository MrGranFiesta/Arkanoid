using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnInstantiate : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    public void Awake()
    {
        GameManager.Instance.AudioManager.PlaySound(clip);    
    }
}
