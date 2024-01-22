using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

namespace _Project.Scripts
{
    public class GameObjectSwitcher : MonoBehaviour
    {
        [SerializeField] private VisualEffect[] visualEffects;
        [SerializeField] private Button button;

        private int _currentGameObjectIndex = 0;

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (visualEffects == null || visualEffects.Length == 0)
            {
                return;
            }

            var current = visualEffects[_currentGameObjectIndex];

            current.gameObject.SetActive(false);
            current.Stop();
            current.Reinit(); // This is a workaround for a feature in the VisualEffect component that causes the particles count (visualEffect.aliveParticleCount) to be incorrect after a Stop() call or disabling the game object.

            _currentGameObjectIndex++;
            _currentGameObjectIndex %= visualEffects.Length;

            var next = visualEffects[_currentGameObjectIndex];
            next.gameObject.SetActive(true);
            next.Play();
        }
    }
}