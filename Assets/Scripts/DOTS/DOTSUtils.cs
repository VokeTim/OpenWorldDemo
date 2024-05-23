using Unity.Collections;
using Unity.Entities;

namespace OpenWorld.DOTS.Utils
{
    /// <summary>
    /// DOTS工具类
    /// </summary>
    public class DOTSUtils
    {
        // DOTS实体管理，方便GameObject类来进行使用
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