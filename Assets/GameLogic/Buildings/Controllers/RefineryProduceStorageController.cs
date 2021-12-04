namespace GameLogic.Manufacture
{
    public interface IRefineryProduceStorageController
    {
        
    }
    public class RefineryProduceStorageController : IRefineryProduceStorageController
    {
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;
        private readonly IRefineryProduceStorageView refineryProduceStorageView;


        public RefineryProduceStorageController(IRefineryProduceStorageModel refineryProduceStorageModel,
            IRefineryProduceStorageView refineryProduceStorageView)
        {
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            this.refineryProduceStorageView = refineryProduceStorageView;
        }
    }
}