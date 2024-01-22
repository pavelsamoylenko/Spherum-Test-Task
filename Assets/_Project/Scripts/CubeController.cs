using UnityEngine;

namespace _Project.Scripts
{
    public class CubeController : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private Color initialColor;

        [Header("Dependencies")]
        [SerializeField] private CubeView cubeView;
        [SerializeField] private ParticleController particleController;

        public CubeModel Model { get; private set; }

        public ParticleController ParticleController => particleController;

        private void Awake()
        {
            var initialPosition = cubeView.transform.position;
            Model = new CubeModel(initialPosition, initialColor);
            cubeView.SetModel(Model);
        }
    

        public void Move(Vector3 direction)
        {
            var newPosition = Model.Position.Value + direction * Time.deltaTime;
            Model.Position.Value = newPosition;
        }
    }
}