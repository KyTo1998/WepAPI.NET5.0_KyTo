using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi5._0.Controllers.Model;

namespace WebApi5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        public static List<goods> lstGoods = new List<goods>();

        [HttpGet]
        public IActionResult GetlistGoods() { 
            return Ok(lstGoods);
        }

        [HttpGet("{id}")]
        public IActionResult GetGoodsForId(string id) {
            try
            {
                var goods = lstGoods.SingleOrDefault(x => x.idGoods == Guid.Parse(id));
                if (goods == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(goods);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            
        }

        [HttpPost]
        public IActionResult PostGoods(goodsTec tec) {
            try
            {
                var goods = new goods
                {
                    idGoods = Guid.NewGuid(),
                    nameGoodsTec = tec.nameGoodsTec,
                    riceGoodsTec = tec.riceGoodsTec
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
        public IActionResult EditGoods(String id, goods goodsEdits) {
            try
            {
                var goodsEdit = lstGoods.SingleOrDefault(x => x.idGoods == Guid.Parse(id));
                if(goodsEdit == null)
                {
                    return NotFound();
                }
                if(id != goodsEdit.idGoods.ToString())
                {
                    return BadRequest();
                }
                goodsEdit.nameGoodsTec = goodsEdits.nameGoodsTec;
                goodsEdit.riceGoodsTec = goodsEdits.riceGoodsTec;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGoods(String id) {
            try
            {
                var goods = lstGoods.SingleOrDefault(x => x.idGoods == Guid.Parse(id));
                if (goods == null)
                {
                    return NotFound();
                }
                else
                {
                   lstGoods.Remove(goods);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
