using System.Collections.Generic;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        DataResult<UserDto> Create(UserDto value);
        DataResult<UserDto> Read(int id);
        DataResult<UserDto> ReadByEmailAddress(string emailAddress);
        DataResult<UserDto> Update(UserDto value);
        DataResult Delete(int id);

        DataResult<IEnumerable<UserResponseDto>> GetResponses(int id);
    }
}
