using Newtonsoft.Json;

namespace Dommel.Json.JsonParsers
{
    public class JsonParser : IJsonParser
    {
        public static bool IsParamExist(string param)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TModel>? Params<TModel>(string param) where TModel : class
        {
            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(param);
        }

        public static TModel? SingleOrDefaultParam<TModel>(string param) where TModel : class
        {
            return Params<TModel>(param)?.FirstOrDefault();
        }
    }
}
