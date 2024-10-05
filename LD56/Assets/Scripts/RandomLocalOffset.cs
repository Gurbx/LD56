using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class RandomLocalOffset : MonoBehaviour
    {
        void Start()
        {
            transform.localPosition = new Vector3(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f), 0);
        }
    }
}
