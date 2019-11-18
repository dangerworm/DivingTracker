using DivingTracker.ServiceLayer.JsonModels;
using System.Threading.Tasks;
using CommonCode.BusinessLayer;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface ISearchService
    {
        Task<DataResult<WikipediaSearchDataJdo>> SearchWikipedia(string query);
        Task<DataResult<MediaWikiPageDataJdo>> ReadWikipediaPage(string pageId);
        Task<DataResult<MediaWikiPageDataJdo>> SearchWiktionary(string query);
    }
}
