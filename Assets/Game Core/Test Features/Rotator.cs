using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Rotateable[] rotateables;
    private Vector3[] offset;

    private void Awake()
    {
        int size = rotateables.Length;
        offset = new Vector3[size];
        for (int i = 0; i < size; i++)
        {
            offset[i] = rotateables[i].transform.position - transform.position;
        }
    }

    private void Update()
    {
        
        for (int i = 0; i < rotateables.Length; i++)
        {
            rotateables[i].Rotate(offset[i]);
        }
    }
}
