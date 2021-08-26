using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Rankable : MonoBehaviour, IComparable<Rankable>
{
    public int CompareTo(Rankable other)
    {
        return other.transform.position.z.CompareTo(transform.position.z);
    }
}
