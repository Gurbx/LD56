using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform pathPoints;
        [SerializeField] private Transform mobSpawnPoint;
        [SerializeField] private Transform towerContainer;
            
        
        public Vector3 MobSpawnPoint => mobSpawnPoint.position;
        public Transform TowerContainer => towerContainer;

        public List<Vector3> GetPathCoords()
        {
            var coords = new List<Vector3>();
            foreach (Transform point in pathPoints)
            {
                coords.Add(point.position);
            }
            return coords;
        }
    }
}