using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Helpers;

namespace DivingTracker.ServiceLayer.Parsers
{
    public static class UserResponseParser
    {
        public static UserResponse ParseReader(IDataReader reader)
        {
            return new UserResponse(
                reader.Get<int>(UserResponseCols.UserId),
                reader.Get<DateTime>(UserResponseCols.CreatedDate),
                reader.Get<int>(UserResponseCols.QuestionId),
                reader.Get<int>(UserResponseCols.AnswerId)
            );
        }

        public static IEnumerable<UserResponse> ParseMultipleReader(IDataReader reader)
        {
            var values = new Collection<UserResponse>();

            while (reader.Read())
            {
                values.Add(ParseReader(reader));
            }

            return values;
        }

        private enum UserResponseCols
        {
            UserId,
            CreatedDate,
            QuestionId,
            AnswerId
        }
    }
}
