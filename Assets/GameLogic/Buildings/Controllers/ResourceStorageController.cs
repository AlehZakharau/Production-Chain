namespace GameLogic.Manufacture
{
    public interface IProduceController
    {
        
    }
    public class ProduceController : IProduceController
    {
        private readonly IProduceModel produceModel;
        private readonly IProduceView produceView;

        public ProduceController(IProduceModel produceModel,
            IProduceView produceView)
        {
            this.produceModel = produceModel;
            this.produceView = produceView;
            
            produceModel.OnProducingResource += OnProducingResource;
            
        }

        private void OnProducingResource()
        {
            produceView.ResourceAmount = produceModel.ResourceAmount;
        }
    }
}