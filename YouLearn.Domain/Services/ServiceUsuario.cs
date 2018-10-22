using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null) {
                AddNotification("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
                return null;
            }

            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);


            Email email = new Email(request.Email);

            Usuario usuario = new Usuario(nome, email, request.Senha);
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = request.Senha;

            AddNotifications(nome, email, usuario);


            //Validações
        
            if (usuario.Senha.Length <= 3)
            {
                throw new Exception("Senha deve ter no mínimo 3 validações");
            }

            if (this.IsInvalid() == true) {
                return null;
            }

            //Persiste no Banco
            //AdicionarUsuarioResponse response =  new RepositoryUsuario().Salvar(usuario);

            //return response;

            return new AdicionarUsuarioResponse(Guid.NewGuid());

        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
