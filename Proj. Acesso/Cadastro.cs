using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proj._Acesso
{
    public class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        // Construtor para inicializar as listas
        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }

        // Adicionar um novo usuário
        public void AdicionarUsuario(Usuario usuario)
        {
            if (usuarios.Exists(u => u.GetId() == usuario.GetId()))
                throw new ArgumentException("Usuário com o mesmo ID já existe.");
            usuarios.Add(usuario);
        }

        // Remover um usuário (apenas se não possuir permissões)
        public bool RemoverUsuario(Usuario usuario)
        {
            var usuarioExistente = usuarios.FirstOrDefault(u => u.GetId() == usuario.GetId());
            if (usuarioExistente != null)
            {
                // Tentativa de revogar permissões de todos os ambientes
                foreach (var ambiente in ambientes)
                {
                    usuarioExistente.RevogarPermissao(ambiente);
                }

                // Após revogar permissões, verifica se foi possível remover
                if (!ambientes.Any(a => usuarioExistente.ConcederPermissao(a)))
                {
                    usuarios.Remove(usuarioExistente);
                    return true;
                }
            }
            return false;
        }


        // Pesquisar usuário por ID
        public Usuario PesquisarUsuario(int id)
        {
            return usuarios.FirstOrDefault(u => u.GetId() == id);
        }

        // Adicionar um novo ambiente
        public void AdicionarAmbiente(Ambiente ambiente)
        {
            if (ambientes.Exists(a => a.GetId() == ambiente.GetId()))
                throw new ArgumentException("Ambiente com o mesmo ID já existe.");
            ambientes.Add(ambiente);
        }

        // Remover um ambiente
        public bool RemoverAmbiente(Ambiente ambiente)
        {
            var ambienteExistente = ambientes.FirstOrDefault(a => a.GetId() == ambiente.GetId());
            if (ambienteExistente != null)
            {
                ambientes.Remove(ambienteExistente);
                return true;
            }
            return false;
        }

        // Pesquisar ambiente por ID
        public Ambiente PesquisarAmbiente(int id)
        {
            return ambientes.FirstOrDefault(a => a.GetId() == id);
        }

        // Carregar dados dos arquivos (download)
        public void Download()
        {
            try
            {
                // Carregar usuários
                if (File.Exists("usuarios.txt"))
                {
                    foreach (var linha in File.ReadAllLines("usuarios.txt"))
                    {
                        var dados = linha.Split(';');
                        var usuario = new Usuario(int.Parse(dados[0]), dados[1]);
                        usuarios.Add(usuario);
                    }
                }

                // Carregar ambientes
                if (File.Exists("ambientes.txt"))
                {
                    foreach (var linha in File.ReadAllLines("ambientes.txt"))
                    {
                        var dados = linha.Split(';');
                        var ambiente = new Ambiente(int.Parse(dados[0]), dados[1]);
                        ambientes.Add(ambiente);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar os dados: {ex.Message}");
            }
        }

        // Salvar dados nos arquivos (upload)
        public void Upload()
        {
            try
            {
                // Salvar usuários
                using (var writer = new StreamWriter("usuarios.txt"))
                {
                    foreach (var usuario in usuarios)
                    {
                        writer.WriteLine($"{usuario.GetId()};{usuario.GetNome()}");
                    }
                }

                // Salvar ambientes
                using (var writer = new StreamWriter("ambientes.txt"))
                {
                    foreach (var ambiente in ambientes)
                    {
                        writer.WriteLine($"{ambiente.GetId()};{ambiente.GetNome()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar os dados: {ex.Message}");
            }
        }
    }
}
