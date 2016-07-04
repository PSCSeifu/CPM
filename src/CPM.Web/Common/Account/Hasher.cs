using CPM.Business.Global.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Common.Account
{
    public interface IHasher : IPasswordHasher<CPMUserBM>
    {
    }

    public class Hasher : PasswordHasher<CPMUserBM>, IHasher
    {
        public override PasswordVerificationResult VerifyHashedPassword(CPMUserBM user, string hashedPassword, string providedPassword)
        {
            PasswordVerificationResult isVerified = PasswordVerificationResult.Failed;
            try
            {
                isVerified = base.VerifyHashedPassword(user, hashedPassword, providedPassword);
            }
            catch (Exception)
            {
                // Check if password is okay and rehash the password if it is
                isVerified = (Encryptor.EncryptOneWay(providedPassword) == hashedPassword) ? PasswordVerificationResult.SuccessRehashNeeded : PasswordVerificationResult.Failed;
            }

            return isVerified;
        }
    }
}
