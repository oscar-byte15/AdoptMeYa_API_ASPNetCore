namespace GrupoWebBackend.DomainPets.Domain.Services.Communications
{
    public abstract class BaseResponseA
    {
        protected BaseResponseA(bool succces, string message)
        {
            Succces = succces;
            Message = message;
        }

        public bool Succces { get; protected set; }
        public string Message { get; protected set; }
    }
}