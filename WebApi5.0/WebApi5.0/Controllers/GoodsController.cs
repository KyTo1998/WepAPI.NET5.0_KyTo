using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi5._0.Data;
using WebApi5._0.Model;

namespace WebApi5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {

        public static List<goodsModel> lstGoods = new List<goodsModel>();

        [HttpGet]
        public IActionResult GetlistGoods() { 
            return Ok(lstGoods);
        }

        [HttpGet("{id}")]
        public IActionResult GetGoodsForId(string id) {
            try
            {
                var goodsModels = lstGoods.SingleOrDefault(x => x.goodsId == Guid.Parse(id));
                if (goodsModels == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(goodsModels);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            
        }

        [HttpPost]
        public IActionResult PostGoods(goodsModel tec) {
            try
            {
                var goods = new goodsModel
                {
                    goodsName = tec.goodsName,
                    goodsCategory = tec.goodsCategory,
                    goodsDescribe = tec.goodsDescribe,
                    goodsSaleOff = tec.goodsSaleOff,
                    goodsPrice = tec.goodsPrice,
                };
                lstGoods.Add(goods);
                return Ok(new { 
                    Success = true,Data = goods
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditGoods(String id, goodsModel goodsEdits)
        {
            try
            {
                var goodsEdit = lstGoods.SingleOrDefault(x => x.goodsId == Guid.Parse(id));
                if (goodsEdit == null)
                {
                    return NotFound();
                }
                if (id != goodsEdit.goodsId.ToString())
                {
                    return BadRequest();
                }
                goodsEdit.goodsName = goodsEdits.goodsName;
                goodsEdit.goodsName = goodsEdits.goodsName;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
