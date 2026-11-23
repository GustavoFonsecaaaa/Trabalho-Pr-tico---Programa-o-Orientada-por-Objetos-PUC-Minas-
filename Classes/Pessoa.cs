using System.Text.RegularExpressions;

namespace Helpdesk.Classes;

public abstract class Pessoa
{
    private static readonly Regex FormatoEmail =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    private string _nome = string.Empty;
    private string _email = string.Empty;

    public int Id { get; }

    public string Nome
    {
        get => _nome;
        set
        {
            string valor = (value ?? string.Empty).Trim();
            if (valor.Length < 3 || valor.Length > 80)
                throw new ValidacaoException("Nome", "deve ter entre 3 e 80 caracteres.");
            if (!valor.All(c => char.IsLetter(c) || c == ' '))
                throw new ValidacaoException("Nome", "deve conter apenas letras e espacos.");
            _nome = valor;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            string valor = (value ?? string.Empty).Trim().ToLowerInvariant();
            if (!FormatoEmail.IsMatch(valor))
                throw new ValidacaoException("E-mail", "formato invalido (exemplo: nome@empresa.com).");
            _email = valor;
        }
    }

    protected Pessoa(int id, string nome, string email)
    {
        if (id <= 0)
            throw new ValidacaoException("Id", "deve ser maior que zero.");
        Id = id;
        Nome = nome;
        Email = email;
    }

    public abstract string Papel();

    public override string ToString() => $"[{Id}] {Nome} ({Papel()}) - {Email}";
}
