namespace SkyLauncher;
public class PanelManager
{
    
    public PanelManager()
    {
        Panels = new List<Panel>();
    }
    public PanelManager(IEnumerable<Panel> panels)
    {
        Panels = panels.ToList();
        ConfigurePanelsErrorMsg(5000);
    }

    /// <summary>
    /// Список панелей, активная из которых должна быть только 1
    /// </summary>
    public List<Panel> Panels { get; set; }
    /// <summary>
    /// Активная отображаемая на данный момент панель
    /// </summary>
    public Panel ActivePanel
    {
        get => Panels.FirstOrDefault(e => e.Visible);
        set
        {
            DisableAllPanels();
            Panels.FirstOrDefault(e => e == value).Visible = true;
        }
    }

    /// <summary>
    /// Скрывает все панели
    /// </summary>
    void DisableAllPanels()
    {
        Panels.ForEach(panel => panel.Visible = false);
    }

    /// <summary>
    /// Устанавливает эвент очистки поля с сообщением ошибки
    /// </summary>
    void ConfigurePanelsErrorMsg(int lifeTime)
    {
        Panels.ForEach(e =>
        {
            e.Controls
            .Cast<Control>()
            .Where(e => e is Label && e.Tag as string == "ErrorMsgLabel")
            .Select(e => e as Label)
            .ToList()
            .ForEach(label =>
            {
                label.Text = "";
                label.TextChanged += async (s, e) =>
                {
                    if (!string.IsNullOrEmpty(label.Text))
                    {
                        await Task.Delay(lifeTime);
                        label.Text = "";
                    }
                };
            });
        });
    }

    /// <summary>
    /// Устанавливает список рабочих панелей
    /// </summary>
    /// <param name="panels"></param>
    public void SetPanels(IEnumerable<Panel> panels)
    {
        Panels = panels.ToList();
        ConfigurePanelsErrorMsg(5000);
    }
    /// <summary>
    /// Добавляет панель
    /// </summary>
    /// <param name="panel"></param>
    public void AddPanel(Panel panel)
    {
        if (!Panels.Contains(panel))
            Panels.Add(panel);
    }
    /// <summary>
    /// Удаляет панель
    /// </summary>
    /// <param name="panel"></param>
    public void RemovePanel(Panel panel)
    {
        if (Panels.Contains(panel))
            Panels.Remove(panel);
    }
}
