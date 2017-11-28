public class PlayerActor : Actor
{

  
    public override void Awake()
    {
        base.Awake();
    }
    public override void StoreData()
    {
        base.StoreData();
    }

    public override  void LoadData()
    {
        base.LoadData();
    }
    public override void ApplyData()
    {
        base.ApplyData();

    }

    private void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    private void OnDisable()
    {

        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
