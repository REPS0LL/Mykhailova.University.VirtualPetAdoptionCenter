﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public interface IEmailService
    {
        void SendRegistrationEmail(string email);
    }
}
