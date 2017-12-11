public class DoorActor : Actor
{
    private Doors m_Door;
    int isDoorOpen;

    public override void Awake()
    {
        base.Awake();
        m_Door = GetComponent<Doors>();
    }
    public override void StoreData()
    {
        base.StoreData();
      
        isDoorOpen = m_Door.isDoorOpen ? 1 : 0;
    }


    public override void LoadData()
    {

        base.LoadData();
        int status = isDoorOpen;
        if (status == 0)
            m_Door.isDoorOpen = false;
        else
            m_Door.isDoorOpen = true;


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
