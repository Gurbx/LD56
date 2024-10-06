using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int hearts;
        [SerializeField] private int gold;
        [SerializeField] private List<MobData> availableMobs;
        
        [SerializeField] private Transform pathPoints;
        [SerializeField] private Transform towerContainer;

        public int Hearts => hearts;
        public int Gold => gold;
        public  List<MobData> AvailableMobs => availableMobs;
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