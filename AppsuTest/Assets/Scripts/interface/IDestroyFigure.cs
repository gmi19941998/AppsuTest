using System;
using System.Collections;
using System.Collections.Generic;
using AppsuTest;
using UnityEngine;

public interface IDestroyFigure 
{
    
    // Start is called before the first frame update
    public event Action<Figure> DestroyFigure;
}
