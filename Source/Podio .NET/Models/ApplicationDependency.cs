using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PodioAPI.Utils;

namespace PodioAPI.Models
{
    public class ApplicationDependency
    {
        [JsonProperty("apps")]
        public List<Application> Apps { get; set; }

        [JsonProperty("dependencies")]
        private object DependencyObject { get; set; }

        public Dictionary<long, List<long>> Dependencies
        {
            get { return LoadDependencies(); }
        }

        private Dictionary<long, List<long>> LoadDependencies()
        {
            var dictionaryToLoad = new Dictionary<long, List<long>>();
            var reflectedValuesDictionay = (Dictionary<string, object>) this.GetPropertyValue("DependencyObject");
            if (reflectedValuesDictionay.Count > 0)
            {
                foreach (var item in reflectedValuesDictionay)
                {
                    var dependencyValueJArray = (JArray) item.Value;
                    dictionaryToLoad.Add(long.Parse(item.Key), dependencyValueJArray.ToObject<List<long>>());
                }
            }
            return dictionaryToLoad;
        }
    }
}