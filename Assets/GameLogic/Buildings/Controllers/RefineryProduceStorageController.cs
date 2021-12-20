namespace GameLogic.Manufacture
{
    public interface IRefineryProduceStorageController
    {
        
    }
    public class RefineryProduceStorageController : IRefineryProduceStorageController
    {
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;
        private readonly IRefineryProduceStorageView refineryProduceStorageView;
        private readonly IBuildingClicable buildingClicable;


        public RefineryProduceStorageController(IRefineryProduceStorageModel refineryProduceStorageModel,
            IRefineryProduceStorageView refineryProduceStorageView, IBuildingClicable buildingClicable)
        {
            this.refineryProduceStorageModel = refineryProduceStorageModel;
            this.refineryProduceStorageView = refineryProduceStorageView;
            this.buildingClicable = buildingClicable;

            buildingClicable.OnClick += OnClick;

            Init();
        }

        private void OnClick()
        {
            throw new System.NotImplementedException();
        }

        private void Init()
        {
            refineryProduceStorageView.ProduceResources = 
                refineryProduceStorageModel.ProduceResources;
        }
    }
}