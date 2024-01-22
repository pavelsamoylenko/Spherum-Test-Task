using UniRx;
using UnityEngine;

namespace _Project.Scripts
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
    
        private CubeModel _model;

        public void SetModel(CubeModel cubeModel)
        {
            _model = cubeModel;
            
            _model.Position
                .Subscribe(UpdatePosition)
                .AddTo(this);

            _model
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