using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MatricesTest : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private Vector3 scalingVector;
    [SerializeField] private int points;
    [SerializeField] private float radius;
    private List<Vector3> _positions = new List<Vector3>();

    private void OnValidate()
    {
        _positions.Clear();

        //var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(rotationVector), scalingVector);

        for (int i = 0; i < points; i++)
        {
            float ratio = (float)i / (float)points;
            ratio *= 2 * math.PI;
            _positions.Add(new Vector3(math.sin(ratio), 0, math.cos(ratio)) * radius);
            Debug.Log($"point {i} with ratio {ratio} sin {math.sin(ratio)} cos {math.cos(ratio)}");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < _positions.Count; i++)
        {
            var rotation = Quaternion.Euler(rotationVector) * _positions[i];
            Gizmos.DrawWireSphere(rotation, 1f);
            Gizmos.DrawRay(transform.position, _positions[i]);
        }
    }
}
