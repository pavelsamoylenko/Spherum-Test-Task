using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class DistanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void SetDistanceValue(float distanceInMeters)
        {
            text.text = $"Distance:\n{distanceInMeters:F2} m";
        }
    }
}