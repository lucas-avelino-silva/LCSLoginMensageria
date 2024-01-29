namespace Infra.Mensageria
{
    public interface IMessageBusService
    {
        void Publicar(object data, string routingKey);
    }
}