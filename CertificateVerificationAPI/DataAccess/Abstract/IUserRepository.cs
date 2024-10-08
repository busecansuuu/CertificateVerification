﻿using CertificateVerificationAPI.Entities;

namespace CertificateVerificationAPI.DataAccess.Abstract
{
    public interface IUserRepository:IGenericRepository<User>
    {
        User GetByEmail(string email);
    }
}
