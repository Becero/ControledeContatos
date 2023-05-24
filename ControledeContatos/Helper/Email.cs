namespace ControledeContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public bool Enviar(string email, string assunto, string mensagem)
        {
           try
            {

            }
            catch(SystemException ex) 
            {
                //Gravar log de erro ao enviar e-mail
                return false;

            }
        }
    }
}
