namespace Helpdesk.Classes;

public class Solicitante : Pessoa
{
    private string _setor = string.Empty;
    private string _ramal = string.Empty;

    public string Setor
    {
        get => _setor;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length < 2 || valor.Length > 50)
                throw new ValidacaoException("Setor", "deve ter entre 2 e 50 caracteres.");
            _setor = valor;
        }
    }

    public string Ramal
    {
        get => _ramal;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length > 0 && (valor.Length < 3 || valor.Length > 5 || !valor.All(char.IsDigit)))
                throw new ValidacaoException("Ramal", "deve ter de 3 a 5 digitos numericos.");
            _ramal = valor;
        }
    }

    public Solicitante(int id, string nome, string email, string setor, string ramal = "")
        : base(id, nome, email)
    {
        Setor = setor;
        Ramal = ramal;
    }

    public override string Papel() => "Solicitante";

    public override string ToString()
    {
        string contato = string.IsNullOrEmpty(Ramal) ? "" : $" - Ramal {Ramal}";
        return $"{base.ToString()} - Setor: {Setor}{contato}";
    }
}
