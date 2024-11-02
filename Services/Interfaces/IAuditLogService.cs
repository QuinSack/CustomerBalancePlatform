using CustomerBalancePlatform.Models;

namespace CustomerBalancePlatform.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLog>> GetAuditLogsAsync();
    }
}
