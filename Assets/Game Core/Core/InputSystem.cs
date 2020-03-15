using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class InputSystem : JobComponentSystem
{
    private Camera _mainCamera;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
        //var mainCamera = Camera.main;
        var mousePosScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        var ray = _mainCamera.ScreenPointToRay(mousePosScreen);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log($"hit point {hit.point}");
        }

        Entities.ForEach((ref MoveData moveData) =>
        {
            if (Input.GetKey(KeyCode.Mouse0))
                moveData.Position = hit.point;
            else
                moveData.Position = new Vector3(0, 0, 0);
        }).Run();

        return default;
    }
}
