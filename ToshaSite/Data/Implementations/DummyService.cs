using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data.Implementations
{
    public class DummyService : IEntityService
    {
        private List<Entity> Entities = new List<Entity>();

        public DummyService()
        {
            var r = new Random();
            for(int i = 0; i < 40; i++)
            {
                var e = new Entity();
                var style = r.NextDouble() > 0.5 ? "frogideas" : "heatwave";
                e.Id = i;
                e.ImageLink = r.NextDouble() > 0.2 ? $"http://tinygraphs.com/squares/{r.Next()}?theme={style}&numcolors=4&size=800&fmt=png" : null;
                e.Text = "Здесь должен быть нормальный текст, но я ебал этим ща заниматься, такшо вот вам рыба.";
                e.Link = "https://www.reddit.com";

                Entities.Add(e);
            }
        }

        public IEnumerable<Entity> GetEntities()
        {
            return Entities;
        }

        public void AddEntity(Entity e)
        {
            Entities.Add(e);
        }

        public void DeleteEntity(Entity e)
        {
            Entities.Remove(Entities.FirstOrDefault(x => x.Id == e.Id));
        }

        public bool CheckCredentials(string username, string password)
        {
            return true;
        }
    }
}
