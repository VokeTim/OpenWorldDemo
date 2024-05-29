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

        /// <summary>
        /// ����һ��ʵ������ߣ���Ϊ�ͷŻ������ͬ������һ�����٣�������Ҫʵʱ����������
        /// </summary>
        /// <returns></returns>
        public static EntityManager CreateEnityManagr() {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            return entityManager;
        }

        /// <summary>
        /// ����������������ѯ����������ʵ�弯��
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
        /// �ͷ��ڴ棬һ�����ڼ�����
        /// </summary>
        /// <param name="entityArray"></param>
        public static void DisposeEntitiesArray(NativeArray<Entity> entityArray) 
        {
            entityArray.Dispose();
        }
    }
}