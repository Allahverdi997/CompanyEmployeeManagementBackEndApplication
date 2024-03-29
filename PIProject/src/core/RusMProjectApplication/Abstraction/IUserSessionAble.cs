﻿using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction
{
    public interface IUserSessionAble
    {
        public string SecretKey { get; set; }
        public string AuthToken { get; set; }
        public User User { get; set; }
    }
}
