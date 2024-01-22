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
                .Subscribe(newColor => _renderer.material.color = newColor)
                .AddTo(this);
        }

        private void UpdatePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}