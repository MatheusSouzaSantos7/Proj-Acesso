using System;
using System.Collections.Generic;

namespace Proj._Acesso
{
    public class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        // Construtor para inicializar os atributos
        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.ambientes = new List<Ambiente>();
        }

        // Getter para o ID (apenas leitura)
        public int GetId()
        {
            return id;
        }

        // Getter e Setter para o Nome
        public string GetNome()
        {
            return nome;
        }

        // Método para obter a lista de ambientes
        public List<Ambiente> GetAmbientes()
        {
            return ambientes;
        }


        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        // Método para conceder permissão de acesso a um ambiente
        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (ambientes.Exists(a => a.GetId() == ambiente.GetId()))
                return false;

            ambientes.Add(ambiente);
            return true;
        }

        // Método para revogar permissão de acesso a um ambiente
        public bool RevogarPermissao(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        // Representação textual do usuário
        public override string ToString()
        {
            return $"ID: {id}, Nome: {nome}, Ambientes: {ambientes.Count}";
        }
    }
}
