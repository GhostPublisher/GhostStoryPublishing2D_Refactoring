namespace GameSystems.Domain.Models
{
    public class StageProgressModel : IDomainModel
    {
        public int CurrentStageID { get; private set; }

        public StageProgressModel(int stageID)
        {
            this.CurrentStageID = stageID;
        }

        public void GoToNextStage()
        {
            this.CurrentStageID += 1;
        }

        public void LoadStage(int stageID)
        {
            this.CurrentStageID = stageID;
        }
    }
/*
    // 모든 데이터는 결국 마지막에 '값 형식'으로 존재하게 된다.
    // 이게 정석 같긴한데, struct를 안쓰다보니 너무 비효율적으로 보임.
    // Model의 책임을 한번 더 위임한 것으로 판단되니, 일단 Model에서 처리하고 나중에 분류하는 식으로.
    namespace GameSystems.Domain.ValueObjects
    {
        public struct StageID
        {
            public int Value { get; private set; }
            public StageID(int value = 0)
            {
                this.Value = Math.Max(0, value);
            }

            public StageID Next() => new StageID(Value + 1);
            public StageID EnsureNonNegative() => new(Math.Max(0, Value));
        }
    } 
*/
}