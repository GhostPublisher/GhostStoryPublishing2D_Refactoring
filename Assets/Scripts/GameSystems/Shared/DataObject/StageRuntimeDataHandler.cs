using Foundations.LazyReferenceRegistry;

namespace GameSystems.Shared.DataObject
{
    public interface IStageRuntimeValueObject
    {
        public int StageID { get; set; }
    }

    public class StageRuntimeValueObject : IReferenceLink, IStageRuntimeValueObject
    {
        private int stageID;

        public int StageID { get => stageID; set => stageID = value; }
    }
}