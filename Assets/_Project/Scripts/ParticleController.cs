using UnityEngine;

namespace _Project.Scripts
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private CubeController cube;
        
        private CubeModel cube2Model;

        private void Update()
        {
            UpdateParticleDirection();
        }

        public void Initialize(CubeModel cube2)
        {
            cube2Model = cube2;
        }

        private void UpdateParticleDirection()
        {
            if (cube2Model == null) return;

            var direction = (cube2Model.Position.Value - cube.Model.Position.Value).normalized;
            
            var shape = particles.shape;
            shape.rotation = Quaternion.LookRotation(direction).eulerAngles;
        }
    }
}