using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text fpsText;
        [SerializeField] private float updateRate = 2.0f;  // Количество обновлений в секунду

        private float _deltaTime = 0.0f;
        private float _fps = 0.0f;

        private float _timer = 0.0f;

        void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            _timer += Time.unscaledDeltaTime;

            if (_timer > 1.0f / updateRate)
            {
                _fps = 1.0f / _deltaTime;
                fpsText.text = Mathf.Ceil(_fps).ToString() + " FPS";
                _timer = 0;
            }
        }
    }
}