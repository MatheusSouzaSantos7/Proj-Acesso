using System;
using System.Collections.Generic;

namespace Proj._Acesso
{
    public class Ambiente
    {
        private int id;
        private string nome;
        private Queue<Log> logs;

        // Construtor para inicializar os atributos
        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.logs = new Queue<Log>();
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

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        /// <summary>
        /// Registra um log no ambiente, garantindo o limite de 100 ocorrências.
        /// </summary>
        /// <param name="log">O log a ser registrado.</param>
        public void RegistrarLog(Log log)
        {
            if (logs.Count >= 100)
            {
                logs.Dequeue(); // Remove o log mais antigo
            }

            logs.Enqueue(log); // Adiciona o novo log
        }

        /// <summary>
        /// Retorna uma lista com os logs registrados no ambiente.
        /// </summary>
        /// <returns>Lista de logs.</returns>
        public List<Log> GetLogs()
        {
            return new List<Log>(logs);
        }

        // Representação textual do ambiente
        public override string ToString()
        {
            return $"ID: {id}, Nome: {nome}, Logs Registrados: {logs.Count}";
        }
    }
}
