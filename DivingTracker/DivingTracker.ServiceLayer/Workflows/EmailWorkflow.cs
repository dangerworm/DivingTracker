using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using CommonCode.BusinessLayer;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class EmailWorkflow
    {
        private readonly DivingTrackerEntities _databaseContext;

        public EmailWorkflow(DivingTrackerEntities databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public DataResult<IEnumerable<MailMessage>> GetConfirmationEmail(int[] userIds)
        {
            var users = new Collection<User>();
            foreach (var userId in userIds)
            {
                var user = _databaseContext.Users.Find(userId);
                if (user == null)
                {
                    return new DataResult<IEnumerable<MailMessage>>(DataResultType.NoRecordsFound, "Could not find user");
                }

                users.Add(user);
            }

            var emails = new Collection<MailMessage>();
            foreach (var user in users)
            {
                var systemLogin = _databaseContext.SystemLogins.Find(user.SystemLoginId);
                if (systemLogin == null)
                {
                    return new DataResult<IEnumerable<MailMessage>>(DataResultType.NoRecordsFound, "Could not find system login");
                }

                var email = new MailMessage();
                email.To.Add(new MailAddress(systemLogin.EmailAddress));
                email.Subject = "DivingTracker Authentication: New Email Address Added";
                email.Body =
                    "Thank you for registering with DivingTracker. Please click the link to confirm your email address: " + Environment.NewLine +
                    $"http://localhost:52505/Authentication/ConfirmEmail?emailConfirmationToken={systemLogin.EmailConfirmationToken}";
                email.From = new MailAddress("noreply@curio.something");

                emails.Add(email);
            }

            return new DataResult<IEnumerable<MailMessage>>(DataResultType.Success, "Emails generated successfully.")
            {
                Value = emails
            };
        }
    }
}
