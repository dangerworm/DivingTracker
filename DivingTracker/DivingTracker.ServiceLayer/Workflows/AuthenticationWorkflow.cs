using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Repositories;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class AuthenticationWorkflow
    {
        private readonly SystemLoginRepository _systemLoginRepository;
        private readonly UserRepository _userRepository;

        public AuthenticationWorkflow(SystemLoginRepository systemLoginRepository,
            UserRepository userRepository)
        {
            Verify.NotNull(systemLoginRepository, nameof(systemLoginRepository));
            Verify.NotNull(userRepository, nameof(userRepository));

            _systemLoginRepository = systemLoginRepository;
            _userRepository = userRepository;
        }

        public DataResult<UserDto> Register(UserRegistrationRequestDto registrationRequest)
        {
            if (!registrationRequest.Password.Equals(registrationRequest.PasswordConfirmation))
            {
                return new DataResult<UserDto>(DataResultType.ValidationError,
                    "The password and confirmation password must be the same.");
            }

            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var saltBytes = new byte[128];
            rngCryptoServiceProvider.GetBytes(saltBytes);

            var passwordHash = GetSaltedHash(registrationRequest.Password, saltBytes);

            var systemLogin = new SystemLogin
            {
                EmailAddress = registrationRequest.EmailAddress,
                PasswordHash = Convert.ToBase64String(passwordHash),
                PasswordSalt = Convert.ToBase64String(saltBytes),
                EmailConfirmationToken = registrationRequest.ConfirmationToken,
                IsEmailConfirmed = false
            };

            var systemLoginResult = _systemLoginRepository.Create(systemLogin);
            if (systemLoginResult.Type != DataResultType.Success ||
                !systemLoginResult.Value.SystemLoginId.HasValue)
            {
                return systemLoginResult.Convert<SystemLogin, UserDto>();
            }

            var user = new User
            {
                SystemLoginId = systemLoginResult.Value.SystemLoginId.Value,
                FirstName = registrationRequest.FirstName,
                Surname = registrationRequest.Surname,
                DateOfBirth = registrationRequest.DateOfBirth
            };

            return _userRepository.Create(user).Convert<User, UserDto>();
        }

        public DataResult<UserDto> Confirm(Guid emailConfirmationToken)
        {
            var systemLoginResult = _systemLoginRepository.ConfirmEmail(emailConfirmationToken);
            if (systemLoginResult.Type != DataResultType.Success ||
                !systemLoginResult.Value.SystemLoginId.HasValue)
            {
                return systemLoginResult.Convert<SystemLogin, UserDto>();
            }

            var userResult = _userRepository.ReadBySystemLoginId(systemLoginResult.Value.SystemLoginId.Value);
            return userResult.Convert<User, UserDto>();
        }

        public DataResult<UserDto> Login(string emailAddress, string password)
        {
            var systemLoginResult = _systemLoginRepository.ReadByEmailAddress(emailAddress);
            if (systemLoginResult.Type != DataResultType.Success)
            {
                return systemLoginResult.Convert<SystemLogin, UserDto>();
            }

            if (systemLoginResult.Value?.SystemLoginId == null)
            {
                systemLoginResult.Type = DataResultType.Unauthorised;
                systemLoginResult.FriendlyMessage = "The username/password combination is not recognised.";
                systemLoginResult.InternalMessage = "Authentication failed.";
                return systemLoginResult.Convert<SystemLogin, UserDto>();
            }

            var saltBytes = Convert.FromBase64String(systemLoginResult.Value.PasswordSalt);
            var saltedHash = GetSaltedHash(password, saltBytes);
            var dbSaltedHash = Convert.FromBase64String(systemLoginResult.Value.PasswordHash);

            var userResult = _userRepository.ReadBySystemLoginId(systemLoginResult.Value.SystemLoginId.Value);
            if (AreByteArraysEqual(saltedHash, dbSaltedHash))
            {
                return userResult.Convert<User, UserDto>();
            }

            userResult.Value = null;
            userResult.Type = DataResultType.Unauthorised;
            userResult.FriendlyMessage = "The username/password combination is not recognised.";
            userResult.InternalMessage = "Authentication failed.";

            return userResult.Convert<User, UserDto>();
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
