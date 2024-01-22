using UnityEngine;

namespace _Project.Scripts
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private CubeController cube;
        
        private CubeModel _cube2Model;

        private void Update()
        {
            UpdateParticleDirection();
        }

        public void Initialize(CubeModel cube2)
        {
            _cube2Model = cube2;
        }

        private void UpdateParticleDirection()
        {
            if (_cube2Model == null) return;

            var direction = (_cube2Model.Position.Value - cube.Model.Position.Value).normalized;
            
            var shape = particles.shape;
            shape.rotation = Quaternion.LookRotation(direction).eulerAngles;
        }
    }
}