using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppsuTest
{
    public enum Figures // your custom enumeration
    {
        Square=0, 
        Hexagon 

    };

    public abstract class Figure : MonoBehaviour
    {
        [SerializeField] private Figures FigureType;
        public Vector2 Scale;



    }

}
