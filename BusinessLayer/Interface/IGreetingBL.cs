﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        public string GreetingMessage(string? firstName, string? lastName);
        
    }
}
