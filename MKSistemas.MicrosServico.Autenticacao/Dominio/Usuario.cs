using System;
using System.Collections.Generic;
using System.Text;

namespace MKSistemas.MicrosServico.Autenticacao.Dominio
{
    public class Usuario
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Senha { get; private set; }

        private Usuario(Guid Id, string nome)
        {
            Nome = nome;
        }

        public void AlterarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        public static Usuario Create(Guid id, string nome, string senha)
        {
            Usuario usuario = new Usuario(id, nome);
            usuario.Senha = senha;

            return usuario;
        }
    }
}
