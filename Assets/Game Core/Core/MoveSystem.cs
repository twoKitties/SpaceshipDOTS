using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class MoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref Translation transformData, in MoveData moveData) =>
        {
            transformData.Value = moveData.Position;
        }).Run();

        return default;
    }
}
