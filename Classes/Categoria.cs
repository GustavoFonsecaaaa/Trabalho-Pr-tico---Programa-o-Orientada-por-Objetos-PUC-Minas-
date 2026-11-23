namespace Helpdesk.Classes;

public class Categoria
{
    private string _nome = string.Empty;
    private string _descricao = string.Empty;

    public int Id { get; }

    public string Nome
    {
        get => _nome;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length < 3 || valor.Length > 40)
                throw new ValidacaoException("Nome da categoria", "deve ter entre 3 e 40 caracteres.");
            _nome = valor;
        }
    }

    public string Descricao
    {
        get => _descricao;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length > 200)
                throw new ValidacaoException("Descricao da categoria", "deve ter no maximo 200 caracteres.");
            _descricao = valor;
        }
    }

    public bool Ativa { get; private set; } = true;

    public Categoria(int id, string nome, string descricao = "")
    {
        if (id <= 0)
            throw new ValidacaoException("Id", "deve ser maior que zero.");
        Id = id;
        Nome = nome;
        Descricao = descricao;
    }

    public void Ativar() => Ativa = true;

    public void Desativar() => Ativa = false;

    public void GarantirQueEstaAtiva()
    {
        if (!Ativa)
            throw new HelpdeskException($"A categoria \"{Nome}\" esta desativada e nao aceita novos chamados.");
    }

    public override string ToString()
    {
        string situacao = Ativa ? "" : " (desativada)";
        string descricao = string.IsNullOrEmpty(Descricao) ? "" : $" - {Descricao}";
        return $"[{Id}] {Nome}{situacao}{descricao}";
    }
}
