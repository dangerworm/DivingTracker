using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DataTransferObjects;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class AuthenticationWorkflow
    {
        private readonly DivingTrackerEntities _databaseContext;

        public AuthenticationWorkflow(DivingTrackerEntities databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public DataResult<User> Register(UserRegistrationRequestDto registrationRequest)
        {
            if (!registrationRequest.Password.Equals(registrationRequest.PasswordConfirmation))
            {
                return new DataResult<User>(DataResultType.ValidationError,
                    "The password and confirmation password must be the same.");
            }

            var saltBytes = new byte[128];
            new RNGCryptoServiceProvider().GetBytes(saltBytes);

            var systemLogin = new SystemLogin
            {
                CreatedDate = DateTime.Now,
                EmailAddress = registrationRequest.EmailAddress,
                PasswordHash = Convert.ToBase64String(GetSaltedHash(registrationRequest.Password, saltBytes)),
                PasswordSalt = Convert.ToBase64String(saltBytes),
                EmailConfirmationToken = registrationRequest.ConfirmationToken,
                IsEmailConfirmed = false
            };

            _databaseContext.SystemLogins.Add(systemLogin);
            _databaseContext.SaveChanges();
            if (systemLogin.SystemLoginId == 0)
            {
                return new DataResult<User>(DataResultType.UnableToCreateRecord, "Unable to create system login");
            }

            var user = new User
            {
                CreatedDate = DateTime.Now,
                SystemLoginId = systemLogin.SystemLoginId,
                FirstName = registrationRequest.FirstName,
                Surname = registrationRequest.Surname,
                DateOfBirth = registrationRequest.DateOfBirth,
                SystemRoleId = (int)SystemRoles.Unknown,
                BranchId = 1
            };

            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
            if (user.UserId == 0)
            {
                return new DataResult<User>(DataResultType.UnableToCreateRecord, "Unable to create user");
            }

            return new DataResult<User>(user, new DataResult(DataResultType.Success, "Successfully created user"));
        }

        public DataResult<User> Confirm(Guid emailConfirmationToken)
        {
            var systemLogin = _databaseContext.SystemLogins
                .FirstOrDefault(x => x.EmailConfirmationToken.Equals(emailConfirmationToken));
            if (systemLogin == null)
            {
                return new DataResult<User>(DataResultType.NoRecordsFound, "Could not find a login with that email token");
            }

            var user = _databaseContext.Users.FirstOrDefault(x => x.SystemLoginId == systemLogin.SystemLoginId);
            return new DataResult<User>(user, new DataResult(DataResultType.Success, "Successfully confirmed user's email address"));
        }

        public DataResult<User> Login(string emailAddress, string password)
        {
            var systemLogin = _databaseContext.SystemLogins
                .FirstOrDefault(x => x.EmailAddress.Equals(emailAddress));
            if (systemLogin == null)
            {
                return new DataResult<User>(DataResultType.NoRecordsFound, "No users found with that email address");
            }

            if (!systemLogin.IsEmailConfirmed)
            {
                return new DataResult<User>(DataResultType.ConfirmationRequired, "This login has not had the email address confirmed");
            }

            var saltBytes = Convert.FromBase64String(systemLogin.PasswordSalt);
            var saltedHash = GetSaltedHash(password, saltBytes);
            var dbSaltedHash = Convert.FromBase64String(systemLogin.PasswordHash);

            var user = _databaseContext.Users
                .FirstOrDefault(x => x.SystemLoginId == systemLogin.SystemLoginId);
            return AreByteArraysEqual(saltedHash, dbSaltedHash)
                ? new DataResult<User>(user, new DataResult(DataResultType.Success, "Login successful")) 
                : new DataResult<User>(DataResultType.Unauthorised, "The username/password combination is not recognised.", "Authentication failed.");
        }

        private static bool AreByteArraysEqual(IReadOnlyCollection<byte> value1, IReadOnlyList<byte> value2)
        {
            if (value1.Count != value2.Count)
            {
                return false;
            }

            return !value1.Where((t, i) => t != value2[i]).Any();
        }

        private static byte[] GetSaltedHash(string password, IReadOnlyList<byte> saltBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var algorithm = new SHA512Managed();

            var plainTextWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Count];

            for (var i = 0; i < passwordBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = passwordBytes[i];
            }

            for (var i = 0; i < saltBytes.Count; i++)
            {
                plainTextWithSaltBytes[passwordBytes.Length + i] = saltBytes[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
