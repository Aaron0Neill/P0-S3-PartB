using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrapnelSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject shrapnel;

    public void SpawnOnDestroy(Vector3 t_pos)
    {
        for (int i = 0; i < 3; ++i)
            SpawnShrapnel(t_pos);
    }

    public GameObject SpawnShrapnel(Vector3 t_pos)
    {
        return Instantiate(shrapnel, t_pos, Quaternion.identity, this.transform);
    }
}
