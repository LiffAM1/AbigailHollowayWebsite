using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbigailHollowayWebsite.Models
{
    public interface IEmailService
    {
        bool Send(ContactFormModel message);
    }
}
