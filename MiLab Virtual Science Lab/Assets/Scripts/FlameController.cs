using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    public ParticleSystem flame;
    public void adjustFlame(float val)
    {
        var main = flame.main;
        main.startLifetime = val;
    }
}
