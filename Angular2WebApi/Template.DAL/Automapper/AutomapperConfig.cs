using AutoMapper;

namespace Template.DAL.Automapper
{
    public static class AutomapperConfig
    {
        public static void Configuration()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new Mappings()));
        }
    }
}
