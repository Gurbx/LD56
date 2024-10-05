using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform[] pathPoints;
        [SerializeField] private Transform mobSpawnPoint;

        public List<Vector3> PathCoords => pathPoints.Select(point => point.position).ToList();
        public Vector3 MobSpawnPoint => mobSpawnPoint.position;
    }
}