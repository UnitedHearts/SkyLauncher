namespace SkyLauncher;
public class PanelManager
{
    Panel _activePanel;

    /// <summary>
    /// Активная отображаемая на данный момент панель
    /// </summary>
    public Panel ActivePanel
    {
        get => _activePanel;
        set => ChangePanel(value);
    }

    public PanelManager(IEnumerable<Panel> panels)
    {
        if (panels.Count() == 0) throw new Exception("Нет панелей для рендера");
        _activePanel = panels.ElementAt(0);
        ConfigurePanelsErrorMsg(panels, 5000);
    }

    /// <summary>
    /// Активирует указанную панель
    /// </summary>
    void ChangePanel(Panel target)
    {
        _activePanel.Visible = false;
        _activePanel = target;
        _activePanel.Visible = true;
    }

    /// <summary>
    /// Устанавливает эвент очистки поля с сообщением ошибки
    /// </summary>
    void ConfigurePanelsErrorMsg(IEnumerable<Panel> panels, int lifeTime)
    {
        panels.ToList().ForEach(e =>
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
}
