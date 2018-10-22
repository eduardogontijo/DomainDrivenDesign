using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50, MSG.X0_NOME_DE_X1_A_X2.ToFormat("Primeiro nome", 1, 50))
                .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, MSG.X0_NOME_DE_X1_A_X2.ToFormat("Último nome", 1, 50));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
