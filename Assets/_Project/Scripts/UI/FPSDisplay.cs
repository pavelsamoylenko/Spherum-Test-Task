using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text fpsText;
        
        private float deltaTime = 0.0f;
        private float fps = 0.0f;
        private float updateRate = 2.0f;  // Количество обновлений в секунду

        private float timer = 0.0f;

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            timer += Time.unscaledDeltaTime;

            if (timer > 1.0f / updateRate)
            {
                fps = 1.0f / deltaTime;
                fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
                timer = 0;
            }
        }
    }
}