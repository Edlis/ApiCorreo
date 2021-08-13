using MassTransit;
using Mensajes;
using Modelos.Conn;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class Consumidor : IConsumer<Correo>
    {
        public readonly SMTPConfiguracionModelo _smtp;
        public Consumidor(SMTPConfiguracionModelo smtp) {
            _smtp = smtp;
        }

        public Task Consume(ConsumeContext<Correo> context)
        {
            var correo = context.Message;
            clsCorreo email = new clsCorreo(_smtp);
            email.Enviar(correo);

            return Task.CompletedTask;
        }
    }
}
