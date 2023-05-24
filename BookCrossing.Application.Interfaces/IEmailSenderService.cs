using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application;
using BookCrossing.Models.Email;

namespace BookCrossing.Application.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmail(Message message);
    }
}
