namespace Helpdesk.Classes;

public class Tecnico : Pessoa
{
    public const int LimiteMinimo = 1;
    public const int LimiteMaximo = 10;

    private string _especialidade = string.Empty;
    private int _limiteDeChamados;
    private int _chamadosEmAtendimento;

    public string Especialidade
    {
        get => _especialidade;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length < 3 || valor.Length > 50)
                throw new ValidacaoException("Especialidade", "deve ter entre 3 e 50 caracteres.");
            _especialidade = valor;
        }
    }

    public int LimiteDeChamados
    {
        get => _limiteDeChamados;
        set
        {
            if (value < LimiteMinimo || value > LimiteMaximo)
                throw new ValidacaoException("Limite de chamados", $"deve estar entre {LimiteMinimo} e {LimiteMaximo}.");
            if (value < _chamadosEmAtendimento)
                throw new ValidacaoException("Limite de chamados",
                    $"o tecnico ja atende {_chamadosEmAtendimento} chamado(s); o limite nao pode ser menor que isso.");
            _limiteDeChamados = value;
        }
    }

    public int ChamadosEmAtendimento => _chamadosEmAtendimento;

    public Tecnico(int id, string nome, string email, string especialidade, int limiteDeChamados = 3)
        : base(id, nome, email)
    {
        Especialidade = especialidade;
        LimiteDeChamados = limiteDeChamados;
    }

    public bool PodeAtender() => _chamadosEmAtendimento < _limiteDeChamados;

    public void AssumirChamado()
    {
        if (!PodeAtender())
            throw new LimiteDeChamadosExcedidoException(Nome, _limiteDeChamados);
        _chamadosEmAtendimento++;
    }

    public void LiberarChamado()
    {
        if (_chamadosEmAtendimento == 0)
            throw new HelpdeskException($"O tecnico {Nome} nao tem chamados em atendimento para liberar.");
        _chamadosEmAtendimento--;
    }

    public override string Papel() => "Tecnico";

    public override string ToString() =>
        $"{base.ToString()} - {Especialidade} - Em atendimento: {_chamadosEmAtendimento}/{_limiteDeChamados}";
}
