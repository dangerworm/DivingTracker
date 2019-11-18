using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class UserService : ServiceBase<SqlConnection, SqlTransaction>, IUserService
    {
        private readonly UserWorkflow _userWorkflow;

        public UserService(IUnitOfWork<SqlConnection, SqlTransaction> unitOfWork, UserWorkflow userWorkflow) 
            : base(unitOfWork)
        {
            Verify.NotNull(userWorkflow, nameof(userWorkflow));

            _userWorkflow = userWorkflow;
        }

        public DataResult<UserDto> Create(UserDto value)
        {
            throw new NotImplementedException();
        }

        public DataResult<UserDto> Read(int id)
        {
            UnitOfWork.Begin();

            var result = _userWorkflow.Read(id);

            UnitOfWork.End();

            return result;
        }
        public DataResult<UserDto> ReadByEmailAddress(string emailAddress)
        {
            UnitOfWork.Begin();

            var result = _userWorkflow.ReadByEmailAddress(emailAddress);

            UnitOfWork.End();

            return result;
        }

        public DataResult<UserDto> Update(UserDto value)
        {
            throw new NotImplementedException();
        }

        public DataResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<IEnumerable<UserResponseDto>> GetResponses(int id)
        {
            UnitOfWork.Begin();

            var result = _userWorkflow.GetResponses(id);

            UnitOfWork.End();

            return result;
        }
    }
}
