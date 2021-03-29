using System;
using UnityEngine;

namespace AppsuTest
{
    public abstract class Player : MonoBehaviour
    {
        public abstract event Action<float> UpdateDistanceCount;
        public abstract event Action<int> UpdateScoreCount;
        public abstract event Action<Figure> DestroyFigure;
    }
}

