using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject shrapnel;
    public void SpawnShrapnel(Vector3 t_pos)
    {
        Instantiate(shrapnel, t_pos, Quaternion.identity, this.transform);
    }
}
