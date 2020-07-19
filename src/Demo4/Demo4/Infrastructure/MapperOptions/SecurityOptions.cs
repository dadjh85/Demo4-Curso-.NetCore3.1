
namespace Demo4.Infrastructure.MapperOptions
{
    /// <summary>
    /// Mapper section Security of appsetting.json
    /// </summary>
    public class SecurityOptions
    {
        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string ApiName { get; set; }
    }
}
