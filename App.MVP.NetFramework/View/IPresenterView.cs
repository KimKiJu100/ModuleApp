namespace App.MVP.NetFramework.View
{
    public interface IPresenterView
    {
        bool Visible { get; set; }
        bool IsDisposed { get; }
        void PresenterInjection(object presenter);
        void Show();
    }
}
