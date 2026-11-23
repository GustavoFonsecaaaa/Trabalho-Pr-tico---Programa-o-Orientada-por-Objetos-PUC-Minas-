namespace Helpdesk.Classes
{
    public class Solicitante : Pessoa
    {
        private string setor = "";
        private string ramal = "";

        public Solicitante(int id, string nome, string email, string setor, string ramal) : base(id, nome, email)
        {
            Setor = setor;
            Ramal = ramal;
        }

        public string Setor
        {
            get { return setor; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim();

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ValidacaoException("Setor", "deve ter entre 2 e 50 caracteres.");
                }

                setor = value;
            }
        }

        public string Ramal
        {
            get { return ramal; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim();

                if (value.Length > 0)
                {
                    if (value.Length < 3 || value.Length > 5)
                    {
                        throw new ValidacaoException("Ramal", "deve ter de 3 a 5 digitos.");
                    }

                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsDigit(value[i]))
                        {
                            throw new ValidacaoException("Ramal", "deve conter apenas numeros.");
                        }
                    }
                }

                ramal = value;
            }
        }

        public override string Papel()
        {
            return "Solicitante";
        }

        public override string ToString()
        {
            string texto = base.ToString() + " - Setor: " + setor;
            if (ramal != "")
            {
                texto = texto + " - Ramal " + ramal;
            }
            return texto;
        }
    }
}
