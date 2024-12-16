using System;

namespace Proj._Acesso
{
    public class Log
    {
        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        // Construtor para inicializar os atributos
        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            this.dtAcesso = dtAcesso;
            this.usuario = usuario;
            this.tipoAcesso = tipoAcesso;
        }

        // Getter para a Data e Hora do Acesso (apenas leitura)
        public DateTime GetDtAcesso()
        {
            return dtAcesso;
        }

        // Getter para o Usuário (apenas leitura)
        public Usuario GetUsuario()
        {
            return usuario;
        }

        // Getter para o Tipo de Acesso (apenas leitura)
        public bool GetTipoAcesso()
        {
            return tipoAcesso;
        }

        // Representação textual do log
        public override string ToString()
        {
            string statusAcesso = tipoAcesso ? "Autorizado" : "Negado";
            return $"Data: {dtAcesso}, Usuário: {usuario.GetNome()} (ID: {usuario.GetId()}), Acesso: {statusAcesso}";
        }
    }
}
