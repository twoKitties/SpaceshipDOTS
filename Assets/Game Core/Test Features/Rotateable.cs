using UnityEngine;

public class Rotateable : MonoBehaviour
{
    [SerializeField] private Vector3 rotateValue;
    [SerializeField] private float speed;

    public void Rotate(Vector3 offset)
    {
        rotateValue.Set(0, rotateValue.y += Time.deltaTime * speed, 0);
        transform.position = Quaternion.Euler(rotateValue) * offset;
    }
}
