using System;
using UnityEngine;

namespace Source.Services.Audio
{
    public interface IAudioClipRepository<in T> where T : Enum
    {
        AudioClip GetAudioClip(T id);
    }
}
