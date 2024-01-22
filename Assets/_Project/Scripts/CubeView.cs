using UniRx;
using UnityEngine;

namespace _Project.Scripts
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
    
        private CubeModel model;

        public void SetModel(CubeModel cubeModel)
        {
            model = cubeModel;
            
            model.Position
                .Subscribe(UpdatePosition)
                .AddTo(this);

            model
                .Color
                .Subscribe(ChangeColor)
                .AddTo(this);
        }

        private void ChangeColor(Color newColor)
        {
            _renderer.material.color = newColor;
        }

        private void UpdatePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}