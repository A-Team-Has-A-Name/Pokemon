
namespace Pokemon.Client.Interfaces
{
    using Pokemon.Client.UI_Elements.Windows;
    using UI_Elements.Windows.Message;

    interface IWindowQueuer
    {
        void QueueWindow(MessageWindow window);
    }
}
