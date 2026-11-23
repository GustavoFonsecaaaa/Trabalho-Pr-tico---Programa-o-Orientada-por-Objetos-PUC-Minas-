namespace Helpdesk.Classes;

public class ValidacaoException : HelpdeskException
{
    public string Campo { get; }

    public ValidacaoException(string campo, string mensagem)
        : base($"{campo}: {mensagem}")
    {
        Campo = campo;
    }
}
