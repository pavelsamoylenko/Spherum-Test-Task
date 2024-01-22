using UniRx;
using UnityEngine;

namespace _Project.Scripts
{
    public class CubeModel
    {
        public ReactiveProperty<Vector3> Position { get; private set; }
        public ReactiveProperty<Color> Color { get; private set; }

        public CubeModel(Vector3 initialPosition, Color initialColor)
        {
            Position = new ReactiveProperty<Vector3>(initialPosition);
            Color = new ReactiveProperty<Color>(initialColor);
        }
    }
}