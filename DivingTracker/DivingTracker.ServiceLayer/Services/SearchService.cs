using System.Threading.Tasks;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Consumers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.JsonModels;

/* 
   For example:
   var search = await SearchService.SearchWikipedia("Donald Trump");
   var page = await SearchService.ReadWikipediaPage("4848272");
   var word = await SearchService.SearchWiktionary("running");
*/

namespace DivingTracker.ServiceLayer.Services
{
    public class SearchService : ISearchService
    {
        private readonly WebConsumer _webConsumer;

        public SearchService(WebConsumer webConsumer)
        {
            Verify.NotNull(webConsumer, nameof(webConsumer));

            _webConsumer = webConsumer;
        }

        public async Task<DataResult<WikipediaSearchDataJdo>> SearchWikipedia(string query)
        {
            return await _webConsumer.SearchWikipedia(query);
        }

        public async Task<DataResult<MediaWikiPageDataJdo>> ReadWikipediaPage(string pageId)
        {
            return await _webConsumer.ReadWikipediaByPageId(pageId);
        }

        public async Task<DataResult<MediaWikiPageDataJdo>> SearchWiktionary(string query)
        {
            return await _webConsumer.SearchWiktionary(query);
        }
    }
}
