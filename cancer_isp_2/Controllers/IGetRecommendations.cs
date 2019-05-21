using System.Collections.Generic;

namespace cancer_isp_2.Controllers
{
    public interface IGetRecommendations<out T>
    {
        IEnumerable<T> GetRecommendations();
    }
}