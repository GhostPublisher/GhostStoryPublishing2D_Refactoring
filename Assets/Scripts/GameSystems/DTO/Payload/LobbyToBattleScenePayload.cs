namespace GameSystems.DTO
{
    public interface IPayload { }

    public class LobbyToBattleScenePayload : IPayload
    {
        public int CurrentStageID;
    }
}
