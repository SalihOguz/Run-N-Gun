using UnityEngine;

// ReSharper disable once CheckNamespace
namespace QFX.MF
{
    public class MF_Rotator : MonoBehaviour
    {
        public float RotationSpeed;

        private bool _isEnabled;

        private void OnEnable()
        {
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

            transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        }
    }
}
