using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi5._0.Model;
using WebApi5._0.Services;

namespace WebApi5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsSearchController : ControllerBase
    {
        private readonly IGoodsRepository _iGoodsRepository;

        public GoodsSearchController(IGoodsRepository iGoodsRepository)
        {
            _iGoodsRepository = iGoodsRepository ;
        }

        [HttpGet]
        public IActionResult SearchByKeyGoods(string keySearch) 
        {
            try
            {
                var result = _iGoodsRepository.GetGoodsAll(keySearch);
                if (result == null)
                {
                    return NotFound();
                }
                else { 
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{idGoods}")]
        public IActionResult EditGoodsMD(string idGoods, goodsModel goods)
        {
            try
            {
                if (Guid.Parse(idGoods) != goods.goodsId)
                {
                    return BadRequest();
                }
                _iGoodsRepository.UpdateGoods(goods);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddGoods(goodsModel goods)
        {
            try
            {
                var resurl = _iGoodsRepository.AddGoods(goods);
                if (resurl == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(resurl);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult GetGoodAll()
        {
            try
            {
               return Ok(_iGoodsRepository.GetGoodsAll());
            }
            catch
            {
                return BadRequest();
            }
        }
       
    }
}
