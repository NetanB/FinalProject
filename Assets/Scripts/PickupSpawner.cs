using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BookPrefab;

public void DropItems()
    {
        Instantiate(BookPrefab, transform.position, Quaternion.identity );
    }
}
