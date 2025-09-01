using Foundations.ReferencesHandler;

namespace GameSystems.Shared.DataObject
{
    public class StageRuntimeDataHandler : IDynamicReferenceHandler
    {
        public StageRuntimeData StageRuntimeData;
    }

    public class StageRuntimeData
    {
        public int StageID { get; set; }
    }
}