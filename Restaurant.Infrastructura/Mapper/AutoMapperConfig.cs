namespace Restaurant.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static void CreateMaps()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
            });
        }
    }
}
