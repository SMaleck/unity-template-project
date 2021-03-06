﻿using Source.Frameworks.ViewUtils;
using Source.Utilities.Mono;
using UnityEngine;

namespace Source.Frameworks.ViewSystem
{
    public class ClosableView : AbstractDisposableMonoBehaviour
    {
        [Tooltip("Leave blank to use this GameObject")]
        [SerializeField] private GameObject _target;
        private GameObject Target => _target != null ? _target : gameObject;

        [SerializeField] private RxButton _closeButton;
        public IButton CloseButton => _closeButton;

        public void SetIsVisible(bool isVisible)
        {
            Target.SetActive(isVisible);
        }
    }
}
