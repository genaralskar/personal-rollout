using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

[CreateAssetMenu]
public class FloatConstant : InputBase, IInput
{

    public float FloatValue = 0;
    
    public override float SetFloat()
    {
        return FloatValue;
    }
}

