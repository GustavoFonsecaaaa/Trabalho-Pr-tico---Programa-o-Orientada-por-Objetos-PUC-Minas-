namespace Helpdesk.Classes
{
    public class Tecnico : Pessoa
    {
        private string especialidade = "";
        private int limiteDeChamados;
        private int chamadosEmAtendimento = 0;

        public Tecnico(int id, string nome, string email, string especialidade, int limiteDeChamados) : base(id, nome, email)
        {
            Especialidade = especialidade;
            LimiteDeChamados = limiteDeChamados;
        }

        public string Especialidade
        {
            get { return especialidade; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                value = value.Trim();

                if (value.Length < 3 || value.Length > 50)
                {
                    throw new ValidacaoException("Especialidade", "deve ter entre 3 e 50 caracteres.");
                }

                especialidade = value;
            }
        }

        public int LimiteDeChamados
        {
            get { return limiteDeChamados; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ValidacaoException("Limite de chamados", "deve estar entre 1 e 10.");
                }

                if (value < chamadosEmAtendimento)
                {
                    throw new ValidacaoException("Limite de chamados", "nao pode ser menor que a quantidade de chamados em atendimento.");
                }

                limiteDeChamados = value;
            }
        }

        public int ChamadosEmAtendimento
        {
            get { return chamadosEmAtendimento; }
        }

        public bool PodeAtender()
        {
            if (chamadosEmAtendimento < limiteDeChamados)
            {
                return true;
            }
            return false;
        }

        public void AssumirChamado()
        {
            if (!PodeAtender())
            {
                throw new LimiteDeChamadosExcedidoException(Nome, limiteDeChamados);
            }
            chamadosEmAtendimento = chamadosEmAtendimento + 1;
        }

        public void LiberarChamado()
        {
            if (chamadosEmAtendimento == 0)
            {
                throw new HelpdeskException("O tecnico " + Nome + " nao tem chamados em atendimento.");
            }
            chamadosEmAtendimento = chamadosEmAtendimento - 1;
        }

        public override string Papel()
        {
            return "Tecnico";
        }

        public override string ToString()
        {
            return base.ToString() + " - " + especialidade + " - Em atendimento: " + chamadosEmAtendimento + "/" + limiteDeChamados;
        }
    }
}
