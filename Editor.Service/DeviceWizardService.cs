using Editor.Service.Interfaces;

namespace Editor.Service
{
    public class DeviceWizardService : IDeviceWizardService
    {
        public int CurrentStep { get; set; } = 0;
        public void NextStep()
        {
            CurrentStep++;
        }
        public void PreviousStep()
        {
            if (CurrentStep > 0) CurrentStep--;
        }
    }
}
