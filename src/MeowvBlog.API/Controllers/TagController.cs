﻿using MeowvBlog.Services.Dto.Common;
using MeowvBlog.Services.Dto.Tags.Params;
using MeowvBlog.Services.Tags;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UPrime;
using UPrime.WebApi;

namespace MeowvBlog.API.Controllers
{
    /// <summary>
    /// 标签相关API
    /// </summary>
    [Route("Tag")]
    public class TagController : ApiControllerBase
    {
        private readonly ITagService _tagService;

        public TagController()
        {
            _tagService = UPrimeEngine.Instance.Resolve<ITagService>();
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public async Task<UPrimeResponse> Insert([FromBody] InsertTagInput input)
        {
            var response = new UPrimeResponse<string>();

            var result = await _tagService.InsertAsync(input);
            if (!result.Success)
                response.SetMessage(UPrimeResponseStatusCode.Error, result.GetErrorMessage());
            else
                response.Result = result.Result;

            return response;
        }

        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<UPrimeResponse> Update([FromBody] UpdateTagInput input)
        {
            var response = new UPrimeResponse<string>();

            var result = await _tagService.UpdateAsync(input);
            if (!result.Success)
                response.SetMessage(UPrimeResponseStatusCode.Error, result.GetErrorMessage());
            else
                response.Result = result.Result;

            return response;
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<UPrimeResponse> Delete([FromBody] DeleteInput input)
        {
            var response = new UPrimeResponse<string>();

            var result = await _tagService.DeleteAsync(input);

            if (!result.Success)
                response.SetMessage(UPrimeResponseStatusCode.Error, result.GetErrorMessage());
            else
                response.Result = result.Result;

            return response;
        }
    }
}