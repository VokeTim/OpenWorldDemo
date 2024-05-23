using Unity.Collections;
using Unity.Entities;

namespace OpenWorld.DOTS.Utils
{
    /// <summary>
    /// DOTS������
    /// </summary>
    public class DOTSUtils
    {
        // DOTSʵ���������GameObject��������ʹ��
        public static EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        public static EntityManager CreateEnityManagr() {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            return entityManager;
        }

        public static NativeArray<Entity> QueryEntitiesArrInGameObject<T>() where T : IComponentData 
        {
            EntityManager entityManager=CreateEnityManagr();
            var entityQuery = entityManager.CreateEntityQuery(ComponentType.ReadWrite<T>());
            var entityArray = entityQuery.ToEntityArray(Allocator.TempJob);
            return entityArray;
        }

        public static void DisposeEntitiesArray(NativeArray<Entity> entityArray) 
        {
            entityArray.Dispose();
        }
    }
}