using Microsoft.EntityFrameworkCore;

namespace GiTinder.Models
{
    public interface IValidatable
    {
        bool IsValid { get; }
    }

}