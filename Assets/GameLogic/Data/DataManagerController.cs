namespace GameLogic.Data
{
    public class DataManagerController
    {
        private readonly DataManagerModel model;
        private readonly DataManagerView view;
        
        
        public DataManagerController(DataManagerModel model, DataManagerView view)
        {
            this.model = model;
            this.view = view;
            
            
            view.saveDataButton.onClick.AddListener(SaveData);
            view.loadDataButton.onClick.AddListener(model.LoadData);
        }

        private void SaveData()
        {
            model.SaveData();
        }
    }
}