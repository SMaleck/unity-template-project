using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGF.Services.Particles.Config
{
    [CreateAssetMenu(fileName = nameof(ParticleEffectConfig), menuName = UgfConstants.UMenuRoot + nameof(ParticleEffectConfig))]
    public class ParticleEffectConfig : ScriptableObject
    {
        [Serializable]
        private class ParticleEffectConfigItem
        {
            [SerializeField] private ParticleEffectType _particleEffectType;
            public ParticleEffectType ParticleEffectType => _particleEffectType;

            [SerializeField] private ParticlePoolItem _particlePoolItemPrefab;
            public ParticlePoolItem ParticlePoolItemPrefab => _particlePoolItemPrefab;
        }

        [SerializeField] private List<ParticleEffectConfigItem> _particleEffectConfigItems;

        public ParticlePoolItem GetParticleEffectPrefab(ParticleEffectType particleEffectType)
        {
            return _particleEffectConfigItems
                .First(item => item.ParticleEffectType == particleEffectType)
                .ParticlePoolItemPrefab;
        }
    }
}
