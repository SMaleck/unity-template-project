using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGF.Util.Mono;
using UnityEngine;

namespace UGF.Services.Audio
{
    public class AudioSourceItem : AbstractDisposableMonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
    }
}
