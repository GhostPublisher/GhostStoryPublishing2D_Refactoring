using System;

namespace GameSystems.Entities
{
    // Unity GameObject는 Model, View, GameFlow, Service 등을 하나로 모아서 관리하는 경향이 있습니다.
    // 이곳에서는 Model과 View의 역할을 모아서 관리하는 것까지 책임을 줄 생각입니다.

    // 기본적으로 Entity의 Type을 Key 사용하여 관리됩니다.

    // GameObject들은 그룹으로 관리될 때 효과적인 경우가 많습니다.    
    // Type을 통하여 그룹을 구분한 후, EntityID를 통하여 그룹 안의 객체를 구분하여 접근합니다.
    public interface IEntity
    {
        public Type EntityType { get; }
        public string EntityID { get; }
    }

/*    // GameObject들은 그룹으로 관리될 때 효과적인 경우가 많습니다.
    // EntityID를 통하여 그룹 안의 객체를 구분하여 접근합니다.
    public interface IEntityGroup
    {
        public string EntityID { get; }
    }*/

    // IEntityModel은 Model의 책임을 수행하는 것을 보여주기 위해 존재합니다.
    // 실제로 사용되는 경우가 없을 수도 있습니다.
    public interface IEntityModel { }

    // IEntityView은 View의 책임을 수행하는 것을 보여주기 위해 존재합니다.
    // 실제로 사용되는 경우가 없을 수도 있습니다.
    public interface IEntityView { }
}