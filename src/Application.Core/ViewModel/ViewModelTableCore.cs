namespace Application.Core.ViewModel
{
    public abstract class ViewModelTableCore : IDisposable
    {
        ~ViewModelTableCore() => Dispose();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Guid? Id { get; set; }

        public abstract bool IsValid();

        public List<string>? Notifications { get; set; } = new List<string>();

        public void AddNotifications(string mensagem)
        {
            Notifications!.Add(mensagem);
        }
    }
}