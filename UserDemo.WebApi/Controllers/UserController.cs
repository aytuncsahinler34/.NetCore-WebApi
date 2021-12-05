using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using UserDemo.Business.Abstract;
using UserDemo.Entities;

namespace UserDemo.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private IUserService _userService;
		private readonly ILogger<UserController> _logger;
		private readonly IDistributedCache _distributedCache;

		public UserController(ILogger<UserController> logger, IUserService userService, IDistributedCache distributedCache) {
			_logger = logger;
			_userService = userService;
			_distributedCache = distributedCache;
		}

		////<summary>
		///Get All Hotels
		///</summary>
		///<returns></returns>
		[HttpGet]
		[Route("GetAll")]
		public List<User> GetAll() 
		{
			//redis cache işlemi.
			var cacheData = _distributedCache.GetString("UserCacheDatas");
			if (cacheData == null) 
			{
				var data = _userService.GetAll();
				if (data.Any()) 
				{
					_distributedCache.SetStringAsync("UserCacheDatas", JsonConvert.SerializeObject(data));
					return data;
				}
				return data;
			}
			else 
			{
				var data = _distributedCache.GetString("UserCacheDatas");
				return JsonConvert.DeserializeObject<List<User>>(data);
			}
			
		}

		[HttpGet]
		[Route("GetById/{id:int}")]
		public User GetById(int id) 
		{
			return _userService.GetById(id);
		}

		[HttpPost]
		[Route("Add")]
		public HttpResponseMessage Add([FromBody]User user) 
		{
			if (ModelState.IsValid) 
			{
				var data =_userService.Add(user); //mesaj gösterilsin diye yoksa view ile datayı basabilirdim.
												  //kütüphanede kullanılabilirdi fluentvalidation gibi ama basic  bir validation yaptım.
				_distributedCache.Remove("UserCacheDatas");
				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			else 
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
		}

		[HttpPut]
		[Route("Update")]
		public User Update([FromBody] User user)
		{
			_distributedCache.Remove("UserCacheDatas");
			return _userService.Update(user);
		}

		[HttpDelete]
		[Route("Delete/{id:int}")]
		public void Delete(int id)
		{
			_distributedCache.Remove("UserCacheDatas");
			_userService.Delete(id);
		}
	}
}
