﻿using System;
using System.Linq;
using Source.Services.Environment;
using Source.Utilities.Reactive;
using UniRx;
using UnityEngine;
using UtilitiesUniRx.Extensions;
using Zenject;

namespace Source.Utilities.Debug
{
    public class FpsProfiler : AbstractInjectableDisposable, IInitializable, IFpsProfiler
    {
        private readonly IEnvironmentService _environmentService;
        private const float UpdateFrequencySeconds = 0.33f;
        private const int BufferSeconds = 60;

        private float _lastMeasuredTime;
        private int _framesRendered;

        private int _fpsBufferIndex;
        private readonly int[] _fpsBuffer;

        public int CurrentFps { get; private set; }
        public int MinFps { get; private set; }
        public int MaxFps { get; private set; }
        public int AverageFps { get; private set; }

        public FpsProfiler(IEnvironmentService environmentService)
        {
            _environmentService = environmentService;

            _fpsBufferIndex = 0;
            _fpsBuffer = new int[(int)(BufferSeconds / UpdateFrequencySeconds)];
        }

        public void Initialize()
        {
            if (!_environmentService.IsDebug)
            {
                return;
            }

            Observable.EveryUpdate()
                .SubscribeBlind(OnUpdate)
                .AddTo(Disposer);
        }

        private void OnUpdate()
        {
            _framesRendered++;
            var timeDifference = Time.realtimeSinceStartup - _lastMeasuredTime;

            if (timeDifference >= UpdateFrequencySeconds)
            {
                var fps = Math.Round(_framesRendered / timeDifference);
                AddFpsCount((int)fps);

                _framesRendered = 0;
                _lastMeasuredTime = Time.realtimeSinceStartup;
            }
        }

        private void AddFpsCount(int fps)
        {
            _fpsBuffer[_fpsBufferIndex] = fps;
            OnFpsCountAdded(fps);

            _fpsBufferIndex = _fpsBufferIndex >= _fpsBuffer.Length - 1
                ? 0
                : _fpsBufferIndex + 1;
        }

        private void OnFpsCountAdded(int fps)
        {
            var buffer = GetCalculationSafeBuffer();

            CurrentFps = fps;
            MinFps = buffer.Min();
            MaxFps = buffer.Max();
            AverageFps = (int)Math.Round(buffer.Average());
        }

        private int[] GetCalculationSafeBuffer()
        {
            var buffer = _fpsBuffer.Where(e => e > 0).ToArray();
            return buffer.Length > 0 ? buffer : new[] { 0 };
        }
    }
}
