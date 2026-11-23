namespace Helpdesk.Classes
{
    public class Categoria
    {
        private int id;
        private string nome = "";
        private string descricao = "";
        private bool ativa = true;

        public Categoria(int id, string nome, string descricao)
        {
            if (id <= 0)
            {
                throw new ValidacaoException("Id", "deve ser maior que zero.");
            }
            this.id = id;
            Nome = nome;
            Descricao = descricao;
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

                if (value.Length < 3 || value.Length > 40)
                {
                    throw new ValidacaoException("Nome da categoria", "deve ter entre 3 e 40 caracteres.");
                }

                nome = value;
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim();

                if (value.Length > 200)
                {
                    throw new ValidacaoException("Descricao da categoria", "deve ter no maximo 200 caracteres.");
                }

                descricao = value;
            }
        }

        public bool Ativa
        {
            get { return ativa; }
        }

        public void Ativar()
        {
            ativa = true;
        }

        public void Desativar()
        {
            ativa = false;
        }

        public void VerificarSeEstaAtiva()
        {
            if (!ativa)
            {
                throw new HelpdeskException("A categoria " + nome + " esta desativada e nao aceita novos chamados.");
            }
        }

        public override string ToString()
        {
            string texto = "[" + id + "] " + nome;
            if (!ativa)
            {
                texto = texto + " (desativada)";
            }
            if (descricao != "")
            {
                texto = texto + " - " + descricao;
            }
            return texto;
        }
    }
}
