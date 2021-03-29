
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IGeneratorObjects<T>
{

  public  IEnumerator GenerateFigures(T Object,List<T> ObjectsList,int RequiredNumberOfObjects,float DelayOnStart,float Delay,LayerMask Mask);
}
