namespace Helpdesk.Classes
{
    public class ValidacaoException : HelpdeskException
    {
        private string campo;

        public ValidacaoException(string campo, string mensagem) : base(campo + ": " + mensagem)
        {
            this.campo = campo;
        }

        public string Campo
        {
            get { return campo; }
        }
    }
}
