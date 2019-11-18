using System.Net.Http;
using System.Threading.Tasks;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.JsonModels;
using Newtonsoft.Json;

namespace DivingTracker.ServiceLayer.Consumers
{
    public class WebConsumer
    {
        private const string WikipediaSearchUrl = "https://en.wikipedia.org/w/api.php?action=query&format=json&list=search&srsearch=intitle:";
        private const string WikipediaPageIdUrl = "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=info&inprop=url&pageids=";
        private const string WiktionarySearchUrl = "https://en.wiktionary.org/w/api.php?action=query&format=json&prop=info&inprop=url&titles=";

        private readonly HttpClient _client;

        public WebConsumer()
        {
            _client = new HttpClient();
        }

        public async Task<DataResult<WikipediaSearchDataJdo>> SearchWikipedia(string query)
        {
            try
            {
                var url = $"{WikipediaSearchUrl}{query.Replace(" ", "%20")}";

                var response = await _client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<WikipediaSearchDataJdo>(json);

                return new DataResult<WikipediaSearchDataJdo>(data, DataResultType.Success, "Success");
            }
            catch (HttpRequestException hrex)
            {
                return new DataResult<WikipediaSearchDataJdo>(null, DataResultType.UnknownError, hrex.Message);
            }
        }

        public async Task<DataResult<MediaWikiPageDataJdo>> ReadWikipediaByPageId(string pageId)
        {
            try
            {
                var url = $"{WikipediaPageIdUrl}{pageId}";

                var response = await _client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<MediaWikiPageDataJdo>(json);

                return new DataResult<MediaWikiPageDataJdo>(data, DataResultType.Success, "Success");
            }
            catch (HttpRequestException hrex)
            {
                return new DataResult<MediaWikiPageDataJdo>(null, DataResultType.UnknownError, hrex.Message);
            }
        }

        public async Task<DataResult<MediaWikiPageDataJdo>> SearchWiktionary(string query)
        {
            try
            {
                var url = $"{WiktionarySearchUrl}{query}";

                var response = await _client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<MediaWikiPageDataJdo>(json);

                return new DataResult<MediaWikiPageDataJdo>(data, DataResultType.Success, "Success");
            }
            catch (HttpRequestException hrex)
            {
                return new DataResult<MediaWikiPageDataJdo>(null, DataResultType.UnknownError, hrex.Message);
            }
        }
    }
}
