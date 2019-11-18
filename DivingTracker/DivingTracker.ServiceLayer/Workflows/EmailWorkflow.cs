using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mail;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Repositories;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class EmailWorkflow
    {
        private readonly UserRepository _userRepository;
        private readonly SystemLoginRepository _systemLoginRepository;

        public EmailWorkflow(UserRepository userRepository,
            SystemLoginRepository systemLoginRepository)
        {
            Verify.NotNull(userRepository, nameof(userRepository));
            Verify.NotNull(systemLoginRepository, nameof(systemLoginRepository));

            _userRepository = userRepository;
            _systemLoginRepository = systemLoginRepository;
        }

        public DataResult<IEnumerable<MailMessage>> GetConfirmationEmail(int[] userIds)
        {
            var users = new Collection<User>();
            foreach (var userId in userIds)
            {
                var userResult = _userRepository.Read(userId);
                if (userResult.Type != DataResultType.Success)
                {
                    return userResult.ConvertSingleToEnumerable<User, MailMessage>();
                }
                users.Add(userResult.Value);
            }

            var emails = new Collection<MailMessage>();
            foreach (var user in users)
            {
                var systemLoginResult = _systemLoginRepository.ReadByEmailAddress(user.EmailAddress);
                if (systemLoginResult.Type != DataResultType.Success)
                {
                    return systemLoginResult.ConvertSingleToEnumerable<SystemLogin, MailMessage>();
                }

                var email = new MailMessage();
                email.To.Add(new MailAddress(user.EmailAddress));
                email.Subject = "DivingTracker Authentication: New Email Address Added";
                email.Body =
                    "Thank you for registering with DivingTracker. Please click the link to confirm your email address: " + Environment.NewLine +
                             $"http://localhost:52505/Authentication/ConfirmEmail?emailConfirmationToken={systemLoginResult.Value.EmailConfirmationToken}";
                email.From = new MailAddress("noreply@curio.something");

                emails.Add(email);
            }

            return new DataResult<IEnumerable<MailMessage>>(DataResultType.Success,
                "Emails generated successfully.")
            {
                Value = emails
            };
        }
    }
}
