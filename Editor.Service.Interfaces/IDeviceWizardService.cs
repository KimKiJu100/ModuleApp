namespace Editor.Service.Interfaces
{
    public interface IDeviceWizardService
    {
        int CurrentStep { get; set; }
        void NextStep();
        void PreviousStep();
    }
}
