using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppsuTest
{
    public enum Figures // your custom enumeration
    {
        Square, 
        Hexagon 

    };

    public abstract class Figure : MonoBehaviour
    {
        [SerializeField] public Figures FigureType;
        public Vector2 Scale;
        
    }

}
