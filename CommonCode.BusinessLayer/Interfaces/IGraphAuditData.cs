using System;

namespace CommonCode.BusinessLayer.Interfaces
{
    public interface IGraphAuditData
    {
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
        Guid OwnerId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}