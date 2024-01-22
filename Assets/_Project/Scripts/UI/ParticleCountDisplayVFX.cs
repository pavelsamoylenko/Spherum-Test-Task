using TMPro;
using UnityEngine;
using UnityEngine.VFX;

namespace _Project.Scripts.UI
{
    [ExecuteAlways]
    public class ParticleCountDisplayVFX : MonoBehaviour
    {
        [SerializeField] private VisualEffect[] visualEffect;
        [SerializeField] private TMP_Text particleCountText;

        private void Update()
        {
            if (visualEffect != null && particleCountText != null)
            {
                int count = 0;
                for (var index = 0; index < visualEffect.Length; index++)
                {
                    var vfx = visualEffect[index];
                    if (vfx == null) continue;
                    count += vfx.aliveParticleCount;
                }

                particleCountText.text = "Particles: " + count.ToString();
            }
        }
    }
}