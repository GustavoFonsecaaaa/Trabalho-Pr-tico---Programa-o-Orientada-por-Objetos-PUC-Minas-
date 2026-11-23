namespace Helpdesk.Classes;

public class HelpdeskException : Exception
{
    public HelpdeskException(string mensagem) : base(mensagem) { }
}
