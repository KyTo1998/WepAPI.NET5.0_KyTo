using System.Collections.Generic;
using WebApi5._0.Model;

namespace WebApi5._0.Services
{
    public interface IGoodsRepository
    {
        List<goodsModel> GetGoodsAll(string KeySearch);

        goodsModel AddGoods(goodsModel goods);

        List<goodsModel> GetGoodsAll();

        void UpdateGoods(goodsModel goods);
    }
}
