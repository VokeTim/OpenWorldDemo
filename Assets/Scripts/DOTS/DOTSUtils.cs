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

        /// <summary>
        /// 创建一个实体管理者，因为释放缓存会连同管理者一起销毁，所以需要实时创建管理者
        /// </summary>
        /// <returns></returns>
        public static EntityManager CreateEnityManagr() {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            return entityManager;
        }

        /// <summary>
        /// 根据数据类型来查询符合条件的实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static NativeArray<Entity> QueryEntitiesArrInGameObject<T>() where T : IComponentData 
        {
            EntityManager entityManager=CreateEnityManagr();
            var entityQuery = entityManager.CreateEntityQuery(ComponentType.ReadWrite<T>());
            var entityArray = entityQuery.ToEntityArray(Allocator.TempJob);
            return entityArray;
        }

        /// <summary>
        /// 释放内存，一般用于检索后
        /// </summary>
        /// <param name="entityArray"></param>
        public static void DisposeEntitiesArray(NativeArray<Entity> entityArray) 
        {
            entityArray.Dispose();
        }
    }
}