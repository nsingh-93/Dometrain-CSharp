namespace AdvancedMethods;

// Events are more used in UI applications
public class Events
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class EventSource
    {
        public event EventHandler<MessageEventArgs> SourceChanged;

        public void RaiseEvent(string message)
        {
            SourceChanged?.Invoke(this, new MessageEventArgs(message));
        }
    }

    public static void RunEvents()
    {
        EventSource source = new EventSource();

        // Add new handler
        source.SourceChanged += Source_SourceChanged;

        // Raise the event
        source.RaiseEvent("Hello world");

        // Remove the event
        source.SourceChanged -= Source_SourceChanged;


        // Can chain multiple handlers
        source.SourceChanged += Source_SourceChanged1;
        source.SourceChanged += Source_SourceChanged2;

        source.RaiseEvent("Hello world from Neil");

        source.SourceChanged -= Source_SourceChanged1;
        source.SourceChanged -= Source_SourceChanged2;

        void Source_SourceChanged(object? sender, MessageEventArgs e)
        {
            Console.WriteLine($"Sender: { sender }");
            Console.WriteLine($"Message: { e.Message }");
        }

        void Source_SourceChanged1(object? sender, MessageEventArgs e)
        {
            Console.WriteLine("First handler");
            Console.WriteLine($"Sender: { sender }");
            Console.WriteLine($"Message: { e.Message }");
        }

        void Source_SourceChanged2(object? sender, MessageEventArgs e)
        {
            Console.WriteLine("Second handler");
            Console.WriteLine($"Sender: { sender }");
            Console.WriteLine($"Message: { e.Message }");
        }
    }
}
