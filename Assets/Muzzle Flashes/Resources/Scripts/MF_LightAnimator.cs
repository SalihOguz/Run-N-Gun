using UnityEngine;

// ReSharper disable once CheckNamespace
namespace QFX.MF
{
    [RequireComponent(typeof(Light))]
    public class MF_LightAnimator : MonoBehaviour
    {
        public AnimationCurve LightAnimationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public float ValueMultiplier = 1f;
        public float TimeMultiplier = 1f;

        private float _startedTime;
        private bool _isEnabled;

        private Light _light;

        private void Awake()
        {
            _light = GetComponent<Light>();
            _light.intensity = LightAnimationCurve.Evaluate(0);
        }

        private void OnEnable()
        {
            _startedTime = Time.time;
            _isEnabled = true;
        }

        private void OnDisable()
        {
            _isEnabled = false;
        }

        private void Update()
        {
            if (!_isEnabled)
                return;

            var time = (Time.time - _startedTime) / TimeMultiplier;

            if (time > TimeMultiplier)
                _startedTime = Time.time;

            var curveValue = LightAnimationCurve.Evaluate(time) * ValueMultiplier;

            _light.intensity = curveValue;
        }
    }
}
