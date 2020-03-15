using Unity.Entities;
using UnityEngine;

public class CameraAuthoring : IConvertGameObjectToEntity
{
    [SerializeField] private Camera cam;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //dstManager.add
    }
}
