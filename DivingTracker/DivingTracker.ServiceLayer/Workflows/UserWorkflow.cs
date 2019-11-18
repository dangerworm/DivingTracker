using System.Collections.Generic;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Repositories;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class UserWorkflow
    {
        private readonly UserRepository _userRepository;
        private readonly UserResponseRepository _userResponseRepository;

        public UserWorkflow(UserRepository userRepository, 
            UserResponseRepository userResponseRepository) 
        {
            Verify.NotNull(userRepository, nameof(userRepository));
            Verify.NotNull(userResponseRepository, nameof(userResponseRepository));

            _userRepository = userRepository;
            _userResponseRepository = userResponseRepository;
        }

        public DataResult<UserDto> Read(int id)
        {
            var result = _userRepository.Read(id);
            return result.Convert<User, UserDto>();
        }

        public DataResult<UserDto> ReadByEmailAddress(string emailAddress)
        {
            var result = _userRepository.ReadByEmailAddress(emailAddress);
            return result.Convert<User, UserDto>();
        }

        public DataResult<IEnumerable<UserResponseDto>> GetResponses(int id)
        {
            var result = _userResponseRepository.ReadAllByUserId(id);
            return result.ConvertAll<UserResponse, UserResponseDto>();
        }
    }
}
