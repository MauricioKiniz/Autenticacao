using System;
using System.Collections.Generic;
using System.Text;

namespace MKSistemas.MicrosServico.Autenticacao.Dominio.Usuarios
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

        public bool Autenticado()
        {
            return true;
        }

        public static Usuario Create(Guid id, string nome, string senha)
        {
            Usuario usuario = new Usuario(id, nome)
            {
                Senha = senha
            };

            return usuario;
        }
    }
}
