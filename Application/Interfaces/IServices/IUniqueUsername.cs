﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IUniqueUsername
    {
        Task<string> GenerateUniqueUsername();
        Task<bool> UsernameIsValid(string username);   
    }
}
