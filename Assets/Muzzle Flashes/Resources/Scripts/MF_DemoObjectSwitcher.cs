using UnityEngine;

// ReSharper disable once CheckNamespace
namespace QFX.MF
{
    public class MF_DemoObjectSwitcher : MonoBehaviour
    {
        public GameObject[] Objects;

        private int _currentIndex;

        private void Awake()
        {
            foreach (var obj in Objects)
                obj.SetActive(false);
            Objects[_currentIndex].SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
                _currentIndex++;
            else if (Input.GetKeyDown(KeyCode.A))
                _currentIndex--;
            else return;

            if (_currentIndex >= Objects.Length)
                _currentIndex = 0;
            else if (_currentIndex < 0)
                _currentIndex = Objects.Length - 1;

            foreach (var obj in Objects)
                obj.SetActive(false);

            Objects[_currentIndex].SetActive(true);
        }
    }
}
