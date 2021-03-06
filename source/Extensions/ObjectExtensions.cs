using System.Text;
using System.Text.Json;

namespace DotNetCore.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToBytes(this object obj)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
        }
    }
}
