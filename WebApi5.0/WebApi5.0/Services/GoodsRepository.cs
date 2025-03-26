using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi5._0.Data;
using WebApi5._0.Model;

namespace WebApi5._0.Services
{
   
    public class GoodsRepository : IGoodsRepository
    {
        private readonly myDbContext _dbContext;

        public GoodsRepository(myDbContext dbContext) {
            _dbContext = dbContext;
        }
        public List<goodsModel> GetGoodsAll(string KeySearch)
        {
            var searchAllByName = _dbContext.dbGoods.Where(good => good.goodsName.Contains(KeySearch));
            var result = searchAllByName.Select(gd => new goodsModel {
                goodsId = gd.goodsId,
                goodsName = gd.goodsName,
                goodsPrice = gd.goodsPrice,
                goodsDescribe = gd.goodsDescribe,
                goodsCategory = gd.goodsCategory,
                goodsSaleOff = gd.goodsSaleOff,
                CategoriesName = gd.category.CategoriesName,
            });
            return result.ToList();
        }

        public goodsModel AddGoods(goodsModel goodsMD)
        {
            var _goods = new dbGoods
            {
                goodsName = goodsMD.goodsName,
                goodsPrice = goodsMD.goodsPrice,
                goodsDescribe = goodsMD.goodsDescribe,
                goodsCategory = goodsMD.goodsCategory,
                goodsSaleOff = goodsMD.goodsSaleOff,
               
            };
            _dbContext.Add(_goods);
            _dbContext.SaveChanges();
            return new goodsModel
            {
                goodsId = goodsMD.goodsId,
                goodsName = goodsMD.CategoriesName,
            };
        }

        public List<goodsModel> GetGoodsAll()
        {
            var lstgoods = _dbContext.dbGoods.Select(gd => new goodsModel
            {
                goodsId = gd.goodsId,
                goodsName = gd.goodsName,
                goodsCategory = gd.goodsCategory,
                goodsSaleOff = gd.goodsSaleOff,
                goodsDescribe = gd.goodsDescribe,
                goodsPrice = gd.goodsPrice,

            });
            return lstgoods.ToList();
        }

        void IGoodsRepository.UpdateGoods(goodsModel goods)
        {
            var resurlGoods = _dbContext.dbGoods.SingleOrDefault(gd => gd.goodsId == goods.goodsId);
            if (resurlGoods != null)
            {
                resurlGoods.goodsId = goods.goodsId;
                resurlGoods.goodsName = goods.goodsName;
                resurlGoods.goodsCategory = goods.goodsCategory;
                resurlGoods.goodsDescribe = goods.goodsDescribe;
                resurlGoods.goodsPrice = goods.goodsPrice;
                resurlGoods.goodsSaleOff = goods.goodsSaleOff;
                _dbContext.SaveChanges();
            }
        }
    }
}
