using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.VFX;

namespace _Project.Scripts
{
    public class GameObjectSwitcher : MonoBehaviour
    {
        [FormerlySerializedAs("gameObjects")] [SerializeField] private VisualEffect[] visualEffects;
        [SerializeField] private Button button;

        private int currentGameObjectIndex = 0;

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if(visualEffects == null) return;
            if(visualEffects.Length == 0) return;
            var current = visualEffects[currentGameObjectIndex];
            current.gameObject.SetActive(false);
            current.Stop();
            current.Reinit();
            currentGameObjectIndex++;
            currentGameObjectIndex %= visualEffects.Length;
            var next = visualEffects[currentGameObjectIndex];
            next.gameObject.SetActive(true);
            next.Play();
        }
    }
}