namespace Helpdesk.Classes
{
    public abstract class Pessoa
    {
        private int id;
        private string nome = "";
        private string email = "";

        public Pessoa(int id, string nome, string email)
        {
            if (id <= 0)
            {
                throw new ValidacaoException("Id", "deve ser maior que zero.");
            }
            this.id = id;
            Nome = nome;
            Email = email;
        }

        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim();

                if (value.Length < 3 || value.Length > 80)
                {
                    throw new ValidacaoException("Nome", "deve ter entre 3 e 80 caracteres.");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != ' ')
                    {
                        throw new ValidacaoException("Nome", "deve conter apenas letras e espacos.");
                    }
                }

                nome = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim().ToLower();

                int posicaoArroba = value.IndexOf('@');
                int posicaoPonto = value.LastIndexOf('.');

                if (value.Contains(" ") || posicaoArroba < 1 || posicaoPonto < posicaoArroba + 2 || posicaoPonto == value.Length - 1)
                {
                    throw new ValidacaoException("E-mail", "formato invalido (exemplo: nome@empresa.com).");
                }

                email = value;
            }
        }

        public abstract string Papel();

        public override string ToString()
        {
            return "[" + id + "] " + nome + " (" + Papel() + ") - " + email;
        }
    }
}
