namespace Helpdesk.Classes;

public class LimiteDeChamadosExcedidoException : HelpdeskException
{
    public LimiteDeChamadosExcedidoException(string nomeTecnico, int limite)
        : base($"O tecnico {nomeTecnico} ja atingiu o limite de {limite} chamado(s) em atendimento.") { }
}
